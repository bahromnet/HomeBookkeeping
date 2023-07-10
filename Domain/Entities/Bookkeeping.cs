using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Bookkeeping
{
    public Guid BookkeepingId { get; set; }
    public decimal Amount { get; set; }
    public string Comment { get; set; }

    public Guid CategoryId { get; set; } 
    public virtual Category? Category { get; set; }

    public DateTime Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

}



