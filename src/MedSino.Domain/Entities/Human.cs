﻿namespace MedSino.Domain.Entities;

public abstract class Human : Auditable
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;
    public bool IsMale { get; set; }
    public string Email { get; set; } = string.Empty;








}
