using MvcMusicStore.Models;
using System.Linq;

namespace MvcMusicStore.Migrations
{
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<MusicStoreDB>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(MusicStoreDB context)
		{
			if (!context.Artists.Any(a => a.Name == "RHCP"))
				context.Artists.Add(new Artist { Name = "RHCP" });

			if (!context.Genres.Any(g => g.Name == "Pop Rock"))
				context.Genres.Add(new Genre { Name = "Pop Rock" });

			if (!context.Albums.Any(a => a.Title == "Back in Black"))
				context.Albums.Add(new Album
				{
					Artist = new Artist { Name = "Ac/Dc" },
					Genre = new Genre { Name = "Rock" },
					Price = 99.9m,
					Title = "Back in Black"
				});
		}
	}
}
