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
        private readonly IMembershipRepository _membershipRepo;

        //dependecyInjection
        public PlanController(IPlanRepository planRepo , IMembershipRepository membershipRepo)
        {
            this._planRepo = planRepo;
            this._membershipRepo = membershipRepo;
        }

        // Get BaseUrl/plan or Get BaseUrl/plan/Index
        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken ct)
        {
            var plans = await _planRepo.GetAllAsync(ct);

            return View(plans);
        }

        // Get BaseUrl/plan/Edit/1
        [HttpGet]
        public async Task<IActionResult> Edit(int id , CancellationToken ct)
        {
            var plan = await _planRepo.GetByIdAsync(id , ct);

            if(plan is null || !plan.isActive)
            {
                TempData["ErrorMessage"] = "This Plan Cannot be edited";
                return RedirectToAction(nameof(Index));
            }

            var hasCurrentMemberships = await _membershipRepo.AnyAsync(M => M.PlanId == id && M.EndDate > DateTime.Now , ct);

            if (hasCurrentMemberships)
            {
                TempData["ErrorMessage"] = "This Plan Cannot be edited";
                return RedirectToAction(nameof (Index));
            }

            return View(plan);
        }

    }
}
