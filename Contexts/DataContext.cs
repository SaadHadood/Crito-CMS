using Crito.Models;
using Microsoft.EntityFrameworkCore;

namespace Crito.Contexts;

public class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }


    public DbSet<ContactFormEntity> ContactForms { get; set; }

}
