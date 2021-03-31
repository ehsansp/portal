using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Jeeb.Client.Dtos;

namespace ShahrKoodak.Core.Services.Interfaces
{
    public interface IJeebMarketClient
    {
        Task<List<CurrencyDto>> ListCurrenciesAsync();

        List<CurrencyDto> ListCurrencies();

        Task<List<RateDto>> ListRatesAsync(string filter = null);

        List<RateDto> ListRates(string filter = null);
    }
}
