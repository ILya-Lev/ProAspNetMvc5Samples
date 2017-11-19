using MvcMusicStore.Models;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
	public class StoreManagerController : Controller
	{
		private readonly MusicStoreDB _context = new MusicStoreDB();

		// GET: StoreManager
		public ActionResult Index()
		{
			var albums = _context.Albums.Include(a => a.Artist).Include(a => a.Genre);
			return View(albums.ToList());
		}

		// GET: StoreManager/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var album = _context.Albums.Find(id);
			if (album == null)
			{
				return HttpNotFound();
			}
			return View(album);
		}

		// GET: StoreManager/Create
		public ActionResult Create()
		{
			ViewBag.ArtistId = new SelectList(_context.Artists, "ArtistId", "Name");
			ViewBag.GenreId = new SelectList(_context.Genres, "GenreId", "Name");
			return View();
		}

		// POST: StoreManager/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "AlbumId,GenreId,ArtistId,Title,Price,AlbumArtistUrl")] Album album)
		{
			if (ModelState.IsValid)
			{
				_context.Albums.Add(album);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.ArtistId = new SelectList(_context.Artists, "ArtistId", "Name", album.ArtistId);
			ViewBag.GenreId = new SelectList(_context.Genres, "GenreId", "Name", album.GenreId);
			return View(album);
		}

		// GET: StoreManager/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Album album = _context.Albums.Find(id);
			if (album == null)
			{
				return HttpNotFound();
			}
			ViewBag.ArtistId = new SelectList(_context.Artists, "ArtistId", "Name", album.ArtistId);
			ViewBag.GenreId = new SelectList(_context.Genres, "GenreId", "Name", album.GenreId);
			return View(album);
		}

		// POST: StoreManager/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit()
		{
			var album = new Album();
			try
			{
				//UpdateModel(album);
				UpdateModel(album, new[] { nameof(Album.AlbumArtistUrl), nameof(Album.AlbumId), nameof(Album.ArtistId), nameof(Album.GenreId), nameof(Album.Title), nameof(Album.Price) });
				_context.Entry(album).State = EntityState.Modified;
				_context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			catch (Exception exc)
			{
				Debug.WriteLine(exc);
				ViewBag.ArtistId = new SelectList(_context.Artists, "ArtistId", "Name", album.ArtistId);
				ViewBag.GenreId = new SelectList(_context.Genres, "GenreId", "Name", album.GenreId);
				return View(album);
			}
		}
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Edit([Bind(Include = "AlbumId,GenreId,ArtistId,Title,Price,AlbumArtistUrl")] Album album)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		_context.Entry(album).State = EntityState.Modified;
		//		_context.SaveChanges();
		//		return RedirectToAction("Index");
		//	}
		//	ViewBag.ArtistId = new SelectList(_context.Artists, "ArtistId", "Name", album.ArtistId);
		//	ViewBag.GenreId = new SelectList(_context.Genres, "GenreId", "Name", album.GenreId);
		//	return View(album);
		//}

		// GET: StoreManager/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Album album = _context.Albums.Find(id);
			if (album == null)
			{
				return HttpNotFound();
			}
			return View(album);
		}

		// POST: StoreManager/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Album album = _context.Albums.Find(id);
			_context.Albums.Remove(album);
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
	}
}
