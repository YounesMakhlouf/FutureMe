using FutureMe.Repositories;
using FutureMe.Services.EmailSender;
using Quartz;

namespace FutureMe.BackgroundJobs
{
    [DisallowConcurrentExecution]
    public class EmailSendingBackgroundJob : IJob
    {
        private readonly IEmailSender _sender;
        private LetterRepository _repository;

        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<EmailSendingBackgroundJob> _logger;

        public EmailSendingBackgroundJob(IServiceProvider serviceProvider, ILogger<EmailSendingBackgroundJob> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("EmailSendingBackgroundJob started at {Time}", DateTime.UtcNow);
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var letterRepository = scope.ServiceProvider.GetRequiredService<ILetterRepository>();
                var emailSender = scope.ServiceProvider.GetRequiredService<IEmailSender>();

                var letters = await letterRepository.GetTodaysLettersAsync();

                var emailTasks = letters.Select(async letter =>
                {
                    try
                    {
                        await emailSender.SendEmailAsync(letter);
                        _logger.LogInformation("Email sent to {Email}", letter.Email);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error sending email to {Email}", letter.Email);
                    }
                });

                await Task.WhenAll(emailTasks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while executing EmailSendingBackgroundJob");
                throw new JobExecutionException(ex);
            }

            _logger.LogInformation("EmailSendingBackgroundJob finished at {Time}", DateTime.UtcNow);
        }
    }
}