using System;
using System.Collections.Generic;

namespace SuperMarket_Gestiune.Models;

public partial class Utilizatori
{
    public int Id { get; set; } = 0;

    public string NumeUtilizator { get; set; } = null!;

    public string Parola { get; set; } = null!;

    public string TipUtilizator { get; set; } = null!;

    public bool? EsteActiva { get; set; } = true;
}
