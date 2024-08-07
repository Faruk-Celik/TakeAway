﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeAway.Application.Features.CQRS.Results.OrderDetailResults
{
    public class GetByIdOrderDetailQueryResult
    {
        public int OrderDetailId { get; set; }
        public string ProdutcId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderingId { get; set; }
    }
}
