using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTunesSearch.Library;

namespace MusicStore.Model;

public class Album
{
    private static readonly iTunesSearchManager s_SearchManager = new();

    public string Artist { get; set; }
    public string Title { get; set; }
    public string CoverUrl { get; set; }

    public Album(string artist, string title, string coverUrl)
    {
        Artist = artist;
        Title = title;
        CoverUrl = coverUrl;
    }

    public static async Task<IEnumerable<Album>> SearchAsync(string searchString)
    {
        var query = await s_SearchManager.GetAlbumsAsync(searchString)
        .ConfigureAwait(false);

        return query.Albums.Select(x =>
                new Album(x.ArtistName, x.CollectionName, 
                    x.ArtworkUrl100.Replace("100x100bb", "600x600bb")));
    }
}