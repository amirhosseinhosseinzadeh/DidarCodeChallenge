global using DidarCodeChallenge.Api.Models;

namespace DidarCodeChallenge.Api.Services;
public interface IBinarySerachTreeService
{
    void InsertNode(Node rootNode, int value);
    
    List<int> DeleteNode(Node root,int value);

    Node BulkInsert(IEnumerable<int> values);
}
