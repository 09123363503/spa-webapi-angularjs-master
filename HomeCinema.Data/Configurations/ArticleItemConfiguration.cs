﻿using HomeCinema.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations
{
    public class ArticleItemConfiguration : EntityBaseConfigurationInt<ArticleItem>
    {
        public ArticleItemConfiguration()
        {
            Property(p => p.ArticleID).IsRequired();
            Property(p => p.ComponentItemID).IsRequired();
        }
    }
}
