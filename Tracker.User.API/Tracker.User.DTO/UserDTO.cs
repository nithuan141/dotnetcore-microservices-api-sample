using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tracker.User.DTO
{
    /// <summary>
    /// The data model for user.
    /// </summary>
    public class UserDTO
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [NotMapped]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,15}$", ErrorMessage = "Password should contain atleast 1 upper case and a number. Length between 8 to 15 characters.")]
        public string Password { get; set; }

        public byte Status { get; set; }

        public string CreateBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string Role { get; set; }

        [NotMapped]
        public string Token { get; set; }
    }
}
