using System.ComponentModel.DataAnnotations;

namespace Bank_Branch.Models
{
    public class BankBranch
    {
        [Key]
        public int BankId { get; set; }
        [Required]
        public string LocationName { get; set; }
        [Required]
        public string LocationURL { get; set; }
        [Required]
        public string BranchManager { get; set; }
        [Required]
        public int EmployeeCount {  get; set; }

        [Required]
        public List<Employee> Employees { get; set;}=new List<Employee>();
    }
}
