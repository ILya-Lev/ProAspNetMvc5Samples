using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace MvcMusicStore.Infrastructure
{
	/// <summary>
	/// server side validation only, by the time beings!
	/// </summary>
	public class MaxWordsAttribute : ValidationAttribute
	{
		private readonly int _amount;

		public MaxWordsAttribute(int amount)
			//: base("There are {0} words when max amount is {1}")
			: base($"{{0}} contains more than {amount} words.")
		{
			_amount = amount;
		}

		/// <summary>
		/// error message should contain 2 placeholders:
		///  the first one for actual amount of words,
		///  the second one - for expected
		/// </summary>
		public MaxWordsAttribute(int amount, string errorMessage) : base(errorMessage)
		{
			_amount = amount;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var stringValue = value as string;
			if (!string.IsNullOrWhiteSpace(stringValue))
			{
				var actualAmount = Regex.Split(stringValue, @"\s")
										.Count(part => !string.IsNullOrWhiteSpace(part));

				if (actualAmount > _amount)
					return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
			}
			return ValidationResult.Success;
		}
	}
}