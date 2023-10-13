using MusicStore.Model;

namespace MusicStore.ViewModels;

public class AlbumViewModel : ViewModelBase
{
    private readonly Album _album;

    public string Artist => _album.Artist;
    public string Title => _album.Title;

    public AlbumViewModel(Album album)
    {
        _album = album;
    }
}