using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Identities
{
    public record UserForRegistration
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }

        [Required(ErrorMessage = "Username is required!")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Password is required!")]
        public string? Password { get; init; }

        [Required(ErrorMessage = "Email is required!")]
        public string? Email { get; init; }

        public ICollection<string>? Roles { get; init; }
    }
}
