using Core.FinanceService.Application.Strategy.Interfaces;

namespace Core.FinanceService.Application.Strategy.Concretes
{
    public class DolarCostStrategy : ICostStrategy
    {
        public string Execute()
        {
            return "$32.00 USD";
        }
    }
}
