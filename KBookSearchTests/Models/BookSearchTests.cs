using Microsoft.VisualStudio.TestTools.UnitTesting;
using BooksAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Tests
{
    [TestClass()]
    public class BookSearchTests
    {
        [TestMethod()]
        public void SearchTest()
        {
            BookSearch bookSearch = new BookSearch();
            var result = bookSearch.Search("Spinning Silver");
            Assert.AreEqual(result != null,true);
        }
    }
}