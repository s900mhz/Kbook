using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using KBookSearch.Models;

namespace BooksAPI
{
    public class BookSearch
    {
        //Creates the API key than sets up the google book service
        private static string API_KEY = "AIzaSyBeXUW-Nknu_CqR2YSRfegh1OrDkUOmd98";

        public static BooksService service = new BooksService(new BaseClientService.Initializer
        {
            ApplicationName = "ISBNBookSearch",
            ApiKey = API_KEY,
        });


        //Generic Book Search
        public List<BookModel> Search(string query)
        {
            //This loads up the book service query to search for books
            var bookQuery = service.Volumes.List(query);
            var result = bookQuery.Execute();
            //This binds the data coming in to a model

            var books = new List<BookModel>();
            
            foreach (var b in result.Items)
            {
                BookModel book = new BookModel();
                book.Id = b.Id;
                book.Title = b.VolumeInfo.Title;
                book.Subtitle = b.VolumeInfo.Subtitle;
                book.Description = b.VolumeInfo.Description;
                book.PageCount = b.VolumeInfo.PageCount;
                book.Rating = b.VolumeInfo.AverageRating;
                book.CoverURL = b.VolumeInfo.ImageLinks;               
                books.Add(book);
            }

            return books;
        }

    }
}
