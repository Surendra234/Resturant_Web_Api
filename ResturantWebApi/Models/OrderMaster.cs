using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResturantWebApi.Models
{
	public class OrderMaster
	{
		[Key]
		public long orderMasterId { get; set; }

		[Column(TypeName = "nvarchar(75)")]
		public string orderNumber { get; set; }

		public int customerId { get; set; }
		public Customer Customer { get; set; }

		[Column(TypeName = "nvarchar(10)")]
		public string pMethod { get; set; }

		public decimal gTotal { get; set; }

		public List<OrderDetail> OrderDetails { get; set; }
	}
}

