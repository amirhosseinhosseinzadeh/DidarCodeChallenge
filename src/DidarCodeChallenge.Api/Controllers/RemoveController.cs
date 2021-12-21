using DidarCodeChallenge.Api.Domains;
using Microsoft.AspNetCore.Mvc;
namespace DidarCodeChallenge.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RemoveController : ControllerBase
{
    private readonly IBinarySerachTreeService _bstService;
    private readonly IRequestService _requestService;

    public RemoveController(IBinarySerachTreeService bstService,
                            IRequestService requestService
        )
    {
        _bstService = bstService;
        _requestService = requestService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string nodes, int value)
    {
        var nodeList = GetNumberList(nodes);
        var rootNode = _bstService.BulkInsert(nodeList);
        var ascendingList = _bstService.DeleteNode(rootNode, value);
        string result = ascendingList.ConvertToString();
        await _requestService.InsertAsync(new Request()
        {
            Response = result,
            Value = value,
            UserRequest = nodes
        });
        return Ok(new { result = result });
    }

    [NonAction]
    public IList<int> GetNumberList(string nodes)
    {
        var nodeMembers = nodes.Split(',');
        List<int> nodeList = new();
        nodeMembers.ToList().ForEach(nodeStr =>
        {
            if (int.TryParse(nodeStr, out int node))
                nodeList.Add(node);
        });
        return nodeList;
    }
}
