using System;

namespace WarehouseOperative.Models.EntitiesForView
{
    public class InvoicesForAllView
    {
        public int InvoiceId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public string InvoiceNumber { get; set; }
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
