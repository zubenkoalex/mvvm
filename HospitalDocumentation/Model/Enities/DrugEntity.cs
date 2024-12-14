using System;
using System.Collections.Generic;

namespace HospitalDocumentation.Model.Enities;

public partial class DrugEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Dosage { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public virtual ICollection<DrugstoreEntity> DrugstoreEntities { get; set; } = new List<DrugstoreEntity>();

    public virtual ICollection<RecipeEntity> RecipeEntities { get; set; } = new List<RecipeEntity>();
}
