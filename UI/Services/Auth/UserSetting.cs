using UI.Models.Auth;

namespace UI.Services.Auth
{
    public class UserSetting : IUserSetting
    {
        private readonly HttpClient _httpClient;
        public UserSetting(IHttpClientFactory httpClientFactory)
        {
           
            _httpClient = httpClientFactory.CreateClient("BackendApi");
        }
        public async Task<UserViewDto> GetCurrentUserAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/Users/profile/{id}");
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Get current user failed: {error}");
            }
            var user = await response.Content.ReadFromJsonAsync<UserViewDto>();
            return user;
        }

        public async Task UpdateAsync( UserUpdateDto userUpdateDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/UserProfile/update-profile", userUpdateDto);

           
            if (!response.IsSuccessStatusCode)
            {
                
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Güncelleme başarısız: {errorMessage}");
            }
        }
    }
}
