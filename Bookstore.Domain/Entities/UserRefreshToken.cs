﻿namespace Bookstore.Domain.Entities;

public class UserRefreshToken
{
    public required string Token { get; set; }
    public DateTime Expires { get; set; }
    public bool IsRevoked { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
}
