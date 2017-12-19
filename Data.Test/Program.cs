using System;
using System.Linq;
using ch.wuerth.tobias.mux.Core.logging;
using ch.wuerth.tobias.mux.Core.logging.exception;
using ch.wuerth.tobias.mux.Core.logging.information;
using Microsoft.EntityFrameworkCore;

namespace ch.wuerth.tobias.mux.Data.Test
{
    internal class Program
    {
        private static void Main(String[] args)
        {
            DataContext dc = new DataContext(new DbContextOptions<DataContext>(),
                new LoggerBundle
                {
                    Exception = new ExceptionConsoleLogger(null),
                    Information = new InformationConsoleLogger(null)
                });
            foreach (String s in dc.SetTracks.Take(50).Select(x => x.Path).ToList())
            {
                Console.WriteLine(s);
            }
        }
    }
}