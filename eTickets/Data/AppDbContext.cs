﻿using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Actor_Movie>()
				.HasKey(am => new
				{
					am.ActorId,
					am.MovieId
				});
			modelBuilder.Entity<Actor_Movie>()
				.HasOne(m=>m.Movie)
				.WithMany(am=>am.Actors_Movies)
				.HasForeignKey(m=>m.MovieId);

			modelBuilder.Entity<Actor_Movie>()
				.HasOne(m => m.Actor)
				.WithMany(am => am.Actors_Movies)
				.HasForeignKey(m => m.ActorId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(o => o.Order)
                .HasForeignKey(k => k.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(o => o.Movie)
                .WithMany()
                .HasForeignKey(o => o.MovieId);


            base.OnModelCreating(modelBuilder);
		}

		public DbSet<Actor> Actors { get; set; }
		public DbSet<Producer> Producers { get; set; }
		public DbSet<Actor_Movie> Actors_Movies { get; set; }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<Cinema> Cinemas { get; set; }

		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShopipingCardItem> ShopipingCardItems { get; set; }
	}
}
