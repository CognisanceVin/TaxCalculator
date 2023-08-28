using Microsoft.EntityFrameworkCore;
using TaxCalculator.Domain.Entities.ReferenceData;
using System.Collections.Generic;

namespace TaxCalculator.Infrastructure.Persistence
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostalCode>().HasData(PostalCodeList);
            modelBuilder.Entity<TaxBaseRate>().HasData(PostalCodeList);
        }
        public static List<PostalCode> PostalCodeList => new()
        {
            new PostalCode { Code = "7441",TaxType = "Progressive"},
            new PostalCode { Code = "A100",TaxType = "Flat Value"},
            new PostalCode { Code = "7000",TaxType = "Flat Rate"},
            new PostalCode { Code = "1000",TaxType = "Progressive"}
        };
        public static List<TaxBaseRate> TaxRateList => new()
        {
            new TaxBaseRate { FromAmount = 0, ToAmount = 8350},
            new TaxBaseRate { FromAmount = 8351, ToAmount = 33950 },
            new TaxBaseRate { FromAmount = 33951, ToAmount = 82250 },
            new TaxBaseRate { FromAmount = 82251, ToAmount = 171550 },
            new TaxBaseRate { FromAmount = 171551, ToAmount = 372950  },
            new TaxBaseRate { FromAmount = 372951}
        };

    }
}
