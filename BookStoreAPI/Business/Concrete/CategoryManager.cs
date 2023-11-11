using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {

        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;

        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public async Task<bool> Add(CategoryDto categoryDto)
        {
            var result = _mapper.Map<Category>(categoryDto);
            await _categoryDal.AddAsync(result);
            await _categoryDal.SaveAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _categoryDal.DeleteAsync(id);
            await _categoryDal.SaveAsync();
            return true;
        }


        public bool Update(CategoryDto categoryDto)
        {
            var result = _mapper.Map<Category>(categoryDto);
           _categoryDal.Update(result);
            _categoryDal.Save();
            return true;
        }

        public IQueryable<CategoryDto> GetAll()
        {
            var result = _categoryDal.GetAll();
            return _mapper.ProjectTo<CategoryDto>(result);
        }
    }
}
