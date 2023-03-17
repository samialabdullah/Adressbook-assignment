using System.Windows;
using System.Windows.Controls;
using WpfApp.MVVM.Models;
using WpfApp.Services;

namespace WpfApp.MVVM.Views
{ 

    public partial class ContactsView : UserControl
    {
        public ContactsView()
        {
            InitializeComponent();
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var contact = (ContactModel)button.DataContext;
        }

        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var contact = (ContactModel)button.DataContext;


            ContactService.Remove(contact);

        }
    }

}