namespace HomeCinema.Web.Models
{
    public class LocationViewModel
    {
        public int ID { get; set; }
        public int WarehouseID { get; set; }
        public string Name { get; set; }
        public string Block { get; set; }
        public string Shelf { get; set; }
        public string Level { get; set; }
        public string Row { get; set; }
    }
}