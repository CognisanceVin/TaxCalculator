using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Domain.Entities;
using TaxCalculator.Domain.Entities.ReferenceData;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaxCalculator.Infrastructure.Persistence
{
    public class TaxCalculatorContext : DbContext
    {

        public TaxCalculatorContext()
        {
        }
        public TaxCalculatorContext(DbContextOptions<TaxCalculatorContext> options)
            : base(options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=localhost;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PostalCode>()
                    .HasData(new PostalCode
                    {
                        Id = 1,
                        Code = "7441",
                        TaxType = "Progressive"
                    }, new PostalCode
                    {
                        Id = 2,
                        Code = "A100",
                        TaxType = "Flat Value"
                    },
                      new PostalCode
                      {
                          Id = 3,
                          Code = "7000",
                          TaxType = "Flat Rate"
                      },
                        new PostalCode
                        {
                            Id = 4,
                            Code = "1000",
                            TaxType = "Progressive"
                        }
                    );
            modelBuilder.Entity<TaxBaseRate>()
        .HasData(new TaxBaseRate
        {
            Id = 1,
            Rate = 10,
            FromAmount = 0,
            ToAmount = 8350
        }, new TaxBaseRate
        {
            Id = 2,
            Rate = 15,
            FromAmount = 8351,
            ToAmount = 33950
        }, new TaxBaseRate
        {
            Id = 3,
            Rate = 25,
            FromAmount = 33951,
            ToAmount = 82250
        }, new TaxBaseRate
        {
            Id = 4,
            Rate = 28,
            FromAmount = 82251,
            ToAmount = 171550
        }, new TaxBaseRate
        {
            Id = 5,
            Rate = 33,
            FromAmount = 171551,
            ToAmount = 372950
        }, new TaxBaseRate
        {
            Id = 6,
            Rate = 35,
            FromAmount = 372951
        }
                 );

        }
        public DbSet<PostalCode> PostalCodes { get; set; }
        public DbSet<TaxBaseRate> TaxBaseRates { get; set; }
        public DbSet<CalculatedTax> CalculatedTaxes { get; set; }

    }
}
