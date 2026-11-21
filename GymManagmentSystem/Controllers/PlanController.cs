using GymManagmentSystem.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagmentSystem.Controllers
{
    public class PlanController : Controller
    {
        private readonly GymDbContext _dbContext = new GymDbContext();

        //Get BaseUrl/plan
        //Get BaseUrl/plan/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var plans = await _dbContext.Plans.ToListAsync();

            return View(plans);
        }
    }
}
