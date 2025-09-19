using Invoicer_API.Entity;
using Invoicer_API.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoicer_API.Models
{
    public class Invoice : BaseEntity
    {
        public Guid CustomerId { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }

        [NotMapped]
        public decimal TotalSum => Rows?.Sum(r => r.Sum) ?? 0;

        public List<InvoiceRow> Rows { get; set; } = new();

        public string? Comment { get; set; }

        public InvoiceStatus Status { get; set; }
    }
}
