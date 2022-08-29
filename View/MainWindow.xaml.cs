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

        public AddBookWindow? abw;
        public AddCategoryWindow? acw;

        public MainWindow()
        {
            InitializeComponent();
            GiveDataToGrid();
            FillComboBoxWithCategorys();

            using(var Library = new LibraryManager())
            {
                CategoryDataGrid.ItemsSource = Library.UpdateBooks();
            }
        }

        void FillComboBoxWithCategorys()
        {
            using (var context = new LibraryDB())
            {
                var query = from category in context.categories select category.CategoryName;

                CategoryComboBox.ItemsSource = query.ToList();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if(acw != null)
                acw.Close();
            if (abw != null)
                abw.Close();
            base.OnClosing(e);
        }

        public void GiveDataToGrid()
        {
            using (var context = new LibraryDB())
            {
                var query = from categories in context.books select categories;

                CategoryDataGrid.ItemsSource = query.ToList();
            }
        }

        private void AddBookButton(object sender, RoutedEventArgs e)
        {
            if (abw == null)
            {
                abw = new AddBookWindow();
                abw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                abw.Activate();
                abw.Closed += Abw_Closed;
                abw.Show();
            }
            else if (abw.IsActive)
            {
                abw.Focus();
                return;
            }
        }

        private void Abw_Closed(object? sender, EventArgs e)
        {
            abw = null;
            GiveDataToGrid();
        }

        void RemoveAllElementsFromTable()
        {
            using (var context = new LibraryDB())
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
                acw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                acw.Activate();
                acw.Closed += AcwOnClosed;
                acw.Show();
            }
            else if (acw.IsActive)
            {
                acw.Focus();
                return;
            }
        }

        private void AcwOnClosed(object? sender, EventArgs e)
        {
            acw = null;
        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (CategoryComboBox.SelectedItem.ToString() != "All")
            {
                using (var context = new LibraryDB())
                {
                    var query = from category in context.books where category.Category == CategoryComboBox.SelectedItem.ToString() select category;

                    CategoryDataGrid.ItemsSource = query.ToList();
                }
            }
            else
            {
                GiveDataToGrid();
            }
        }
    }
}
