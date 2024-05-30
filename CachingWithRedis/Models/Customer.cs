namespace CachingWithRedis.Models;

public sealed class Customer
{
    public required int Id { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required DateOnly DateOfBirth { get; set; }
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
}
