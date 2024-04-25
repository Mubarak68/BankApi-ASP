using Bank_Branch.Models;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class EmployeeDetails
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public int BankId { get; set; }
    }
}
