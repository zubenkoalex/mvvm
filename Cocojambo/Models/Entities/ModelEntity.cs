using System;
using System.Collections.Generic;

namespace Cocojambo.Models.Entities;

public partial class ModelEntity
{
    public int Id { get; set; }

    public string NameModelCar { get; set; } = null!;

    public virtual ICollection<CarEntity> CarEntities { get; set; } = new List<CarEntity>();
}
