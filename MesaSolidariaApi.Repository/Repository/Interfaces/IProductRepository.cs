namespace MesaSolidariaApi.Repository.Repository.Interfaces;

public interface IProductRepository
{ 
    Task<int> GetSumOfRice();
    Task<int> GetSumOfBeans();
    Task<int> GetSumOfOil();
    Task<DateTime> GetLastUpdatedDateForRice();
    Task<DateTime> GetLastUpdatedDateForBeans();
    Task<DateTime> GetLastUpdatedDateForOil();
}