﻿using System;
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
        }

        private void AddBookToDBButton(object sender, RoutedEventArgs e)
        {
            
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            base.Hide();
            base.OnClosing(e);
        }
    }
}
