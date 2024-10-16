
public static class StringsTransformator
{
    public static string TransformSeparators(string input, string originalSeparator, string targetSeparator)
    {
        string[] wordsSplit = input.Split(originalSeparator);

        string result = string.Join(targetSeparator, wordsSplit);

        return result;
    }
}

