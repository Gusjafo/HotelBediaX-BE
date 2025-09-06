using HotelBediaX.Application.Interfaces;

namespace HotelBediaX.Application.UseCases.DestinationUseCases
{
    public class DeleteUseCase(IDestinationRepository repository)
    {
        private readonly IDestinationRepository _repository = repository;

        public async Task ExecuteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
