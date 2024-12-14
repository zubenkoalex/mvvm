using System;
using System.Collections.Generic;

namespace HospitalDocumentation.Model.Enities;
public partial class RecipeEntity
{
    public int Id { get; set; }

    public int? DrugId { get; set; }

    public DateOnly Date { get; set; }

    public string Duration { get; set; } = null!;

    public virtual DrugEntity? Drug { get; set; }

    public virtual ICollection<MedicalRecordEntity> MedicalRecordEntities { get; set; } = new List<MedicalRecordEntity>();
}
