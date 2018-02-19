﻿using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Livecoin.Models.Private;

namespace Livecoin
{
    public partial class LivecoinClient
    {
        /// <summary>
        /// Открыть ордер (лимитный) на покупку, определенной валюты.
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>        
        public async Task<ExchangeResponse<OrderResponse>> BuyLimit(string symbol, decimal price,
            decimal quantity)
        {
            return await QueryPrivatePost<OrderResponse>("exchange/buylimit",
                new Dictionary<string, string>
                {
                    {"currencyPair", symbol},
                    {"price", price.ToString(CultureInfo.InvariantCulture)},
                    {"quantity", quantity.ToString(CultureInfo.InvariantCulture)}
                });
        }        

        /// <summary>
        /// Открыть ордер (лимитный) на продажу определенной валюты. Доп.параметры аналогично покупки.
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public async Task<ExchangeResponse<OrderResponse>> SellLimit(string symbol, decimal price, decimal quantity)
        {
            return await QueryPrivatePost<OrderResponse>("exchange/selllimit",
                new Dictionary<string, string>
                {
                    {"currencyPair", symbol},
                    {"price", price.ToString(CultureInfo.InvariantCulture)},
                    {"quantity", quantity.ToString(CultureInfo.InvariantCulture)}
                });
        }
        
        /// <summary>
        /// Открыть ордер(рыночный) на покупку определенной валюты на заданное количество.
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="quantity"> Количество</param>
        /// <returns></returns>        
        public async Task<ExchangeResponse<OrderResponse>> BuyMarket(string symbol, decimal quantity)
        {
            return await QueryPrivatePost<OrderResponse>("exchange/buymarket",
                new Dictionary<string, string>
                {
                    {"currencyPair", symbol},                    
                    {"quantity", quantity.ToString(CultureInfo.InvariantCulture)}
                });
        }

        /// <summary>
        /// Открыть ордер(рыночный) на продажу определенной валюты на заданное количество.
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>        
        public async Task<ExchangeResponse<OrderResponse>> SellMarket(string symbol, decimal quantity)
        {
            return await QueryPrivatePost<OrderResponse>("exchange/sellmarket",
                new Dictionary<string, string>
                {
                    {"currencyPair", symbol},                    
                    {"quantity", quantity.ToString(CultureInfo.InvariantCulture)}
                });
        }

        /// <summary>
        /// Отменить ордер (лимитный).
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="orderID"></param>
        /// <returns></returns>        
        public async Task<ExchangeResponse<CancelLimit>> CancelLimit(string symbol, long orderID)
        {
            return await QueryPrivatePost<CancelLimit>("exchange/cancellimit",
                new Dictionary<string, string>
                {
                    {"currencyPair", symbol},                    
                    {"orderId", orderID.ToString()}
                });
        }
    }
}