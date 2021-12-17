global using DidarCodeChallenge.Api.Helpers;
namespace DidarCodeChallenge.Api.Services;
public class BinarySearchTreeService : IBinarySerachTreeService
{
    public void InsertNode(Node rootNode, int value)
    {
        if (rootNode == null)
        {
            rootNode = new(value);
        }
        else
        {
            if (value >= rootNode.Value)
            {
                if (!rootNode.HasRighHand())
                    rootNode.Right = new(value);
                else
                    InsertNode(rootNode.Right, value);
            }
            else if (value < rootNode.Value)
            {
                if (!rootNode.HasLeftHand())
                    rootNode.Left = new(value);
                else
                    InsertNode(rootNode.Left, value);
            }
        }
    }

    public Node BulkInsert(IEnumerable<int> values)
    {
        int[] numberArrary = values.ToArray();
        Node firstNode = new(numberArrary[0]);
        if (values.TryGetNonEnumeratedCount(out int count))
            for (var i = 1; i < count; i++)
                InsertNode(firstNode, numberArrary[i]);

        return firstNode;
    }

    private void HardDelete(Node target)
    {
        if (!target.HasAnyChild())
        {
            target = target.Right;
        }
        else
        {
                var replaceNode = target.Right;
                var replaceNodeParrent = target;
                while (replaceNode.HasLeftHand())
                {
                    replaceNodeParrent = replaceNode;
                    replaceNode = replaceNode.Left;
                }
                target.Value = replaceNode.Value;

                if (!replaceNode.HasAnyChild())
                {
                    replaceNodeParrent.Left = null;
                }
                else
                {
                    HardDelete(replaceNodeParrent.Right);
                }
        }
    }

    public List<int> DeleteNode(Node root, int value)
    {
        if (root.Value == value)
        {
            if (!root.HasAnyChild())
            {
                root = null;
                return new List<int>();
            }
            else
            {
                HardDelete(root);
            }
        }
        List<int> ls = new();

        if (root.HasLeftHand())
        {
            ls.AddRange(DeleteNode(root.Left, value));
        }
        ls.Add(root.Value);
        if (root.HasRighHand())
        {
            ls.AddRange(DeleteNode(root.Right, value));
        }
        return ls;
    }
}
