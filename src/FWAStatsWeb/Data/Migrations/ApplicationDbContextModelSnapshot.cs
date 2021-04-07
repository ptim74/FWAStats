﻿// <auto-generated />
using System;
using FWAStatsWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FWAStatsWeb.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity("FWAStatsWeb.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("FWAStatsWeb.Models.BlacklistedClan", b =>
                {
                    b.Property<string>("Tag")
                        .HasMaxLength(15);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Tag");

                    b.ToTable("BlacklistedClans");
                });

            modelBuilder.Entity("FWAStatsWeb.Models.Clan", b =>
                {
                    b.Property<string>("Tag")
                        .HasMaxLength(15);

                    b.Property<string>("BadgeUrl")
                        .HasMaxLength(150);

                    b.Property<int>("ClanLevel");

                    b.Property<int>("ClanPoints");

                    b.Property<string>("Description")
                        .HasMaxLength(300);

                    b.Property<int>("EstimatedWeight");

                    b.Property<string>("Group")
                        .HasMaxLength(10);

                    b.Property<bool>("InLeague");

                    b.Property<bool>("IsWarLogPublic");

                    b.Property<string>("LocationName")
                        .HasMaxLength(30);

                    b.Property<double>("MatchPercentage");

                    b.Property<int>("Members");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("RequiredTrophies");

                    b.Property<int>("Th10Count");

                    b.Property<int>("Th11Count");

                    b.Property<int>("Th12Count");

                    b.Property<int>("Th13Count");

                    b.Property<int>("Th14Count");

                    b.Property<int>("Th8Count");

                    b.Property<int>("Th9Count");

                    b.Property<int>("ThLowCount");

                    b.Property<string>("Type")
                        .HasMaxLength(15);

                    b.Property<int>("WarCount");

                    b.Property<string>("WarFrequency")
                        .HasMaxLength(20);

                    b.Property<int>("WarLosses");

                    b.Property<int>("WarTies");

                    b.Property<int>("WarWinStreak");

                    b.Property<int>("WarWins");

                    b.Property<double>("WinPercentage");

                    b.HasKey("Tag");

                    b.HasIndex("Name");

                    b.ToTable("Clans");
                });

            modelBuilder.Entity("FWAStatsWeb.Models.ClanEvent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Activity");

                    b.Property<string>("ClanTag")
                        .HasMaxLength(15);

                    b.Property<int>("Donations");

                    b.Property<DateTime>("EventDate");

                    b.HasKey("ID");

                    b.HasIndex("EventDate");

                    b.HasIndex("ClanTag", "EventDate");

                    b.ToTable("ClanEvents");
                });

            modelBuilder.Entity("FWAStatsWeb.Models.ClanValidity", b =>
                {
                    b.Property<string>("Tag")
                        .HasMaxLength(15);

                    b.Property<string>("Group")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("Tag");

                    b.HasIndex("ValidFrom");

                    b.HasIndex("ValidTo");

                    b.ToTable("ClanValidities");
                });

            modelBuilder.Entity("FWAStatsWeb.Models.Member", b =>
                {
                    b.Property<string>("Tag")
                        .HasMaxLength(15);

                    b.Property<string>("BadgeUrl")
                        .HasMaxLength(150);

                    b.Property<int>("ClanRank");

                    b.Property<string>("ClanTag")
                        .HasMaxLength(15);

                    b.Property<int>("Donations");

                    b.Property<int>("DonationsReceived");

                    b.Property<int>("ExpLevel");

                    b.Property<string>("LeagueName")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Role")
                        .HasMaxLength(15);

                    b.Property<int>("Trophies");

                    b.HasKey("Tag");

                    b.HasIndex("ClanTag");

                    b.HasIndex("Name");

                    b.HasIndex("Role");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("FWAStatsWeb.Models.Player", b =>
                {
                    b.Property<string>("Tag")
                        .HasMaxLength(15);

                    b.Property<int>("AttackWins");

                    b.Property<int>("BestTrophies");

                    b.Property<int>("DefenseWins");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("TownHallLevel");

                    b.Property<int>("WarStars");

                    b.HasKey("Tag");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("FWAStatsWeb.Models.PlayerEvent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClanTag")
                        .HasMaxLength(15);

                    b.Property<DateTime>("EventDate");

                    b.Property<int>("EventType");

                    b.Property<string>("PlayerTag")
                        .HasMaxLength(15);

                    b.Property<string>("StringValue")
                        .HasMaxLength(15);

                    b.Property<int>("Value");

                    b.HasKey("ID");

                    b.HasIndex("ClanTag", "EventDate");

                    b.HasIndex("EventType", "EventDate");

                    b.HasIndex("PlayerTag", "EventDate");

                    b.ToTable("PlayerEvents");
                });

            modelBuilder.Entity("FWAStatsWeb.Models.UpdateTask", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClanGroup")
                        .HasMaxLength(10);

                    b.Property<string>("ClanName")
                        .HasMaxLength(50);

                    b.Property<string>("ClanTag")
                        .HasMaxLength(15);

                    b.Property<int>("Mode");

                    b.HasKey("ID");

                    b.ToTable("UpdateTasks");
                });

            modelBuilder.Entity("FWAStatsWeb.Models.War", b =>
                {
                    b.Property<string>("ID")
                        .HasMaxLength(30);

                    b.Property<int>("ClanAttacks");

                    b.Property<string>("ClanBadgeUrl")
                        .HasMaxLength(150);

                    b.Property<double>("ClanDestructionPercentage");

                    b.Property<int>("ClanExpEarned");

                    b.Property<int>("ClanLevel");

                    b.Property<string>("ClanName")
                        .HasMaxLength(50);

                    b.Property<int>("ClanStars");

                    b.Property<string>("ClanTag")
                        .HasMaxLength(15);

                    b.Property<DateTime>("EndTime");

                    b.Property<bool>("Friendly");

                    b.Property<bool>("Matched");

                    b.Property<string>("OpponentBadgeUrl")
                        .HasMaxLength(150);

                    b.Property<double>("OpponentDestructionPercentage");

                    b.Property<int>("OpponentLevel");

                    b.Property<string>("OpponentName")
                        .HasMaxLength(50);

                    b.Property<int>("OpponentStars");

                    b.Property<string>("OpponentTag")
                        .HasMaxLength(15);

                    b.Property<DateTime>("PreparationStartTime");

                    b.Property<string>("Result")
                        .HasMaxLength(15);

                    b.Property<DateTime>("StartTime");

                    b.Property<bool>("Synced");

                    b.Property<int>("TeamSize");

                    b.HasKey("ID");

                    b.HasIndex("ClanTag");

                    b.HasIndex("EndTime");

                    b.HasIndex("PreparationStartTime");

                    b.HasIndex("OpponentTag", "EndTime");

                    b.ToTable("Wars");
                });

            modelBuilder.Entity("FWAStatsWeb.Models.WarAttack", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AttackerTag")
                        .HasMaxLength(15);

                    b.Property<int>("DefenderMapPosition");

                    b.Property<string>("DefenderTag")
                        .HasMaxLength(15);

                    b.Property<int>("DefenderTownHallLevel");

                    b.Property<int>("DestructionPercentage");

                    b.Property<bool>("IsOpponent");

                    b.Property<int>("Order");

                    b.Property<int>("Stars");

                    b.Property<string>("WarID")
                        .HasMaxLength(30);

                    b.HasKey("ID");

                    b.HasIndex("AttackerTag");

                    b.HasIndex("DefenderTag");

                    b.HasIndex("WarID", "Order");

                    b.ToTable("WarAttacks");
                });

            modelBuilder.Entity("FWAStatsWeb.Models.WarMember", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsOpponent");

                    b.Property<int>("MapPosition");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("OpponentAttacks");

                    b.Property<string>("Tag")
                        .HasMaxLength(15);

                    b.Property<int>("TownHallLevel");

                    b.Property<string>("WarID")
                        .HasMaxLength(30);

                    b.HasKey("ID");

                    b.HasIndex("Tag");

                    b.HasIndex("WarID", "MapPosition");

                    b.ToTable("WarMembers");
                });

            modelBuilder.Entity("FWAStatsWeb.Models.WarSync", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AllianceMatches");

                    b.Property<DateTime>("Finish");

                    b.Property<int>("MissedStarts");

                    b.Property<DateTime>("Start");

                    b.Property<bool>("Verified");

                    b.Property<int>("WarMatches");

                    b.HasKey("ID");

                    b.HasIndex("Finish");

                    b.HasIndex("Start");

                    b.ToTable("WarSyncs");
                });

            modelBuilder.Entity("FWAStatsWeb.Models.Weight", b =>
                {
                    b.Property<string>("Tag")
                        .HasMaxLength(15);

                    b.Property<int>("ExtWeight");

                    b.Property<bool>("InWar");

                    b.Property<DateTime>("LastModified");

                    b.Property<int>("SyncWeight");

                    b.Property<int>("WarWeight");

                    b.HasKey("Tag");

                    b.ToTable("Weights");
                });

            modelBuilder.Entity("FWAStatsWeb.Models.WeightResult", b =>
                {
                    b.Property<string>("Tag")
                        .HasMaxLength(15);

                    b.Property<int>("Base01");

                    b.Property<int>("Base02");

                    b.Property<int>("Base03");

                    b.Property<int>("Base04");

                    b.Property<int>("Base05");

                    b.Property<int>("Base06");

                    b.Property<int>("Base07");

                    b.Property<int>("Base08");

                    b.Property<int>("Base09");

                    b.Property<int>("Base10");

                    b.Property<int>("Base11");

                    b.Property<int>("Base12");

                    b.Property<int>("Base13");

                    b.Property<int>("Base14");

                    b.Property<int>("Base15");

                    b.Property<int>("Base16");

                    b.Property<int>("Base17");

                    b.Property<int>("Base18");

                    b.Property<int>("Base19");

                    b.Property<int>("Base20");

                    b.Property<int>("Base21");

                    b.Property<int>("Base22");

                    b.Property<int>("Base23");

                    b.Property<int>("Base24");

                    b.Property<int>("Base25");

                    b.Property<int>("Base26");

                    b.Property<int>("Base27");

                    b.Property<int>("Base28");

                    b.Property<int>("Base29");

                    b.Property<int>("Base30");

                    b.Property<int>("Base31");

                    b.Property<int>("Base32");

                    b.Property<int>("Base33");

                    b.Property<int>("Base34");

                    b.Property<int>("Base35");

                    b.Property<int>("Base36");

                    b.Property<int>("Base37");

                    b.Property<int>("Base38");

                    b.Property<int>("Base39");

                    b.Property<int>("Base40");

                    b.Property<int>("Base41");

                    b.Property<int>("Base42");

                    b.Property<int>("Base43");

                    b.Property<int>("Base44");

                    b.Property<int>("Base45");

                    b.Property<int>("Base46");

                    b.Property<int>("Base47");

                    b.Property<int>("Base48");

                    b.Property<int>("Base49");

                    b.Property<int>("Base50");

                    b.Property<bool>("PendingResult");

                    b.Property<int>("TH10Count");

                    b.Property<int>("TH11Count");

                    b.Property<int>("TH12Count");

                    b.Property<int>("TH13Count");

                    b.Property<int>("TH14Count");

                    b.Property<int>("TH7Count");

                    b.Property<int>("TH8Count");

                    b.Property<int>("TH9Count");

                    b.Property<int>("THSum");

                    b.Property<int>("TeamSize");

                    b.Property<DateTime>("Timestamp");

                    b.Property<int>("Weight");

                    b.HasKey("Tag");

                    b.ToTable("WeightResults");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FWAStatsWeb.Models.Member", b =>
                {
                    b.HasOne("FWAStatsWeb.Models.Clan", "Clan")
                        .WithMany("MemberList")
                        .HasForeignKey("ClanTag");
                });

            modelBuilder.Entity("FWAStatsWeb.Models.WarAttack", b =>
                {
                    b.HasOne("FWAStatsWeb.Models.War")
                        .WithMany("Attacks")
                        .HasForeignKey("WarID");
                });

            modelBuilder.Entity("FWAStatsWeb.Models.WarMember", b =>
                {
                    b.HasOne("FWAStatsWeb.Models.War")
                        .WithMany("Members")
                        .HasForeignKey("WarID");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FWAStatsWeb.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FWAStatsWeb.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FWAStatsWeb.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FWAStatsWeb.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
