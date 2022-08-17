using LibraryDBGuiApplication.Data;
using LibraryDBGuiApplication.Models;
using LibraryDBGuiApplication.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryDBGuiApplication
{
    public partial class MainWindow : Window
    {
        public AddBookWindow abw = new();
        public AddCategoryWindow? acw;

        public MainWindow()
        {
            InitializeComponent();
            GiveDataToGrid();
            FillComboBoxWithCategorys();
        }

        void FillComboBoxWithCategorys()
        {
            using(var context = new LibraryDB())
            {
                var query = from category in context.categories select category.CategoryName;

                CategoryComboBox.ItemsSource = query.ToList();
            }
        }

        public void GiveDataToGrid()
        {
            using(var context = new LibraryDB())
            {
                var query = from categories in context.books select categories;

                CategoryDataGrid.ItemsSource = query.ToList();
            }
        }

        private void AddBookButton(object sender, RoutedEventArgs e)
        {
            if (abw.IsActive)
            {
                return;
            }
            else if(abw == null)
            {
                abw = new AddBookWindow();
                abw.Focus();
                abw.Show();
            }
            else
            {
                abw.Show();
            }
        }

        void RemoveAllElementsFromTable()
        {
            using(var context = new LibraryDB())
            {
                var query = from elements in context.categories select elements;

                context.RemoveRange(query);

                context.SaveChanges();
            }
        }

        private void AddCategoryButtonMainWindow(object sender, RoutedEventArgs e)
        {
            if(acw == null)
            {
                acw = new AddCategoryWindow();
                acw.Closed += AddCategoryWindowOnClosed;
                acw.Show();
            }
            else
            {
                acw.Activate();
                acw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
        }

        private void AddCategoryWindowOnClosed(object? sender, EventArgs e)
        {
            acw = null;
        }
    }
}
