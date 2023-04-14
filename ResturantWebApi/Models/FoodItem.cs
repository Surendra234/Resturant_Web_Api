using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResturantWebApi
{
	public class FoodItem
	{
		[Key]
		public int foodItem { get; set; }

		[Column(TypeName = "nvarchar(100)")]
		public string foodItemName { get; set; }

		public decimal price { get; set; }
	}
}

