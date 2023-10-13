using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using MusicStore.Model;
using ReactiveUI;

namespace MusicStore.ViewModels;

public class MusicStoreViewModel : ViewModelBase
{
    private string? _searchString;
    private bool _isBusy;
    private AlbumViewModel? _selectedAlbum;

    public ObservableCollection<AlbumViewModel> SearchResults { get; } = new();

    public string? SearchString {
        get => _searchString;
        set => this.RaiseAndSetIfChanged(ref _searchString, value);
    }

    public bool IsBusy {
        get => _isBusy;
        set => this.RaiseAndSetIfChanged(ref _isBusy, value);
    }

    public AlbumViewModel? SelectedAlbum {
        get => _selectedAlbum;
        set => this.RaiseAndSetIfChanged(ref _selectedAlbum, value);
    }
    
    public MusicStoreViewModel()
    {
        this.WhenAnyValue(x => x.SearchString)
            .Throttle(TimeSpan.FromMilliseconds(400))
            .ObserveOn(RxApp.MainThreadScheduler)
            .Subscribe(DoSearch!);
    }
       
    private async void DoSearch(string s)
    {
        IsBusy = true;
        SearchResults.Clear();

        if (!string.IsNullOrWhiteSpace(s))
        {
            var albums = await Album.SearchAsync(s);

            foreach (var album in albums)
            {
                AlbumViewModel vm = new(album);
                SearchResults.Add(vm);
            }
        }
        IsBusy = false;
    }
}