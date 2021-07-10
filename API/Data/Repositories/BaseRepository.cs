using API.Data.Contexts;

namespace API.Data.Repositories
{
    public class BaseRepository
    {
        protected AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}