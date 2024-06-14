using Core.FinanceService.Application.Strategy.Interfaces;

namespace Core.FinanceService.Application.Strategy.Concretes
{
    public class RealCostStrategy : ICostStrategy
    {
        public string Execute()
        {
            return "R$125,00 BRL";
        }
    }
}
