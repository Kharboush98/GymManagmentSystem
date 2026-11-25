using GymManagmentSystem.Entities;
using System.Linq.Expressions;

namespace GymManagmentSystem.Repositories.Interfaces
{
    public interface IMembershipRepository
    {
        Task<bool> AnyAsync(Expression<Func<Membership, bool>> predicate , CancellationToken ct = default);
    }
}
