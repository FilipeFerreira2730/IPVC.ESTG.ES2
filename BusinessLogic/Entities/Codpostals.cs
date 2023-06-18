using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Codpostals
{
    public string codpostal1 { get; set; } = null!;
    
    public string localidade { get; set; } = null!;
    public virtual ICollection<Imovels> Imovels { get; set; } = new List<Imovels>();
    public virtual ICollection<Utilizadors> Utilizadors { get; set; } = new List<Utilizadors>();
}
