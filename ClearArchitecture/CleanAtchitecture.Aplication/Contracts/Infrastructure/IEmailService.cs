

using CleanArchitecture.Application.Contracts.Models;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
