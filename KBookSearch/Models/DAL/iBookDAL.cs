using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBookSearch.Models.DAL
{
    public interface IBookDAL
    {
        List<BookModel> GetBooks();
        bool SaveBook();
    }
}
