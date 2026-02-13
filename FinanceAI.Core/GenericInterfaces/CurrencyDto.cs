namespace FinanceAI.Core.GenericInterfaces
{
    public class CurrencyDto
    {
        public string Symbol { get; set; }   // USD, EUR, ALTIN gibi
        public decimal Price { get; set; }    // 31.50 gibi
        public string Change { get; set; }   // +%0.5 gibi bir değişim oranı
    }
}
