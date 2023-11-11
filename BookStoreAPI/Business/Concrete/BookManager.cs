using AutoMapper;
using Business.Abstract;
using Business.Logger;
using Business.Validations;
using Core.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IBookDal _bookDal;
        private readonly IMapper _mapper;
        private readonly IValidator<Book> _validator;

        public BookManager(IBookDal bookDal, IMapper mapper, IValidator<Book> validator)
        {
            _bookDal = bookDal;
            _mapper = mapper;
            _validator = validator;
        }
     
        public async Task<bool> Add(BookDto bookDto)
        {
            var map = _mapper.Map<Book>(bookDto);
            ValidationTool.Validate(_validator, map);
            await _bookDal.AddAsync(map);
            await _bookDal.SaveAsync();
            return true;
        }
        public bool Update(BookDto bookDto)
        {
            var map = _mapper.Map<Book>(bookDto);
            ValidationTool.Validate(_validator, map);
            _bookDal.Update(map);
            _bookDal.Save();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _bookDal.DeleteAsync(id);
            await _bookDal.SaveAsync();
            return true;
        }

        public IQueryable<BookDto> GetAll(bool tracking)
        {
            var result = _bookDal.GetAll();
            return _mapper.ProjectTo<BookDto>(result);
        }

        public IQueryable<BookDto> GetByCategory(int id, bool tracking )
        {
            var result = _bookDal.GetAll(p => p.CategoryId == id);
            return _mapper.ProjectTo<BookDto>(result);
        }

        public async Task<BookDto> GetById(int id, bool tracking )
        {
           var result = await _bookDal.GetAsync(p => p.Id == id);
            if (result is null)
                throw new BookNotFoundException(id);
            return _mapper.Map<BookDto>(result);
        }

        public async Task<BookDto> GetByName(string name, bool tracking)
        {
           var result =  await _bookDal.GetAsync(p => p.Name == name);
            return _mapper.Map<BookDto>(result);
        }

        public async Task<int> SaveAsync()
        {
            return await _bookDal.SaveAsync();
        }

        public int Save()
        {
            return _bookDal.Save();
        }
    }
}
