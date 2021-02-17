using System.Threading.Tasks;
using CoreLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataLibrary.Interfaces
{
    public interface ICotDataContext
    {
        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
        Task<int> SaveAsync();
        void EnsureDataBaseCreated();
        DbSet<RubData> Rub { get; set; }
        DbSet<ChfData> Chf { get; set; }
        DbSet<BtcData> Btc { get; set; }
        DbSet<EurData> Eur { get; set; }
        DbSet<GbpData> Gbp { get; set; }
        DbSet<NzdData> Nzd { get; set; } 
        DbSet<AudData> Aud { get; set; }
        DbSet<JpyData> Jpy { get; set; }
        DbSet<CadData> Cad { get; set; }
        DbSet<UsdData> Usd { get; set; }
        DbSet<GoldData> Gold { get; set; }
        DbSet<SilverData> Silver { get; set; }
        DbSet<CrudeOilData> CrudeOil { get; set; } 
        DbSet<NatGasData> NaturalGas { get; set; }
        DbSet<RawCotData> RawCotData { get; set; }
    }
}
