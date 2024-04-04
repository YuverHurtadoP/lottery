﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lottery.Application.DTOS
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
