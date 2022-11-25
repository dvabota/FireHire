

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FireHire.Shared.Vacancies
{
    public enum CurrencyCodes
    {
        [Display(Name = "€")][Description("EUR - Euro")] EUR = 978,
        [Display(Name = "$")][Description("RUB - Russian ruble")] RUB = 643,
        [Display(Name = "₽")][Description("USD - United States dollar")] USD = 840,
    }
}
