using System.Windows;
using System.Windows.Controls;
using WpfApp.MVVM.Models;
using WpfApp.Services;

namespace WpfApp;

public partial class MainWindow : Window
{

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Btn_Remove_Click(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var contact = (ContactModel)button!.DataContext;

        if (MessageBox.Show("Are you sure you want to delete the contact?",
            "Remove contact",
            MessageBoxButton.YesNo,
            MessageBoxImage.Warning) == MessageBoxResult.Yes)
        {
            ContactService.Remove(contact);
        }
    }
}
