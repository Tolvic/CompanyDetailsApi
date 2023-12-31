﻿namespace CompanyDetails.Core.Models;

public class Entity {
    public string? Role { get; set; }
    public DateOnly? DateFrom { get; set; }
    public DateOnly? DateTo { get; set; }
    public double? OwnershipPercentage { get; set; }
    public string? OwnershipType { get; set; }
}