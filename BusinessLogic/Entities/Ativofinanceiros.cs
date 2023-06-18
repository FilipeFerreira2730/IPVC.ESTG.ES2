using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Ativofinanceiros
{
    public Guid idativo { get; set; }
    
    public DateTime datainicio { get; set; }
    
    public int duracao { get; set; }
    
    public double taxaimposto { get; set; }
    
    public Guid idcliente { get; set; }
    
    public virtual Utilizadors idclienteNavigation { get; set; }
    
    public virtual ICollection<Depositos> Depositos { get; set; } = new List<Depositos>();
    
    public virtual ICollection<Fundos> Fundos { get; set; } = new List<Fundos>();
    
    public virtual ICollection<Imovels> Imovels { get; set; } = new List<Imovels>();
}
