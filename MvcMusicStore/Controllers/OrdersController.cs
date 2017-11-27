using MvcMusicStore.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcMusicStore.Controllers
{
	public class OrdersController : Controller
	{
		private readonly MusicStoreDB _context = new MusicStoreDB();

		// GET: Orders
		public ActionResult Index()
		{
			return View(_context.Orders.ToList());
		}

		// GET: Orders/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Order order = _context.Orders.Find(id);
			if (order == null)
			{
				return HttpNotFound();
			}
			return View(order);
		}

		// GET: Orders/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Orders/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "OrderId,OrderDate,Username,FirstName,LastName,Address,City,State,PostalCode,Country,Phone,Email,Total")] Order order)
		{
			if (ModelState.IsValid)
			{
				_context.Orders.Add(order);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(order);
		}

		// GET: Orders/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Order order = _context.Orders.Find(id);
			if (order == null)
			{
				return HttpNotFound();
			}
			return View(order);
		}

		// POST: Orders/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "OrderId,OrderDate,Username,FirstName,LastName,Address,City,State,PostalCode,Country,Phone,Email,Total")] Order order)
		{
			if (ModelState.IsValid)
			{
				_context.Entry(order).State = EntityState.Modified;
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(order);
		}

		// GET: Orders/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Order order = _context.Orders.Find(id);
			if (order == null)
			{
				return HttpNotFound();
			}
			return View(order);
		}

		// POST: Orders/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Order order = _context.Orders.Find(id);
			_context.Orders.Remove(order);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_context.Dispose();
			}
			base.Dispose(disposing);
		}

		public JsonResult CheckUserName(string username)
		{
			var user = Membership.GetUser(username);
			return Json(user == null, JsonRequestBehavior.AllowGet);
		}
	}
}
