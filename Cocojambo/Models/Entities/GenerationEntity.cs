using System;
using System.Collections.Generic;

namespace Cocojambo.Models.Entities;

public partial class GenerationEntity
{
    public int Id { get; set; }

    public string NameGeneration { get; set; } = null!;

    public virtual ICollection<CarEntity> CarEntities { get; set; } = new List<CarEntity>();
}
