using ReactiveUI;

namespace MusicStore.ViewModels;

public class MusicStoreViewModel : ViewModelBase
{
    private string? _searchString;
    private bool _isBusy;

    public string? SearchString {
        get => _searchString;
        set => this.RaiseAndSetIfChanged(ref _searchString, value);
    }

    public bool IsBusy {
        get => _isBusy;
        set => this.RaiseAndSetIfChanged(ref _isBusy, value);
    }

}