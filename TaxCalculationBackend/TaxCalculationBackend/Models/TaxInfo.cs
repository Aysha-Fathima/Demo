using System;
using System.Collections.Generic;

namespace TaxCalculationBackend.Models;

public partial class TaxInfo
{
    public int TaxInfoId { get; set; }

    public int? UserId { get; set; }

    public int? AssessmentYear { get; set; }

    public double? IncomeSalary { get; set; }

    public double? IncomeFromProperty { get; set; }

    public double? MunicipalTaxPaid { get; set; }

    public double? ShortTermCapitalGains { get; set; }

    public double? LongTermCapitalGains { get; set; }

    public double? OtherBankInterest { get; set; }

    public double? OtherWinLottery { get; set; }

    public double? GrossTotalIncome { get; set; }

    public double? TotalDeduction { get; set; }

    public double? AdvanceTaxPaid { get; set; }

    public double? OldRegime { get; set; }

    public double? NewRegime { get; set; }

    public virtual UserDatum? User { get; set; }
}
