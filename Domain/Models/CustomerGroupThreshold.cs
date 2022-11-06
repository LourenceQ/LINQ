using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class CustomerGroupThreshold
    {
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public decimal? TotalOrderAmount { get; set; }
        public string CustomerGroupName { get; set; }
    }
}
