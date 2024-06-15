﻿using Bookify.Application.Abstractions.Email;

namespace Bookify.Infrastructure.Email;

internal sealed class EmailService : IEmailService {
    public Task SendAsync(Domain.Users.Email recipient, string subject, string body) {
        // Just for demonstration purposes
        return Task.CompletedTask;
    }
}