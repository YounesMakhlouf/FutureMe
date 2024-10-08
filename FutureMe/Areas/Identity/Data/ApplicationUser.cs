using FutureMe.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FutureMe.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public ICollection<Letter>? Letters { get; set; }
    public ICollection<Comment>? Comments { get; set; }
}