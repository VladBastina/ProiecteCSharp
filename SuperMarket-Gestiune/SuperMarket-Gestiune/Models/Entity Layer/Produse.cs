using System;
using System.Collections.Generic;

namespace SuperMarket_Gestiune.Models;

public partial class Produse
{
    public int Id { get; set; }

    public string Nume { get; set; } = null!;

    public string CodBare { get; set; } = null!;

    public int? CategorieId { get; set; }

    public int? ProducatorId { get; set; }

    public bool? EsteActiva { get; set; }
}
