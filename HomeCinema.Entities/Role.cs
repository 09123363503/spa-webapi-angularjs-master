namespace HomeCinema.Entities
{
    /// <summary>
    /// HomeCinema Role
    /// </summary>
    public class Role : IEntityBaseInteger
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}