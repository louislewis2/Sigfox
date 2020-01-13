﻿namespace Sigfox
{
    using System;
    using System.Net;
    using System.Web;
    using System.Text;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Net.Http.Headers;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    using Sigfox.Exceptions;

    public class SigfoxIntegrationClient
    {
        #region Fields

        private const string baseUrl = "https://api.sigfox.com/v2/";
        private const string productInfo = "SigfoxIntegrationClient";

        private readonly string login;
        private readonly string password;
        private readonly HttpClient httpClient;

        #endregion Fields

        #region Constructor

        public SigfoxIntegrationClient(string login, string password)
        {
            this.login = login;
            this.password = password;

            this.httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        #endregion Constructor

        #region Methods

        public async Task<T> PostAsync<T>(string resourceUrl, object data) where T : class
        {
            if (string.IsNullOrWhiteSpace(resourceUrl))
            {
                throw new ArgumentException("Resource Url Cannot Be Emtpty");
            }

            if (data == null)
            {
                throw new ArgumentException("Data Cannot Be Null");
            }

            var content = new StringContent(SerializeToJson(data), Encoding.UTF8, "application/json");

            this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{this.login}:{this.password}")));
            this.httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(productName: productInfo, productVersion: "0.0.1"));
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var httpResponseMessage = await this.httpClient.PostAsync(resourceUrl, content);

            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                return httpResponseMessage.Deserialize<T>();
            }

            throw new IntegrationException(httpResponseMessage: httpResponseMessage, httpResponseMessage.ReasonPhrase);
        }

        public async Task<T> GetAsync<T>(string resourceUrl, string queryString) where T : class
        {
            if (string.IsNullOrWhiteSpace(resourceUrl))
            {
                throw new ArgumentException("Resource Url Cannot Be Emtpty");
            }

            var finalResourceUrl = string.IsNullOrWhiteSpace(queryString) ? resourceUrl : $"{resourceUrl}?{HttpUtility.ParseQueryString(query: queryString).ToString()}";

            this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{this.login}:{this.password}")));

            this.httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(productName: productInfo, productVersion: "0.0.1"));

            var httpResponseMessage = await this.httpClient.GetAsync(finalResourceUrl);

            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                return httpResponseMessage.Deserialize<T>();
            }

            throw new IntegrationException(httpResponseMessage: httpResponseMessage, httpResponseMessage.ReasonPhrase);
        }

        #endregion Methods

        #region Private Methods

        private static string SerializeToJson<T>(T obj)
        {
            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), NullValueHandling = NullValueHandling.Ignore };

            return JsonConvert.SerializeObject(obj, settings);
        }

        #endregion Private Methods
    }
}