using GymManagmentSystem.Enums;

namespace GymManagmentSystem.Entities
{
    public class Trainer : GymUser
    {
        public DateTime HireDate{ get; set; }
        public Specialities Specialities { get; set; }

        public ICollection<Session> Sessions { get; set; } = default!;
    }
}
