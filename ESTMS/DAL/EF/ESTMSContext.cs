﻿using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL.EF
{
    internal class ESTMSContext : DbContext
    {
       
        public DbSet<User> Users { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Team> Teams { get; set; }





    }
}
