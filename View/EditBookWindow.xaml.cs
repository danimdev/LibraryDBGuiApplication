using LibraryDBGuiApplication.Data;
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
using System.Windows.Shapes;

namespace LibraryDBGuiApplication.View
{
    public partial class EditBookWindow : Window
    {
        //what needs to be done:
        //make the textbox now as a change text holder and
        //after pressing apply it changes in the list and it will be updated

        public EditBookWindow()
        {
            InitializeComponent();


            AddItemsToComboBox();
        }

        void AddItemsToComboBox()
        {
            using(var context = new LibraryDB())
            {
                var query = from Bookname in context.books select Bookname.Name;

                BookIDComboBox.ItemsSource = query.ToList();
            }
        }
    }
}
