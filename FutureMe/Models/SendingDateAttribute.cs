using System.ComponentModel.DataAnnotations;

namespace FutureMe.Models
{
    public class SendingDateAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)// Return a boolean value: true == IsValid, false != IsValid
            {
                DateTime d = Convert.ToDateTime(value);
                return d.Date >= DateTime.Now.Date; //Dates Greater than or equal to today are valid (true)
            }
        }
}
