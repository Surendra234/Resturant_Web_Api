using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResturantWebApi.Models;

namespace ResturantWebApi.Data
{
	public class ResturantDbContext: IdentityDbContext
    {
		public ResturantDbContext(DbContextOptions<ResturantDbContext> options): base(options)
		{

		}

		public DbSet<Customer> Customers { get; set; }

		public DbSet<FoodItem> FoodItems { get; set; }

		public DbSet<OrderMaster> OrderMasters { get; set; }

		public DbSet<OrderDetail> OrderDetails { get; set; }
	}
}

