namespace DotNetBank.Models
{
    /// <summary>
    /// Petar Ivanov, F116389 - DTO за създаване на нова банкова сметка с необходимите параметри.
    /// </summary>
    public class AccountCreationRequest
    {
        public string Iban { get; set; }
        public string OwnerName { get; set; }
        public string Currency { get; set; }
        public decimal InitialBalance { get; set; }
        public AccountKind Kind { get; set; }
    }

    /// <summary>
    /// Petar Ivanov, F116389 - Видове банкови сметки, които приложението поддържа.
    /// </summary>
    public enum AccountKind
    {
        Checking,
        Savings,
        Student
    }
}