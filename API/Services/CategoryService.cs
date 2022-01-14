using API.Domain.Models;
using API.Domain.Services;

namespace API.Services
{
    public class CategoryService : ICategoryService
    {
        public async Task<IEnumerable<Category>> ListAsync()
        {
            return null;
        }
    }
}
