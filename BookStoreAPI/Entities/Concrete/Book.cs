using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Book : EntityBase
    {
        public string Name { get; set; }
        public int Page { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Author { get; set; }
    }
}
