using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TripLog.Models;

namespace TripLog.Services
{
    public class TripLogApiDataService : BaseHttpService, ITripLogDataService
    {
        readonly Uri _baseUri;
        readonly IDictionary<string, string> _headers;
        public TripLogApiDataService(Uri baseUri)
        {
            _baseUri = baseUri;
            _headers = new Dictionary<string, string>();
        }
        public async Task<IList<TripLogEntry>> GetEntriesAsync()
        {
            var url = new Uri(_baseUri, "/api/TripLogEntry");
            var response = await SendRequestAsync<TripLogEntry[]>(url,
                HttpMethod.Get, _headers);

            return response;
        }

        public async Task<TripLogEntry> GetEntryAsync(string id)
        {
            var url = new Uri(_baseUri,
                string.Format("/api/TripLogEntry/{0}", id));
            var response = await SendRequestAsync<TripLogEntry>(url,
                HttpMethod.Get, _headers);

            return response;
        }

        public async Task<TripLogEntry> AddEntryAsync(TripLogEntry entry)
        {
            var url = new Uri(_baseUri, "/api/TripLogEntry");
            var response = await SendRequestAsync<TripLogEntry>(url,
                HttpMethod.Post, _headers, entry);

            return response;
        }

        public async Task<TripLogEntry> UpdateEntryAsync(TripLogEntry entry)
        {
            var url = new Uri(_baseUri,
                string.Format("/api/TripLogEntry/{0}", entry.Id));
            var response = await SendRequestAsync<TripLogEntry>(url,
                new HttpMethod("PATCH"), _headers, entry);

            return response;
        }

        public async Task RemoveEntryAsync(TripLogEntry entry)
        {
            var url = new Uri(_baseUri,
                string.Format("/api/TripLogEntry/{0}", entry.Id));
            var response = await SendRequestAsync<TripLogEntry>(url,
                HttpMethod.Delete, _headers);
        }
    }
}
