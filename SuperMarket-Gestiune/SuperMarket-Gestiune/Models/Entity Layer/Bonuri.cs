using SuperMarket_Gestiune.Models.Entity_Layer;
using System;
using System.Collections.Generic;

namespace SuperMarket_Gestiune.Models;

public partial class Bonuri : BasePropertyChanged
{
    private float sumaIncasata;
    public int Id { get; set; }

    public DateTime DataEliberarii { get; set; }

    public int? CasierId { get; set; }

    public float SumaIncasata
    {
        get { return this.sumaIncasata;}
        set { 
            this.sumaIncasata = value;
            NotifyPropertyChanged(nameof(SumaIncasata));
        }
    }

    public bool? EsteActiva { get; set; }
}
