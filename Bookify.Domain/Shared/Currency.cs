namespace Bookify.Domain.Shared;

public record Currency {
    internal static readonly Currency None = new("");
    public static readonly Currency EUR = new("EUR");
    public static readonly Currency USD = new("USD");
    
    public string Code { get; init; }
    
    private Currency(string code) {
        Code = code;
    }
    
    public static Currency FromCode(string code) {
        return All.FirstOrDefault(c => c.Code == code) 
               ?? throw new ApplicationException($"The currency code '{code}' is invalid.");
    }
    
    public static readonly IReadOnlyCollection<Currency> All = new[] {
        EUR,
        USD
    };
}