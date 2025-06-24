using B3.Cdb.Calculator.Domain.Resource;

namespace B3.Cdb.Calculator.Domain.Entitie
{
    public class CdbInvestment
    {
        public decimal InitialValue { get; set; }
        public decimal GrossReturn { get; set; }
        public decimal NetReturn { get; set; }

        private CdbInvestment()
        { }

        public CdbInvestment(decimal initialValue)
        {
            if (initialValue <= Constants.MinimalInitialValue)
                throw new ArgumentException(Messages.InvalidInitialValue);

            InitialValue = initialValue;
        }

        public void Calculate(int months)
        {
            if (months <= Constants.MinimalPeriod)
                throw new ArgumentException(Messages.InvalidPeriod);

            GrossReturn = Math.Round(CalculateGrossReturn(months), 2);
            var taxRate = GetTaxRate(months);
            NetReturn = Math.Round(CalculateNetReturn(taxRate), 2);
        }

        private decimal CalculateGrossReturn(int months)
        {
            decimal accumulatedValue = InitialValue;
            for (int i = 0; i < months; i++)
                accumulatedValue *= (1 + (Constants.CDI * Constants.TB));

            return accumulatedValue;
        }

        private decimal CalculateNetReturn(decimal taxRate)
        {
            var profit = GrossReturn - InitialValue;
            return GrossReturn - (profit * taxRate);
        }

        public static decimal GetTaxRate(int months)
        {
            return months switch
            {
                <= 6 => 0.225m,
                <= 12 => 0.20m,
                <= 24 => 0.175m,
                _ => 0.15m
            };
        }
    }
}