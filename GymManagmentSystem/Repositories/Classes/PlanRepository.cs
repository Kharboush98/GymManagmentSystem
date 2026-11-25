using GymManagmentSystem.Contexts;
using GymManagmentSystem.Entities;
using GymManagmentSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymManagmentSystem.Repositories.Classes
{
    public class PlanRepository : IPlanRepository
    {
        private readonly GymDbContext _dbContext;

        public PlanRepository(GymDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<Plan>> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbContext.Plans.AsNoTracking().ToListAsync(ct);
        }
    }
}
