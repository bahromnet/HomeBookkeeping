namespace Domain.Entities;
public class Category
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string ExpenceIncomeType { get; set; }

    public virtual IList<Bookkeeping>? Bookkeepings { get; set; } = new List<Bookkeeping>();


}
