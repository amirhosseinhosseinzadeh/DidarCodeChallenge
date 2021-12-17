using DidarCodeChallenge.Api.Domains;
using DidarCodeChallenge.Api.Repository;

namespace DidarCodeChallenge.Api.Services;

public class RequestService : IRequestService
{
    private readonly IGenericRepository<Request> _requestRepository;
    public RequestService(IGenericRepository<Request> requestRepository)
    {
        _requestRepository = requestRepository;
    }

    public async Task InsertAsync(Request request)
    {
        if(request == null)
            throw new ArgumentNullException(nameof(request));
        
        await _requestRepository.InsertAsync(request);
    }
}