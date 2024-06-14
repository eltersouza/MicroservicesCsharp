using Core.FinanceService.Application.Enums;
using Core.FinanceService.Application.Strategy.Concretes;
using Core.FinanceService.Application.Strategy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.FinanceService.Application.Strategy
{
    public class CostStrategyBuilder
    {
        private ICostStrategy Strategy { get; set; }

        public CostStrategyBuilder(StrategyEnum strategy)
        {
            this.SetStrategy(strategy);
        }

        private void SetStrategy(StrategyEnum strategy)
        {
            switch (strategy)
            {
                case StrategyEnum.Real:
                    this.Strategy = new RealCostStrategy();
                    break;
                case StrategyEnum.Dolar:
                    this.Strategy = new DolarCostStrategy();
                    break;
            }
        }

        public string Execute()
        {
            if (Strategy == null)
                return null;
            
            return Strategy.Execute();
        }
    }
}
