

using FireHire.Shared.Vacancies;

namespace FireHire.Server.Data
{
    public class SalaryDb
    {
        public SalaryDb(int id, int vacancyId, double lowBound, double highBound, CurrencyCodes currencyCode)
        {
            Id = id;
            VacancyId = vacancyId;
            LowBound = lowBound;
            HighBound = highBound;
            CurrencyCode = currencyCode;
        }

        public int Id { get; set; }
        public int VacancyId { get; set; }
        public double LowBound { get; set; }
        public double HighBound { get; set; }

        public CurrencyCodes CurrencyCode { get; set; }
    }
}
