using System.Text;

namespace RFord.Benchmark.UrlEncodeMethods.Core
{
    public static class Methods
    {
        private static char Encode(char c) => c switch
        {
            '+' => '-',
            '/' => '_',
            _ => c
        };

        public static IEnumerable<char> Alpha(IEnumerable<char> chars)
        {
            foreach (char c in chars)
            {
                yield return Encode(c);
            }
        }

        // spans don't inherit from ienumerable, and as such, are not usable in LINQ expressions
        public static IEnumerable<char> Charlie(IEnumerable<char> chars) => chars.Select(Encode);

        public static string Delta(ReadOnlySpan<char> chars)
        {
            StringBuilder sb = new StringBuilder(chars.Length);
            foreach (char c in chars)
            {
                sb.Append(Encode(c));
            }
            return sb.ToString();
        }

        public static string Echo(ReadOnlySpan<char> chars)
        {
            StringBuilder sb = new StringBuilder(chars.Length);
            for (int i = 0; i < chars.Length; i++)
            {
                sb.Append(Encode(chars[i]));
            }
            return sb.ToString();
        }

        public static ReadOnlySpan<char> Foxtrot(ReadOnlySpan<char> chars)
        {
            Span<char> mutable = new Span<char>(chars.ToArray());

            for (int i = 0; i < chars.Length; i++)
            {
                mutable[i] = Encode(chars[i]);
            }

            return mutable;
        }

        public static ReadOnlySpan<char> Golf(ReadOnlySpan<char> chars)
        {
            Span<char> mutable = new Span<char>(chars.ToArray());

            for (int i = 0; i < chars.Length; i++)
            {
                switch (mutable[i])
                {
                    case '+':
                    case '/':
                        mutable[i] = Encode(mutable[i]);
                        break;
                }
            }

            return mutable;
        }

        public static string Hotel(string str) => str.Replace('+', '-').Replace('/', '_');
    }
}