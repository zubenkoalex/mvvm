using System;
using System.Collections.Generic;

namespace Cocojambo.Models.Entities;

public partial class CarEntity
{
    public int Id { get; set; }

    public int? MarkId { get; set; }

    public int? ModelId { get; set; }

    public int? GenerationId { get; set; }

    public int Mileage { get; set; }

    public int Price { get; set; }

    public int ReleaseYear { get; set; }

    public int? PacageId { get; set; }

    public string Picture { get; set; } = null!;

    public virtual GenerationEntity? Generation { get; set; }

    public virtual MarkEntity? Mark { get; set; }

    public virtual ModelEntity? Model { get; set; }

    public virtual PacageEntity? Pacage { get; set; }
}
