using System;

namespace HomeCinema.Entities
{
    public class Error : IEntityBaseInteger
    {
        public int ID { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
