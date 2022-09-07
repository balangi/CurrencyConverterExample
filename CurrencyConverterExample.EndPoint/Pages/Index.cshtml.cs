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
            // "USD", "CAD", 1.34
            // "CAD", "GBP", 0.58
            // "USD", "EUR", 0.86

            _currencyConverter.ClearConfiguration();

            List<Tuple<string, string, double>> conversionRates = new List<Tuple<string, string, double>>();
            conversionRates.Add(new Tuple<string, string, double>("USD", "CAD", 1.34));
            conversionRates.Add(new Tuple<string, string, double>("CAD", "GBP", 0.58));
            conversionRates.Add(new Tuple<string, string, double>("USD", "EUR", 0.86));

            _currencyConverter.UpdateConfiguration(conversionRates);

            ViewData["Price1"] = _currencyConverter.Convert("USD", "EUR", 1).ToString("0.##");
            ViewData["Price2"] = _currencyConverter.Convert("CAD", "EUR", 1).ToString("0.##");
        }
    }
}