using System;
using System.ComponentModel.DataAnnotations;

namespace ResturantWebApi.Models
{
	public class OrderDetail
	{
		[Key]
		public long orderDetailId { get; set; }

		public long orderMasterId { get; set; }
		public OrderMaster OrderMaster { get; set; }

		public int foodItemId { get; set; }
		public FoodItem FoodItem { get; set; }

		public decimal foodItemPrice { get; set; }

		public int quantity { get; set; }
	}
}

