namespace Application.Common.Models
{
    public class BookkeepingGetDto
    {

        public Guid BookkeepingId { get; set; }
        public decimal Amount { get; set; }
        public string Comment { get; set; }

        public  CategoryGetDto? Category { get; set; }

        public DateTime Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string? LastModifiedBy { get; set; }
    }
}
