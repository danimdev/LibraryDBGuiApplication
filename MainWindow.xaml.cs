using LibraryDBGuiApplication.Data;
using LibraryDBGuiApplication.Models;
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

namespace LibraryDBGuiApplication
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            //AddCategoryToDatabase();
            GiveDataToGrid();
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

        }


        //test add mathod
        //public void AddCategoryToDatabase()
        //{
        //    using (var context = new LibraryDB())
        //    {
        //        var category = new Category { CategoryName = "Drama" };
        //        context.Add(category);
        //        context.SaveChanges();
        //    }
        //}
    }
}
