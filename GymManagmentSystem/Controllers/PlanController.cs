using GymManagmentSystem.Contexts;
using GymManagmentSystem.Repositories.Classes;
using GymManagmentSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagmentSystem.Controllers
{
    public class PlanController : Controller
    {
        private readonly IPlanRepository _planRepo;

        //dependecyInjection
        public PlanController(IPlanRepository planRepo)
        {
            this._planRepo = planRepo;
        }

        // Get BaseUrl/plan or Get BaseUrl/plan/Index
        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken ct)
        {
            var plans = await _planRepo.GetAllAsync(ct);

            return View(plans);
        }
    }
}
