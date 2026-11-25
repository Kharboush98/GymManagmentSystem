using GymManagmentSystem.Entities;

namespace GymManagmentSystem.Repositories.Interfaces
{
    public interface IPlanRepository
    {
        Task<IEnumerable<Plan>> GetAllAsync(CancellationToken ct = default);
        Task<Plan?> GetByIdAsync(int id, CancellationToken ct = default);

    }
}
