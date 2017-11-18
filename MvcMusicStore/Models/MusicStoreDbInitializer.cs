using System.Data.Entity;

namespace MvcMusicStore.Models
{
	public class MusicStoreDbInitializer : DropCreateDatabaseAlways<MusicStoreDB>
	{
		protected override void Seed(MusicStoreDB context)
		{
			context.Artists.Add(new Artist { Name = "RHCP" });
			context.Genres.Add(new Genre { Name = "Pop Rock" });
			context.Albums.Add(new Album
			{
				Artist = new Artist { Name = "Ac/Dc" },
				Genre = new Genre { Name = "Rock" },
				Price = 99.9m,
				Title = "Back in Black"
			});

			base.Seed(context);     //does nothing - is it required?
		}
	}
}