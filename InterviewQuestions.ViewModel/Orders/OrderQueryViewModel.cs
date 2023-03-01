using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.ViewModel.Orders
{
    public class OrderQueryViewModel
    {
        public string? code { get; set; }
        public string? BuyerName { get; set; }

        public string? PurchaseOrderNumber { get; set; }

        public string? BillingZipCode { get; set; }

        public decimal? OrderAmount { get; set; }
    }
}
