using System;
using System.Collections.Generic;

namespace SuperMarket_Gestiune.Models;

public partial class Categorii
{
    public int Id { get; set; }

    public string Nume { get; set; } = null!;

    public bool? EsteActiva { get; set; }
}
