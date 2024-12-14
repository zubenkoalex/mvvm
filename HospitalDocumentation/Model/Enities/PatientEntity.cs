using System;
using System.Collections.Generic;

namespace HospitalDocumentation.Model.Enities;
public partial class PatientEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string Sex { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<MedicalRecordEntity> MedicalRecordEntities { get; set; } = new List<MedicalRecordEntity>();
}
