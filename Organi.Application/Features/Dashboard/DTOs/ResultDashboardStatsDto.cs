using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Features.Dashboard.DTOs
{
    public class ResultDashboardStatsDto
    {
        public int TotalProducts { get; set; }
        public int TotalCategories { get; set; }
        public int BasketItems { get; set; }
        public int LowStockItems { get; set; }
    }
}
