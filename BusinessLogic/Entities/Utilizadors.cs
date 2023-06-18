using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Utilizadors
{
    public Guid IdUtilizador { get; set; }
    public string Nome { get; set; } = null!;
    
    public string nif { get; set; } = null!;
    
    public string ncc { get; set; } = null!;
    
    public string rua { get; set; } = null!;
    
    public int n_porta { get; set; }
    
    public string username { get; set; } = null!;
    
    public string pass { get; set; } = null!;
    
    public string codpostal { get; set; } = null!;
    
    public int tipoutilizador { get; set; }
    
    public virtual ICollection<Ativofinanceiros> Ativofinanceiros { get; set; } = new List<Ativofinanceiros>();
}

