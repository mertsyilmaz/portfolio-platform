using CV.Application.Abstractions.Persistence;
using CV.Application.Common.Exceptions;

namespace CV.Application.Hobbies
{
    public class DeleteHobbyService : IDeleteHobbyService
    {
        private readonly IHobbyRepository _hobbyRepository;

        public DeleteHobbyService(IHobbyRepository hobbyRepository)
        {
            _hobbyRepository = hobbyRepository;
        }

        public async Task DeleteAsync(Guid id)
        {
            var hobby = await _hobbyRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(hobby, ErrorMessages.HobbyNotFound);
            await _hobbyRepository.DeleteAsync(hobby);
        }
    }
}
