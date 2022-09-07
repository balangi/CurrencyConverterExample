using CurrencyConverterExample;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CurrencyConverterExample.EndPoint.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICurrencyConverter _currencyConverter;
        public IndexModel(
            ILogger<IndexModel> logger,
            ICurrencyConverter currencyConverter)
        {
            _logger = logger;
            _currencyConverter = currencyConverter;
        }

        public void OnGet()
        {
            var conversionRates = new List<Tuple<string, string, double>>();
            conversionRates.Add(new Tuple<string, string, double>("USD", "CAD", 1.34));
            conversionRates.Add(new Tuple<string, string, double>("CAD", "GBP", 0.58));
            conversionRates.Add(new Tuple<string, string, double>("USD", "EUR", 0.86));

            _currencyConverter.UpdateConfiguration(conversionRates);

        }
    }
}