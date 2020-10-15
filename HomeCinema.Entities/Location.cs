﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    public class Location : IEntityBaseInteger
    {
        public Location()
        {
            Cargos = new List<Cargo>();
        }
        public int ID { get; set; }
        public int WarehouseID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Block { get; set; }
        public string Shelf { get; set; }
        public string Level { get; set; }
        public string Row { get; set; }

        public virtual ICollection<Cargo> Cargos { get; set; }
    }
}
