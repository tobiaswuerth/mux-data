using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ch.wuerth.tobias.mux.Data
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(String[] args)
        {
            return GetInstance();
        }

        public static DataContext GetInstance()
        {
            DataContext dataContext = new DataContext(new DbContextOptions<DataContext>());
            dataContext.Database.Migrate();
            return dataContext;
        }
    }
}