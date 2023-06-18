using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Depositos
{
    public Guid iddeposito { get; set; }
    
    public string banco { get; set; } = null!;
    
    public string titulares { get; set; } = null!;
    
    public double valor { get; set; }
    
    public double taxajuro { get; set; }
    
    public string nconta { get; set; } = null!;
    
    public Guid idativofk { get; set; }
    
    public virtual Ativofinanceiros idativoNavigation { get; set; }
}
