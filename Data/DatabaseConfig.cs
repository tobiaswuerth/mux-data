using System;
using System.Collections.Generic;
using System.Text;

namespace ch.wuerth.tobias.mux.Data
{
    public class DatabaseConfig
    {
        public String ConnectionString { get; set; }

        public DatabaseConfig()
        {
            ConnectionString =
                "Data Source=localhost;Initial Catalog=Mux;Integrated Security=True;Persist Security Info=False;User ID=;Password=;MultipleActiveResultSets=True;Connect Timeout=5;Encrypt=True;TrustServerCertificate=True;Application Name=Mux;ConnectRetryCount=3;ConnectRetryInterval=5";
        }
    }
}
