using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagmentSystem.Entities
{
    public class Membership : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int MemberID { get; set; }
        public Member Member { get; set; } = null!;

        public int PlanId { get; set; }
        public Plan Plan { get; set; } = null!;

        [NotMapped]
        public string Status => StartDate > DateTime.Now ? "Upcoming"
            : EndDate > DateTime.Now ? "Active"
            : "Expired";
    }
}
