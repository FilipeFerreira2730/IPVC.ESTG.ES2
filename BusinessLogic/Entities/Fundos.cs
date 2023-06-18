using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Fundos
{
    public Guid idfundo { get; set; }
    
    public string nome { get; set; } = null!;
    
    public double montante { get; set; }
    
    public double taxajuro { get; set; }
    
    public Guid idativofk { get; set; }
    
    public virtual Ativofinanceiros idativoNavigation { get; set; }
}

