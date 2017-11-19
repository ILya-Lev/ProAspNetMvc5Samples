using MvcMusicStore.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcMusicStore.Controllers
{
	public class HomeController : Controller
	{
		private readonly MusicStoreDB _context = new MusicStoreDB();

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Per Aspera ad Astera.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult Edit()
		{
			return View();
		}

		//Get: Home/Search
		[HttpGet]
		public ActionResult Search(string albumName)
		{
			if (string.IsNullOrWhiteSpace(albumName))
				return View();

			var theAlbum = _context.Albums.FirstOrDefault(a =>
															  string.Compare(a.Title, albumName, StringComparison.InvariantCultureIgnoreCase) == 0);

			if (theAlbum == null)
				return HttpNotFound($"Cannot find an album with title {albumName}.");
			return RedirectToAction(nameof(StoreManagerController.Details), "StoreManager",
									new RouteValueDictionary { ["id"] = theAlbum.AlbumId });
		}
	}
}