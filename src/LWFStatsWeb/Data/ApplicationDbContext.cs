﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LWFStatsWeb.Models;

namespace LWFStatsWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Clan>().HasIndex(e => e.Name);
            builder.Entity<Member>().HasIndex(e => e.Name);
            builder.Entity<Member>().HasIndex(e => e.Role);
            builder.Entity<War>().HasIndex(e => e.EndTime);
            builder.Entity<WarClanResult>().HasIndex(e => e.Tag);
            builder.Entity<WarOpponentResult>().HasIndex(e => e.Tag);
            builder.Entity<WarSync>().HasIndex(e => e.Start);
            builder.Entity<WarSync>().HasIndex(e => e.Finish);
        }

        public virtual DbSet<Clan> Clans { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<UpdateTask> UpdateTasks { get; set; }
        public virtual DbSet<War> Wars { get; set; }
        public virtual DbSet<WarClanResult> WarParticipants { get; set; }
        public virtual DbSet<WarOpponentResult> WarOpponents { get; set; }
        public virtual DbSet<WarSync> WarSyncs { get; set; }
        public virtual DbSet<WarOpponentBadgeUrls> WarOpponentBadgeUrls { get; set; }
        public virtual DbSet<ClanBadgeUrls> ClanBadgeUrls { get; set; }
    }
}