using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcMusicStore.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace MvcMusicStore.Tests.Infrastructure
{
	[TestClass]
	public class MaxWordsAttributeTests
	{
		private class MaxWordsPublicValidate : MaxWordsAttribute
		{
			public MaxWordsPublicValidate(int amount) : base(amount)
			{
			}

			public MaxWordsPublicValidate(int amount, string errorMessage) : base(amount, errorMessage)
			{
			}

			public ValidationResult DoValidation(object value, ValidationContext context)
			{
				return base.IsValid(value, context);
			}
		}

		private MaxWordsPublicValidate _maxWordsAttribute;
		private ValidationContext _validationContext;

		[TestInitialize]
		public void Initialize()
		{
			_maxWordsAttribute = new MaxWordsPublicValidate(3);
			_validationContext = new ValidationContext("a");
		}

		[TestMethod]
		public void IsValid_TwoWords_Valid()
		{
			var result = _maxWordsAttribute.DoValidation("two words", _validationContext);
			result.Should().BeNull();
		}
		[TestMethod]
		public void IsValid_ThreeWords_Valid()
		{
			var result = _maxWordsAttribute.DoValidation("another three words", _validationContext);
			result.Should().BeNull();
		}
		[TestMethod]
		public void IsValid_TreeWordsManyWhitespaces_Valid()
		{
			var input = "    another	 tree   words		";

			var result = _maxWordsAttribute.DoValidation(input, _validationContext);

			result.Should().BeNull();
		}
		[TestMethod]
		public void IsValid_FourWords_Invalid()
		{
			var result = _maxWordsAttribute.DoValidation("here are four words", _validationContext);

			result.Should().NotBeNull();
			result.ErrorMessage.Should().NotBeNullOrWhiteSpace();
		}
		[TestMethod]
		public void IsValid_FourWordsCustomMessage_Invalid()
		{
			var errorMessage = "Too many words!";
			var attribute = new MaxWordsPublicValidate(3, errorMessage);

			var result = attribute.DoValidation("here are four words", _validationContext);

			result.Should().NotBeNull();
			result.ErrorMessage.Should().NotBeNullOrWhiteSpace();
			result.ErrorMessage.Should().Be(errorMessage);
		}
	}
}
