namespace TestingBasic;

public record User(string FirstName, string LastName)
{
    public int Id { get; init; }
    public DateTime CreatedDate { get; init; } = DateTime.UtcNow;
    public string Phone { get; set; } = "+998 ";
    public bool VerifiedEmail { get; set; } = false;
}