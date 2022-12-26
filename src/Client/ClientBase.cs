using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NoCond.Client
{
    internal abstract class ClientBase
    {
        public Func<Task<string>> RetrieveAuthorizationToken { get; set; }

        /// <summary>
        /// Creates the HTTP request message asynchronous.
        /// </summary>
        /// <remarks>
        /// Called by implementing swagger client classes
        /// </remarks>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        protected async Task<HttpRequestMessage> CreateHttpRequestMessageAsync(CancellationToken cancellationToken)
        {
            var msg = new HttpRequestMessage();

            if (RetrieveAuthorizationToken != null)
            {
                var token = await RetrieveAuthorizationToken();
                msg.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
            return msg;
        }
    }
}