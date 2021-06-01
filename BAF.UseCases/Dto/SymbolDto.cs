

namespace BAF.UseCases.Dto
{
    /// <summary>
    /// Symbol consists of BaseCurrency and QuoteCurrency 
    /// Example: [BaseCurrency][QuoteCurrency] -> DODOUSDT
    /// </summary>
    public class SymbolDto
    {
        public string BaseCurrency { get; set; }
        public string QuoteCurrency { get; set; }

        /// <summary>
        /// Get symbol using BaseCurrency and QuoteCurrency
        /// </summary>
        public string GetSymbol() => BaseCurrency + QuoteCurrency;
    }
}
