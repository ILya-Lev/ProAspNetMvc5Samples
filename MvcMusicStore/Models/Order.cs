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
		[ScaffoldColumn(false)]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Your {0} is required")]
		[StringLength(160, MinimumLength = 3, ErrorMessage = "Your {0} should be at least 3 and at most 160 symbols long")]
		[Display(Name = "First name", Order = 11000)]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Your {0} is required")]
		[StringLength(160)]
		[Display(Name = "Last name", Order = 12000)]
		[MaxWords(3, ErrorMessage = "There are too many words in the {0}")]
		public string LastName { get; set; }

		public string Address { get; set; }

		public string City { get; set; }

		public string State { get; set; }

		public string PostalCode { get; set; }

		public string Country { get; set; }

		public string Phone { get; set; }

		[EmailAddress(ErrorMessage = "Entered value does not look like an email")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[ReadOnly(true)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
		[DataType(DataType.Currency)]
		public decimal Total { get; set; }
	}
}