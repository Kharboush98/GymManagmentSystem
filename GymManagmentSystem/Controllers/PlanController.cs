using GymManagmentSystem.Repositories.Interfaces;
using GymManagmentSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

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

            var plansViewModel = plans.Select(p => new PlanViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                DurationDays = p.DurationDays,
                isActive = p.isActive
            });


            return View(plansViewModel);
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

            var plansViewModel = new UpdatePlanViewModel()
            {
                Name = plan.Name,
                Description = plan.Description,
                DurationDays = plan.DurationDays,
                Price = plan.Price,
            };

            return View(plansViewModel);
        }


        // Get BaseUrl/plan/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute]int id , UpdatePlanViewModel updatedPlan , CancellationToken ct)
        {
            if(!ModelState.IsValid)
            {
                return View(updatedPlan);
            }

            var plan = await _planRepo.GetByIdAsync(id, ct);

            if (plan is null || !plan.isActive)
            {
                TempData["ErrorMessage"] = "This Plan Cannot be edited";
                return RedirectToAction(nameof(Index));
            }

            var hasCurrentMemberships = await _membershipRepo.AnyAsync(M => M.PlanId == id && M.EndDate > DateTime.Now, ct);

            if (hasCurrentMemberships)
            {
                TempData["ErrorMessage"] = "This Plan Cannot be edited";
                return RedirectToAction(nameof(Index));
            }

            //update
            plan.Description = updatedPlan.Description;
            plan.DurationDays = updatedPlan.DurationDays;
            plan.Price = updatedPlan.Price;
            plan.UpdatedAt = DateTime.Now;

            var res = await _planRepo.UpdateAsync(ct);
            if (res > 0)
            {
                TempData["SuccessMessage"] = "Plan updated successfully";
                return RedirectToAction(nameof(Index));
            } else
            {
                ModelState.AddModelError(string.Empty, "Failed to update plan");
                return View(updatedPlan);
            }
        }
    }
}
