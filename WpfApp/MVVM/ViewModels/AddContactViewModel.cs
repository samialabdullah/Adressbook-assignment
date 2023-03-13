using CommunityToolkit.Mvvm.ComponentModel;


namespace WpfApp.MVVM.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title = "Add Contact";
    }
}
