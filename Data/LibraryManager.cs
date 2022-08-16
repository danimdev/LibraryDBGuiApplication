using LibraryDBGuiApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDBGuiApplication.Data
{
    public class LibraryManager
    {
        public void AddBook(string Bookname,string Categoryname)
        {
            using(var db = new LibraryDB())
            {
                Book book = new Book();
                book.Name = Bookname;
                book.Category = Categoryname;
            }
        }

        public void AddCategory()
        {

        }

    }
}
