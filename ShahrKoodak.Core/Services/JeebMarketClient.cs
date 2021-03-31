using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Jeeb.Client.Dtos;
using RestSharp;
using ShahrKoodak.Core.common;
using ShahrKoodak.Core.Services.Interfaces;

namespace ShahrKoodak.Core.Services
{
    public class JeebMarketClient : BaseClient, IJeebMarketClient
    {
        const string BaseUrl = "https://core.jeeb.io/api/v3/markets/";

        const string CurrenciesUrl = "currencies";
        const string RatesUrl = "rates";

        public JeebMarketClient()
            : base(BaseUrl)
        {
        }

        public async Task<List<CurrencyDto>> ListCurrenciesAsync()
        {
            var httpRequest = BuildRequest(CurrenciesUrl, Method.GET);
            var response = await ExecuteRequestAsync<Response<List<CurrencyDto>>>(httpRequest);
            return response.Result;
        }

        public List<CurrencyDto> ListCurrencies()
        {
            return ListCurrenciesAsync().GetAwaiter().GetResult();
        }

        public async Task<List<RateDto>> ListRatesAsync(string filter = null)
        {
            var httpRequest = BuildRequest(RatesUrl, Method.GET);
            if (!string.IsNullOrEmpty(filter))
                httpRequest.AddQueryParameter("filter", filter);
            var response = await ExecuteRequestAsync<Response<List<RateDto>>>(httpRequest);
            return response.Result;
        }

        public List<RateDto> ListRates(string filter = null)
        {
            return ListRatesAsync(filter).GetAwaiter().GetResult();
        }
    }
}
