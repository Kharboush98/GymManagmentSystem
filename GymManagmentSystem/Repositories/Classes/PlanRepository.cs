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

        public async Task<Plan?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _dbContext.Plans.FindAsync([id], ct);
        }

        public async Task<int> UpdateAsync(CancellationToken ct = default)
        {
            try
            {
                return await _dbContext.SaveChangesAsync(ct);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
        }
    }
}
