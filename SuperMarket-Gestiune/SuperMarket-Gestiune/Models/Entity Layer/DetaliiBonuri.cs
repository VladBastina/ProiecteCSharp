using SuperMarket_Gestiune.Models.Entity_Layer;
using System;
using System.Collections.Generic;

namespace SuperMarket_Gestiune.Models;

public partial class DetaliiBonuri : BasePropertyChanged
{
    private decimal _amount;
    private float _price;
    public int Id { get; set; }

    public int? BonId { get; set; }

    public int? ProdusId { get; set; }

    public decimal Cantitate
    {
        get
        {
            return _amount;
        }
        set
        {
            if (_amount != value) { _amount = value; }
            NotifyPropertyChanged(nameof(Cantitate));
        }
    }

    public float Subtotal { get { return _price; } set { _price = value; NotifyPropertyChanged(nameof(Subtotal)); } }

    public bool? EsteActiva { get; set; }
}
