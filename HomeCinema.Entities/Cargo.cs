﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    public class Cargo : IEntityBase
    {
        public Cargo()
        {
            CargoDetails = new List<CargoDetail>();
        }
        public int ID { get; set; }
        [Required]
        public int Date { get; set; }
        [Required]
        public int Number { get; set; }
        public bool Input { get; set; }
        public bool Output { get; set; }
        public bool Prodution { get; set; }
        [Required]
        public int WHKeeperID { get; set; }
        [DefaultValue(1)]
        public int SumCount { get; set; }
        [DefaultValue(0)]
        public int SumUnitID1 { get; set; }
        [DefaultValue(0)]
        public decimal SumUnitValue1 { get; set; }
        [DefaultValue(0)]
        public int SumunitID2 { get; set; }
        [DefaultValue(0)]
        public decimal SumUnitValue2 { get; set; }
        [DefaultValue(0)]
        public int CreateUserID { get; set; }
        [DefaultValue(0)]
        public Int64 CreateOn { get; set; }
        [DefaultValue(0)]
        public int ModifyUserID { get; set; }
        [DefaultValue(0)]
        public Int64 ModifyOn { get; set; }
        [DefaultValue(0)]
        public int DeleteUserID { get; set; }
        [DefaultValue(0)]
        public Int64 DeleteOn { get; set; }

        public virtual ICollection<CargoDetail> CargoDetails { get; set; }
    }
}
