using GymManagmentSystem.Contexts;
using GymManagmentSystem.Entities;
using GymManagmentSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Policy;

namespace GymManagmentSystem.Repositories.Classes
{
    public class MembershipRepository : IMembershipRepository
    {
        private readonly GymDbContext _dbContext;

        public MembershipRepository(GymDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<bool> AnyAsync(Expression<Func<Membership, bool>> predicate, CancellationToken ct)
        {
            return await _dbContext.Memberships.AnyAsync(predicate, ct);
        }
    }
}
