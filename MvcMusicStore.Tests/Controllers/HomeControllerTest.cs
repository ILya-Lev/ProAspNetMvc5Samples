using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcMusicStore.Controllers;
using System.Web.Mvc;

namespace MvcMusicStore.Tests.Controllers
{
	[TestClass]
	public class HomeControllerTest
	{
		[TestMethod]
		public void Index_ShouldExist()
		{
			var controller = new HomeController();
			var result = controller.Index() as ViewResult;
			result.Should().NotBeNull();
		}

		[TestMethod]
		public void About_TitleShouldMathc()
		{
			var controller = new HomeController();
			var result = controller.About() as ViewResult;
			(result.ViewBag.Message as string).Should().Be("Your application description page.");
		}

		[TestMethod]
		public void Contact_ShouldExist()
		{
			var controller = new HomeController();
			var result = controller.Contact() as ViewResult;
			result.Should().NotBeNull();
			(result.ViewBag.Message as string).Should().Be("Your contact page.");
		}
	}
}
