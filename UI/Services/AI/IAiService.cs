namespace UI.Services.AI
{
    public interface IAiService
    {
        Task<string> GenerateAsync(string prompt);
    }
}
