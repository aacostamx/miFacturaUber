using miFacturaUber.Models;
using System.Data.Entity;

namespace miFacturaUber.DataAccess
{
    public class FacturaUberContext : DbContext
    {
        public FacturaUberContext() : base("FacturaUberContext")
        {

        }

        public DbSet<FacturaUber> Factura { get; set; }
    }
}