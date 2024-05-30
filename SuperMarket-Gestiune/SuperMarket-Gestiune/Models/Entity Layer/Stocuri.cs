using System;
using System.Collections.Generic;

namespace SuperMarket_Gestiune.Models;

public partial class Stocuri
{
    public int Id { get; set; }

    public int? ProdusId { get; set; }

    public decimal Cantitate { get; set; }

    public string UnitateMasura { get; set; } = null!;

    public DateTime DataAprovizionarii { get; set; }

    public DateTime? DataExpirarii { get; set; }

    public float PretAchizitie { get; set; }

    public float PretVanzare { get; set; }

    public bool? EsteActiva { get; set; }
}
