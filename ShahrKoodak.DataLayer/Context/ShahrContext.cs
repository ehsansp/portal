using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PortalBuilder.Models;


namespace PortalBuilder.DataLayer.Context
{
    public class ShahrContext:DbContext
    {
        public ShahrContext(DbContextOptions<ShahrContext> options) : base(options)
        {
            
        }

        public DbSet<Article> Articles { get; set; }



    }
}
