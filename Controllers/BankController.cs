using Bank_Branch.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly BankContext _context;

        public BankController(BankContext context)
        {
            _context = context;
        }


        [HttpGet]
        //public IActionResult GetAll()
        //{
        //    var branches = _context.bankBranchTable.ToList();
        //    return Ok(branches);
        //}

        public List<BankBranchResponse> GetAll() 
        {
            return _context.bankBranchTable.Select(b => new BankBranchResponse
            {
                BranchManager = b.BranchManager,
                LocationURL = b.LocationURL,
                LocationName = b.LocationName
        }).ToList();
            
        }

        [HttpPost]
        public IActionResult AddBranch(AddBankBranch form)
        {
            var context = _context;

            var locationName = form.LocationName;
            var locationURL = form.LocationURL;
            var branchManager = form.BranchManager;
            


                context.bankBranchTable.Add(new BankBranch
                {
                    LocationName = locationName,
                    LocationURL = locationURL,
                    BranchManager = branchManager
                });
                context.SaveChanges();

                return Created();
            }
        }
}

