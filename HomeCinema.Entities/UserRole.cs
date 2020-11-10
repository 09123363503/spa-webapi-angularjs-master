namespace HomeCinema.Entities
{
    /// <summary>
    /// HomeCinema User's Role
    /// </summary>
    public class UserRole : IEntityBaseInteger
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
