using EC04_C_sharp_Adress_book_WpfApp.MVVM.Models;
using EC04_C_sharp_Adress_book_WpfApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EC04_C_sharp_Adress_book_WpfApp.MVVM.Views
{
    /// <summary>
    /// Interaction logic for ContactsListView.xaml
    /// </summary>
    public partial class ContactsListView : UserControl
    {

        private readonly FileService fileService;


        public ContactsListView()
        {
            InitializeComponent();
            fileService = new FileService();
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var contact = (ContactModel)button.DataContext;

            MessageBox.Show(contact.FirstName);
        }

        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var contact = (ContactModel)button.DataContext;

            fileService.Delete(contact);
            //ContactService.CsRemove(contact);
        }
    }
}
