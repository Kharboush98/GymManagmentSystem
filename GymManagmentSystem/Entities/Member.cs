namespace GymManagmentSystem.Entities
{
    public class Member : GymUser
    {
        public string? photo {  get; set; }

        public ICollection<Membership> Memberships { get; set; } = default!;
    }
}
