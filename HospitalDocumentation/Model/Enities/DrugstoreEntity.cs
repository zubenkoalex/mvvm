using System;
using System.Collections.Generic;

namespace HospitalDocumentation.Model.Enities;

public partial class DrugstoreEntity
{
    public int Id { get; set; }

    public int? DrugId { get; set; }

    public virtual DrugEntity? Drug { get; set; }

    public DrugEntity DrugEntity
    {
        get => default;
        set
        {
        }
    }
}
