using LibraryDBGuiApplication.Data;
using LibraryDBGuiApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace LibraryDBGuiApplication
{
    public partial class AddBookWindow : Window
    {
        public AddBookWindow()
        {
            InitializeComponent();
            FillComboboxWithCurrentCategories();
        }

        void FillComboboxWithCurrentCategories()
        {
            using(var context = new LibraryDB())
            {
                var query = from categories in context.categories select categories.CategoryName;

                CategoryComboboxSelection.ItemsSource = query.ToList();
            }
        }

        private void AddBookToDBButton(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(CategoryComboboxSelection.SelectedItem.ToString()) && !String.IsNullOrEmpty(BooknameTextbox.Text))
            {
                using (var data = new LibraryManager())
                {
                    Book newBook = new Book();
                    newBook.Name = BooknameTextbox.Text;
                    newBook.Category = CategoryComboboxSelection.SelectedItem.ToString();

                    data.AddBook(newBook.Name,newBook.Category);

                    base.Close();
                }
            }
            else
            {
                MessageBox.Show("Something happend");
                base.Close();
            }
        }
    }
}