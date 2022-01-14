using API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository { 
        public CategoryRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
