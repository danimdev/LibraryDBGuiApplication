using LibraryDBGuiApplication.Data;
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
using LibraryDBGuiApplication.View;

namespace LibraryDBGuiApplication.View
{
    public partial class AddCategoryWindow : Window
    {
        public AddCategoryWindow()
        {
            InitializeComponent();
        }

        private void AddCategoryButton(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(CategoryNameTextbox.Text))
            {
                using (var libraryManager = new LibraryManager())
                {
                    libraryManager.AddCategory(CategoryNameTextbox.Text);

                    using (var context = new LibraryDB())
                    {
                        var query = from category in context.categories select category.CategoryName;

                        ((MainWindow)Application.Current.MainWindow).CategoryComboBox.ItemsSource = query.ToList();
                    }
                }
            }

            base.Close();
        }
    }
}
