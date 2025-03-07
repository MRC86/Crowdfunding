﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Share.Utility.Http
{
    public interface IHttpRequest
    {
        public Task<string> GetAsync(string url);
        public Task<TResult> GetAsync<TResult>(string url, Dictionary<string, string>? urlParam = null);
        public Task<string> PostAsync(string url, object input);
        public Task<TResult> PostAsync<TResult>(string url, object input, Dictionary<string, string>? urlParam = null);
        public Task<TResult> PostAsync<TResult>(string url, MultipartFormDataContent input, Dictionary<string, string>? urlParam = null);
        public Task<string> PutAsync(string url, object input);
        public Task<TResult> PutAsync<TResult>(string url, object input, Dictionary<string, string>? urlParam = null);
        public Task<string> DeleteAsync(string url);
        public String BaseUrl { set; }
        public String Token { set; get; }
    }
}
