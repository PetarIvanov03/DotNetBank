namespace DotNetBank.Models
{
    /// <summary>
    /// DTO за създаване на нова банкова сметка.
    /// </summary>
    public class AccountCreationRequest
    {
        public string Iban { get; set; }
        public string OwnerName { get; set; }
        public string Currency { get; set; }
        public decimal InitialBalance { get; set; }
        public AccountKind Kind { get; set; }
    }

    public enum AccountKind
    {
        Checking,
        Savings,
        Student
    }
}
