using HotelBediaX.Application.Interfaces;

namespace HotelBediaX.Application.UseCases.DestinationUseCases
{
    public class DeleteUseCase(IDestinationRepository repository)
    {
        private readonly IDestinationRepository _repository = repository;

        public async Task<bool> ExecuteAsync(int id)
        {
            var destination = await _repository.GetByIdAsync(id);
            if (destination is null)
                return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
