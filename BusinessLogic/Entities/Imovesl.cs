using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Imovels
{
    public Guid idimovel { get; set; }
    
    public string nome { get; set; } = null!;
    
    public double valorrenda { get; set; }
    
    public double valorcondo { get; set; }
    
    public double valoresti { get; set; }
    
    public string rua { get; set; } = null!;
    
    public string nporta { get; set; } = null!;
    
    public string? codpostal { get; set; }

    
    public Guid idativofk { get; set; }

    public virtual Ativofinanceiros idativoNavigation { get; set; }
}

