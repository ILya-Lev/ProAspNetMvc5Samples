using MvcMusicStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
	public class StoreController : Controller
	{
		// GET: Store
		public ActionResult Index()
		{
			return View(_staticStorage);
		}

		//GET: Store/Browse?genre=string
		public string Browse(string genre)
		{
			var message = HttpUtility.HtmlEncode($"Store.Browse, Genre = {genre}");
			return message;
		}

		//GET: Store/Details/id
		public string Details(int id)
		{
			return $"Store.Details, ID = {id}";
		}

		[Authorize]
		public ActionResult Buy(int albumId)
		{
			var theAlbum = _staticStorage.Single(a => a.AlbumId == albumId);
			return View(theAlbum);
		}

		private static readonly IReadOnlyList<Album> _staticStorage = new List<Album>
		{
			new Album { AlbumId = 2, Title = "The fall of math", Price = 8.99m},
			new Album { AlbumId = 3, Title = "The blue notebooks", Price = 8.99m},
			new Album { AlbumId = 4, Title = "Lost in translation", Price = 9.99m},
			new Album { AlbumId = 5, Title = "Permutation", Price = 10.99m},
		};
	}
}