﻿namespace MedSino.Domain.Entities.Raitings;

public class Raiting : Auditable
{
    public long DoctorId { get; set; }
    public long UserId { get; set; }
    public float StarCount { get; set; }
}
