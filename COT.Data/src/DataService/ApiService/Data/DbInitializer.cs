using DataLibrary.Models;

namespace ApiService.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CotDataContext dataContext)
        { 
            dataContext.Database.EnsureCreated();
        }
    }
}
