using System;
using System.Collections.Generic;

namespace HospitalDocumentation.Model.Enities;

public partial class AppointmentRecordEntity
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public string Reason { get; set; } = null!;

    public virtual ICollection<MedicalRecordEntity> MedicalRecordEntities { get; set; } = new List<MedicalRecordEntity>();
}
