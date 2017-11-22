using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcMusicStore.Models
{
	public class Album
	{
		public virtual int AlbumId { get; set; }

		[DisplayName("Genre")]
		public virtual int GenreId { get; set; }

		[DisplayName("Artist")]
		public virtual int ArtistId { get; set; }

		[DataType(DataType.MultilineText)]
		public virtual string Title { get; set; }
		public virtual decimal Price { get; set; }
		public virtual string AlbumArtistUrl { get; set; }
		public virtual Genre Genre { get; set; }
		public virtual Artist Artist { get; set; }
	}
}