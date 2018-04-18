using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ch.wuerth.tobias.mux.Data
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public static DataContext GetInstance()
        {
            DataContext dataContext = new DataContext(new DbContextOptions<DataContext>());
            dataContext.Database.Migrate();
            return dataContext;
        }

        public DataContext CreateDbContext(String[] args)
        {
            return GetInstance();
        }
    }
}