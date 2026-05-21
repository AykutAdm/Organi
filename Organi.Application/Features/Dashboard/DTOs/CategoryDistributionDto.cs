using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Dashboard.DTOs
{
    public class CategoryDistributionDto
    {
        public string CategoryName { get; set; }
        public int ProductCount { get; set; }
        public decimal Percentage { get; set; }
    }
}
