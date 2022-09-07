#nullable disable

namespace CurrencyConverterExample;

public class CurrencyConverter : ICurrencyConverter
{
    private IEnumerable<Tuple<string, string, double>>? _conversionRates;

    public void ClearConfiguration()
    {
        _conversionRates = null;
    }

    public double Convert(string fromCurrency, string toCurrency, double amount)
    {
        double total = 0;
        if (_conversionRates != null)
        {
            var result = _conversionRates.Where(w => w.Item1 == fromCurrency && w.Item2 == toCurrency);
            // direct route
            if (result.Any())
            { 
                if(result.FirstOrDefault() != null && result.FirstOrDefault().Item3 != 0)
                total = amount * result.FirstOrDefault().Item3;
            }
            else
            {
                // check indirect route
                result = _conversionRates.Where(w => w.Item2 == fromCurrency);
                if (result.Any())
                {
                    var rate1 = 0.0;
                    var currency1 = string.Empty;
                    var currency2 = string.Empty;
                    if (result.FirstOrDefault() != null && result.FirstOrDefault().Item3 != 0)
                    {
                        rate1 = amount / result.FirstOrDefault().Item3;
                        currency1 = result.FirstOrDefault().Item1;
                    }

                    var result2 = _conversionRates.Where(w => w.Item2 == toCurrency);
                    if (result2.Any())
                    {
                        if (result2.FirstOrDefault() != null && result2.FirstOrDefault().Item3 != 0)
                        {
                            total = rate1 * result2.FirstOrDefault().Item3;
                            currency2 = result2.FirstOrDefault().Item1;
                        }
                    }

                    if(currency1 == currency2)
                    {
                        return total;
                    }
                    else
                    {
                        throw new Exception("No route found.");
                    }
                }
            }
        }

        return total;
    }

    public void UpdateConfiguration(IEnumerable<Tuple<string, string, double>> conversionRates)
    {
        if (conversionRates != null)
        {
            _conversionRates = conversionRates;
        }
    }
}