using API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Resources
{
    public class CategoryResource
    {
        private Category category;

        public CategoryResource(Category category)
        {
            this.category = category;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}