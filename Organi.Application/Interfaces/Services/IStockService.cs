using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Application.Interfaces.Services
{
    public interface IStockService
    {
        Task DecreaseStockAsync(int productId, int amount);
        Task IncreaseStockAsync(int productId, int amount);
        Task ClearStockAsync(int productId);
    }
}
