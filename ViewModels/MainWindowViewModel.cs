using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Windows.Input;
using ReactiveUI;

namespace MusicStore.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ICommand BuyMusicCommand { get; }
    public Interaction<MusicStoreViewModel, AlbumViewModel?> ShowDialog { get; }
    public ObservableCollection<AlbumViewModel> Albums { get; } = new();

    public MainWindowViewModel() {
        ShowDialog = new();
        BuyMusicCommand = ReactiveCommand.CreateFromTask(async() => {
            MusicStoreViewModel store = new();
            var result = await ShowDialog.Handle(store);
            if(result != null)
            {
                Albums.Add(result);
            }
        });
    }
}
