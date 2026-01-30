namespace FinanceAI.Application.Interfaces
{
    public interface ICurrentUserService
    {
        // Token içindeki NameIdentifier claim'ini okuyup ID döner
        int UserId { get; }
    }
}
