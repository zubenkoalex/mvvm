using System;
using System.Collections.Generic;

namespace Cocojambo.Models.Entities;

public partial class PacageEntity
{
    public int Id { get; set; }

    public string FuelType { get; set; } = null!;

    public string EngineVolume { get; set; } = null!;

    public int EnginePower { get; set; }

    public string Kpptype { get; set; } = null!;

    public string DriveType { get; set; } = null!;

    public string CallType { get; set; } = null!;

    public string CallColor { get; set; } = null!;

    public string Rudder { get; set; } = null!;

    public string NamePacage { get; set; } = null!;

    public virtual ICollection<CarEntity> CarEntities { get; set; } = new List<CarEntity>();
}
