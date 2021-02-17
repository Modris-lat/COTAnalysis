using System.Threading.Tasks;
using CoreLibrary.Models;
using DataLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary.Models
{
    public class CotDataContext: DbContext, ICotDataContext
    {
        public CotDataContext(DbContextOptions<CotDataContext> options)
            : base(options) { }

        public DbSet<RubData> Rub { get; set; }
        public DbSet<ChfData> Chf { get; set; }
        public DbSet<BtcData> Btc { get; set; }
        public DbSet<EurData> Eur { get; set; }
        public DbSet<GbpData> Gbp { get; set; }
        public DbSet<NzdData> Nzd { get; set; }
        public DbSet<AudData> Aud { get; set; }
        public DbSet<JpyData> Jpy { get; set; }
        public DbSet<CadData> Cad { get; set; }
        public DbSet<UsdData> Usd { get; set; }
        public DbSet<GoldData> Gold { get; set; }
        public DbSet<SilverData> Silver { get; set; }
        public DbSet<CrudeOilData> CrudeOil { get; set; }
        public DbSet<NatGasData> NaturalGas { get; set; }
        public DbSet<RawCotData> RawCotData { get; set; }

        public async Task<int> SaveAsync()
        {
            return await SaveChangesAsync();
        }
        public void EnsureDataBaseCreated()
        {
            Database.EnsureCreatedAsync();
        }
    }
}
