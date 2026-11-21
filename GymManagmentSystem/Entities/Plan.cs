namespace GymManagmentSystem.Entities
{
    public class Plan : BaseEntity
    {
        public string  Name{ get; set; }
        public string  Description{ get; set; }
        public int DurationDays { get; set; }
        public decimal Price { get; set; }
        public bool isActive { get; set; }

        public ICollection<Membership> Memberships { get; set; } = default!;
    }
}
