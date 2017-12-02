using MvcMusicStore.Infrastructure;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcMusicStore.Models
{
	public class Order
	{
		public int OrderId { get; set; }

		public DateTime OrderDate { get; set; }

		[Remote("CheckUserName", "Orders")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Your {0} is required")]
		[StringLength(160, MinimumLength = 3, ErrorMessage = "Your {0} should be at least 3 and at most 160 symbols long")]
		[DisplayName("First name")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Your {0} is required")]
		[StringLength(160)]
		[DisplayName("Last name")]
		[MaxWords(3, ErrorMessage = "There are too many words in {0}")]
		public string LastName { get; set; }

		public string Address { get; set; }

		public string City { get; set; }

		public string State { get; set; }

		public string PostalCode { get; set; }

		public string Country { get; set; }

		public string Phone { get; set; }

		[EmailAddress(ErrorMessage = "Entered value does not look like an email")]
		public string Email { get; set; }

		public decimal Total { get; set; }
	}
}