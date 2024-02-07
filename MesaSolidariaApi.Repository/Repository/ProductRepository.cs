using MesaSolidariaApi.Repository.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MesaSolidariaApi.Repository.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> GetSumOfRice()
    {
        return await _context.Products
            .SumAsync(p => p.Rice);
    }
    
    public async Task<int> GetSumOfBeans()
    {
        return await _context.Products
            .SumAsync(p => p.Bean);
    }
    
    public async Task<int> GetSumOfOil()
    {
        return await _context.Products
            .SumAsync(p => p.Oil);
    }
    
    public async Task<DateTime> GetLastUpdatedDateForRice()
    {
        var product = await _context.Products
            .Where(p => p.Rice > 0)
            .OrderByDescending(p => p.LastUpdate)
            .FirstOrDefaultAsync();

        return product?.LastUpdate ?? default;
    }
    
    public async Task<DateTime> GetLastUpdatedDateForBeans()
    {
        var product = await _context.Products
            .Where(p => p.Bean > 0)
            .OrderByDescending(p => p.LastUpdate)
            .FirstOrDefaultAsync();

        return product?.LastUpdate ?? default;
    }
    
    public async Task<DateTime> GetLastUpdatedDateForOil()
    {
        var product = await _context.Products
            .Where(p => p.Oil > 0)
            .OrderByDescending(p => p.LastUpdate)
            .FirstOrDefaultAsync();

        return product?.LastUpdate ?? default;
    }
}