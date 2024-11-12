﻿namespace Bookstore.Infrastructure.Authentication;

public class JwtSettings
{
    public required string SecretKey { get; set; }
    public int AccessTokenExpirationMinutes { get; set; }
    public int RefreshTokenExpirationDays { get; set; }
    public required string Issuer { get; set; }
    public required string Audience { get; set; }

}
