using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
	public class StoreController : Controller
	{
		// GET: Store
		public string Index()
		{
			return "Hello from Store.Index";
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
	}
}