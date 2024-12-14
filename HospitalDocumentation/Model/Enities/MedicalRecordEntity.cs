using System;
using System.Collections.Generic;

namespace HospitalDocumentation.Model.Enities;

public partial class MedicalRecordEntity
{
    public int Id { get; set; }

    public int? PatientId { get; set; }

    public int? DoctorId { get; set; }

    public int? AppointmentRecordId { get; set; }

    public int? MedicalHistoryId { get; set; }

    public int? RecipeId { get; set; }

    public int? LaboratoryTestId { get; set; }

    public virtual AppointmentRecordEntity? AppointmentRecord { get; set; }

    public virtual DoctorEntity? Doctor { get; set; }

    public virtual LaboratoryTestEntity? LaboratoryTest { get; set; }

    public virtual MedicalHistoryEntity? MedicalHistory { get; set; }

    public virtual PatientEntity? Patient { get; set; }

    public virtual RecipeEntity? Recipe { get; set; }
}
