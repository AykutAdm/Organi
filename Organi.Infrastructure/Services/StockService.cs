using Microsoft.Extensions.Logging;
using Organi.Application.Interfaces.Services;
using Organi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organi.Infrastructure.Services
{
    public class StockService : IStockService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StockService> _logger;

        public StockService(IUnitOfWork unitOfWork, ILogger<StockService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task ClearStockAsync(int productId)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(productId);
            if (product == null)
                return;

            product.Stock = 0;
            await _unitOfWork.Products.UpdateAsync(product);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Stok sıfırlandı: {Name}", product.Name);
        }

        public async Task DecreaseStockAsync(int productId, int amount)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(productId);

            product.Stock -= amount;
            await _unitOfWork.Products.UpdateAsync(product);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Stok azaltıldı: {Name}, Kalan: {Stock}", product.Name, product.Stock);
        }

        public async Task IncreaseStockAsync(int productId, int amount)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(productId);

            product.Stock += amount;
            await _unitOfWork.Products.UpdateAsync(product);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Stok artırıldı: {Name}, Yeni Stok: {Stock}", product.Name, product.Stock);
        }

        public async Task InitializeStockAsync(int productId, int initialStock)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(productId);
            if (product == null)
            {
                _logger.LogWarning("Ürün bulunamadı: ProductId {ProductId}", productId);
                return;
            }

            // Stok takibi için log at ve gerekirse uyarı ver
            if (initialStock < 10)
            {
                _logger.LogWarning("Düşük stok ile ürün eklendi: {Name}, Stok: {Stock}", product.Name, initialStock);
            }
            else
            {
                _logger.LogInformation("Ürün stok sistemi başlatıldı: {Name}, Başlangıç Stok: {Stock}", product.Name, initialStock);
            }
        }
    }
}
