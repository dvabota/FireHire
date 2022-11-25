

namespace FireHire.Shared.Vacancies
{
    public class Salary
    {
        public Salary(double lowBound, double highBound, CurrencyCodes currencyCode)
        {
            LowBound = lowBound;
            HighBound = highBound;
            CurrencyCode = currencyCode;
        }

        public double LowBound { get; set; }
        public double HighBound { get; set; }

        public CurrencyCodes CurrencyCode { get; set; }
    }
}
