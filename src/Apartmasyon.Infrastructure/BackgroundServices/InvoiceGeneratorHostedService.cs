using Apartmasyon.Application.Common.Interfaces;
using Apartmasyon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Apartmasyon.Infrastructure.BackgroundServices;

public class InvoiceGeneratorHostedService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<InvoiceGeneratorHostedService> _logger;

    private readonly TimeSpan _period = TimeSpan.FromMinutes(1);

    public InvoiceGeneratorHostedService(IServiceProvider serviceProvider, ILogger<InvoiceGeneratorHostedService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Otomatik Aidat Oluşturma Servisi başlatıldı.");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                _logger.LogInformation("Sistem kontrol ediliyor: Yeni ay aidatları basılıyor...");

                using (var scope = _serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<IApartmentDbContext>();

                    var activeApartments = await context.Apartments
                        .Where(a => a.IsActive && a.IsOccupied)
                        .ToListAsync(stoppingToken);

                    var currentMonthName = DateTime.Now.ToString("MMMM yyyy");

                    foreach (var apartment in activeApartments)
                    {
                        string description = $"{currentMonthName} Dönemi Standart Aidat Bedeli";

                        bool isAlreadyInvoiced = await context.Invoices
                            .AnyAsync(i => i.ApartmentId == apartment.Id && i.Description == description, stoppingToken);

                        if (!isAlreadyInvoiced)
                        {
                            var invoice = new Invoice
                            {
                                ApartmentId = apartment.Id,
                                Description = description,
                                Amount = 450.00m,
                                DueDate = DateTime.UtcNow.AddDays(15),
                                IsPaid = false
                            };

                            context.Invoices.Add(invoice);
                            _logger.LogInformation($"Daire No {apartment.Number} için {invoice.Amount} TL aidat oluşturuldu.");
                        }
                    }

                    await context.SaveChangesAsync(stoppingToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Aidat oluşturulurken bir hata meydana geldi.");
            }

            await Task.Delay(_period, stoppingToken);
        }
    }
}