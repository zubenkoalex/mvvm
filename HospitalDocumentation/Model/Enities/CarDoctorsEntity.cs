using System;
using System.Collections.Generic;

namespace HospitalDocumentation.Model.Enities;

public partial class CarDoctorsEntity
{
    public int Id { get; set; }

    public string Mark { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Generation { get; set; } = null!;

    public int ReleaseYear { get; set; }

    public int ApproximatePrice { get; set; }

    public virtual ICollection<DoctorEntity> DoctorEntities { get; set; } = new List<DoctorEntity>();
}
