using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class BookValidation : AbstractValidator<Book>
    {
        public BookValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);

            RuleFor(x => x.Author)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.CategoryName)
                .NotEmpty()
                .NotNull();
            
        }
    }
}
