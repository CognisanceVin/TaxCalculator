﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Domain.Entities;

namespace TaxCalculator.Domain.Interfaces
{
    public interface ICalculatedTaxRepository
    {
        Task<bool> SaveCalculated(double tax, double income, string postalCode);
    }
}
