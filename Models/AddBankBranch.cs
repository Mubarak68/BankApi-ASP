namespace WebApplication1.Models
{
    public class AddBankBranch
    {
        public string LocationName { get; set; }
        public string LocationURL { get; set; }
        public string BranchManager { get; set; }
    }

    public class BankBranchResponse
    {
        public string LocationName { get; set; }
        public string LocationURL { get; set; }
        public string BranchManager { get; set; }
    }
}
