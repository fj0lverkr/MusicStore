using MusicStore.Model;
using Avalonia.Media.Imaging;
using ReactiveUI;
using System.Threading.Tasks;

namespace MusicStore.ViewModels;

public class AlbumViewModel : ViewModelBase
{
    private readonly Album _album;
    private Bitmap? _cover;

    public string Artist => _album.Artist;
    public string Title => _album.Title;

    public Bitmap? Cover
    {
        get => _cover;
        set => this.RaiseAndSetIfChanged(ref _cover, value);
    }

    public async Task LoadCover()
    {
        await using var imageStream = await _album.LoadCoverBitmapAsync();
        Cover = await Task.Run(() => Bitmap.DecodeToWidth(imageStream, 400));
    }

    public AlbumViewModel(Album album)
    {
        _album = album;
    }
}