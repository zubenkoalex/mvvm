using System;
using System.Collections.Generic;

namespace HospitalDocumentation.Model.Enities;

public partial class DoctorEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Speciality { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? CarId { get; set; }

    public virtual CarDoctorsEntity? Car { get; set; }

    public virtual ICollection<MedicalRecordEntity> MedicalRecordEntities { get; set; } = new List<MedicalRecordEntity>();

    public CarDoctorsEntity CarDoctorsEntity
    {
        get => default;
        set
        {
        }
    }
}
