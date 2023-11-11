using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Task<bool> Add(CategoryDto categoryDto);
        bool Update(CategoryDto categoryDto);
        Task<bool> Delete(int id);

        IQueryable<CategoryDto> GetAll();
    }
}
