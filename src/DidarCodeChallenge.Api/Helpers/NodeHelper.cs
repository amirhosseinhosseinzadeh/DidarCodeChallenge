namespace DidarCodeChallenge.Api.Helpers;
public static class NodeHelper
{
    public static bool HasLeftHand(this Node node)
        => node.Left != null;

    public static bool HasRighHand(this Node node)
        => node.Right != null;

    public static bool HasAnyChild(this Node node)
        => node.Right != null || node.Left != null;

    public static string ConvertToString(this IList<int> lst)
    {
        string result = "";
        lst.TryGetNonEnumeratedCount(out int count);
        for (var i = 1; i <= count; i++)
        {
            result = result + lst[i - 1].ToString();
            if (i < count)
                result = result + ",";
        }
        return result;
    }

    public static void Delete(this Node node)
    {
        node = null;
    }
}
