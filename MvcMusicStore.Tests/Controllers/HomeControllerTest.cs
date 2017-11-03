using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcMusicStore.Controllers;
using System.Web;
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
			(result.ViewBag.Message as string).Should().Be("Per Aspera ad Astera.");
		}

		[TestMethod]
		public void Contact_ShouldExist()
		{
			var controller = new HomeController();
			var result = controller.Contact() as ViewResult;
			result.Should().NotBeNull();
			(result.ViewBag.Message as string).Should().Be("Your contact page.");
		}

		[TestMethod]
		[TestCategory("experiments")]
		public void HttpUtility_HtmlEncode_MaliciousScript()
		{
			var htmlEncoded = HttpUtility.HtmlEncode(@"\x3cscript\x3e%20alert(\x27pwnd\x27)%20\x3c/script\x3e");
			var htmlDecoded = HttpUtility.HtmlDecode(@"\x3cscript\x3e%20alert(\x27pwnd\x27)%20\x3c/script\x3e");
			var urlEncoded = HttpUtility.UrlEncode(@"\x3cscript\x3e%20alert(\x27pwnd\x27)%20\x3c/script\x3e");
			var urlDecoded = HttpUtility.UrlDecode(@"\x3cscript\x3e%20alert(\x27pwnd\x27)%20\x3c/script\x3e");

			var ajaxHelper = new AjaxHelper(new ViewContext(), new ViewPage());
			var jsEncoded = ajaxHelper.JavaScriptStringEncode(@"\x3cscript\x3e%20alert(\x27pwnd\x27)%20\x3c/script\x3e");

			htmlEncoded.Should().Contain(@"<script>");
			htmlDecoded.Should().Contain(@"<script>");
			jsEncoded.Should().Contain(@"<script>");
		}
	}
}
