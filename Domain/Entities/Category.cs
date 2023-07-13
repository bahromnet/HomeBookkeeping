using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Category
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }

    /// <summary>
    /// if ExpenceIncomeType = false type: Expence 
    /// else type:Income
    /// </summary>
    public bool ExpenceIncomeType { get; set; }

    public virtual IList<Bookkeeping>? Bookkeepings { get; set; } = new List<Bookkeeping>();


}
