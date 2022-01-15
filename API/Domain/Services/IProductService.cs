using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.Models;

namespace API.Domain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();

    }
}