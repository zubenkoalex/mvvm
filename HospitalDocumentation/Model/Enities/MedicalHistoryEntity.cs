using System;
using System.Collections.Generic;

namespace HospitalDocumentation.Model.Enities;

public partial class MedicalHistoryEntity
{
    public int Id { get; set; }

    public string Diagnosis { get; set; } = null!;

    public string DescriptionOfTreatment { get; set; } = null!;

    public virtual ICollection<MedicalRecordEntity> MedicalRecordEntities { get; set; } = new List<MedicalRecordEntity>();
}
