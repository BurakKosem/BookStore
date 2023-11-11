using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookService
    {
        IQueryable<BookDto> GetAll(bool tracking);
        Task<BookDto> GetById(int id, bool tracking);
        IQueryable<BookDto> GetByCategory(int id, bool tracking);
        Task<bool> Add(BookDto book);
        bool Update(BookDto book);
        Task<bool> Delete(int id);
        Task<BookDto> GetByName(string name, bool tracking);
        int Save();
        Task<int> SaveAsync();
    }
}
