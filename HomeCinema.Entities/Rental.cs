﻿using System;

namespace HomeCinema.Entities
{
    /// <summary>
    /// HomeCinema Rental Info
    /// </summary>
    public class Rental : IEntityBaseInteger
    {
        public int ID { get; set; }
        public int CustomerId { get; set; }
        public int StockId { get; set; }
        public virtual Stock Stock { get; set; }
        public DateTime RentalDate { get; set; }
        public Nullable<DateTime> ReturnedDate { get; set; }
        public string Status { get; set; }
    }
}
