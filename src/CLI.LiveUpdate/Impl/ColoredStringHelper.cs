namespace ITGlobal.CommandLine.Impl
{
    internal static class ColoredStringHelper
    {
        public static bool AreEqual(ColoredString[] left, ColoredString[] right)
        {
            if (left == right)
            {
                return true;
            }

            if (left == null || right == null)
            {
                return false;
            }

            if (left.Length != right.Length)
            {
                return false;
            }

            for (var i = 0; i < left.Length; i++)
            {
                if (left[i] != right[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}