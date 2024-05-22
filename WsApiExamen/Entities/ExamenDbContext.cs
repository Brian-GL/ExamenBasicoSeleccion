using Microsoft.EntityFrameworkCore;

namespace WsApiExamen.Entities
{
    public class ExamenDbContext : DbContext
    {
        public ExamenDbContext(DbContextOptions<ExamenDbContext> options)
        : base(options)
        {
        }
    }
}
