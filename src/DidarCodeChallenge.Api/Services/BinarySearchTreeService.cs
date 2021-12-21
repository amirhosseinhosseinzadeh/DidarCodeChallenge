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
                if (!rootNode.HasRightHand())
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
        if (target.HasRightHand())
        {

            var replaceNode = target.Right;
            var replaceNodeParrent = target;
            while (replaceNode.HasLeftHand())
            {
                replaceNodeParrent = replaceNode;
                replaceNode = replaceNode.Left;
            }
            if (!replaceNode.HasAnyChild())
            {
                var targetValue = target.Value;
                target.Value = replaceNode.Value;
                replaceNode.Value = targetValue;
            }
            else
            {
                HardDelete(replaceNodeParrent.Right);
            }

        }
        else
        {
            var replaceNode = target.Left;
            var replaceNodeParrent = target;
            while (replaceNode.HasRightHand())
            {
                replaceNodeParrent = replaceNode;
                replaceNode = replaceNode.Right;
            }
            if (!replaceNode.HasAnyChild())
            {
                var targetValue = target.Value;
                target.Value = replaceNode.Value;
                replaceNode.Value = targetValue;
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
            var leftHandResult = DeleteNode(root.Left, value);
            if (leftHandResult.TryGetNonEnumeratedCount(out int count) && count == 0)
                root.Left = null;
            else
                ls.AddRange(leftHandResult);
        }
        ls.Add(root.Value);
        if (root.HasRightHand())
        {
            var rightHandResult = DeleteNode(root.Right, value);
            if (rightHandResult.TryGetNonEnumeratedCount(out int count) && count == 0)
                root.Right = null;
            else
                ls.AddRange(rightHandResult);
        }
        return ls;
    }
}
