using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace UI.DelegatingHandlers
{
    public class JwtHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var context = _httpContextAccessor.HttpContext;
            var token = context?.Session.GetString("JWT");

            if (!string.IsNullOrEmpty(token))
            {
                // ÖNEMLİ: Eğer token'ın başında zaten "Bearer " varsa bunu temizle veya 
                // direkt ekle. Genelde sadece saf token saklanır.
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
