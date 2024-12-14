using System;
using System.Collections.Generic;

namespace HospitalDocumentation.Model.Enities;

public partial class LaboratoryTestEntity
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public DateOnly Date { get; set; }

    public string Result { get; set; } = null!;

    public virtual ICollection<MedicalRecordEntity> MedicalRecordEntities { get; set; } = new List<MedicalRecordEntity>();
}
