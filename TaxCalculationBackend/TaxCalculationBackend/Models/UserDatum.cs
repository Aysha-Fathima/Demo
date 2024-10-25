using System;
using System.Collections.Generic;

namespace TaxCalculationBackend.Models;

public partial class UserDatum
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? PanCardNumber { get; set; }

    public string? Gender { get; set; }

    public string? MobileNumber { get; set; }

    public string? Email { get; set; }

    public string? UserAddress { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int? Age { get; set; }

    public virtual ICollection<TaxInfo> TaxInfos { get; set; } = new List<TaxInfo>();
}
