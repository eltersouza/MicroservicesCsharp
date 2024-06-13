using Aplication.DTOs;

namespace Aplication.Interfaces.Messaging
{
    public interface IEnrollmentDataPublisher
    {
        Task<bool> PublishAsync(Enrollment enrollment);
    }
}
