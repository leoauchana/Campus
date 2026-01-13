using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class CampusContext : DbContext
{
    public CampusContext(DbContextOptions<CampusContext> options) : base(options)
    {
    }
}