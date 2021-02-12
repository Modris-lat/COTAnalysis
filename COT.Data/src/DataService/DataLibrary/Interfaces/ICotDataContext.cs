using System.Threading.Tasks;
using CoreLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary.Interfaces
{
    public interface ICotDataContext
    {
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
        Task<int> SaveAsync();
        public DbSet<CotDataDb> Rub { get; set; }
        public DbSet<CotDataDb> Chf { get; set; }
        public DbSet<CotDataDb> Btc { get; set; }
        public DbSet<CotDataDb> Eur { get; set; }
        public DbSet<CotDataDb> Gbp { get; set; }
        public DbSet<CotDataDb> Nzd { get; set; }
        public DbSet<CotDataDb> Aud { get; set; }
        public DbSet<CotDataDb> Jpy { get; set; }
        public DbSet<CotDataDb> Cad { get; set; }
        public DbSet<CotDataDb> Usd { get; set; }
        public DbSet<CotDataDb> Gold { get; set; }
        public DbSet<CotDataDb> Silver { get; set; }
        public DbSet<CotDataDb> CrudeOil { get; set; }
        public DbSet<CotDataDb> NaturalGas { get; set; }
    }
}
