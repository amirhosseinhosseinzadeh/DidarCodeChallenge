namespace DidarCodeChallenge.Api.Models;

#nullable enable
public class Node
{
    public Node? Right { get; set; }

    public Node? Left { get; set; }

    public int Value { get; set; }

    public Node(int node)
    {
        Value = node;
        Left = Right = null;
    }
}
