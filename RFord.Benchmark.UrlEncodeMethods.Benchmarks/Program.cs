using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using RFord.Benchmark.UrlEncodeMethods.Core;

namespace RFord.Benchmark.UrlEncodeMethods.Benchmarks
{
    /*
    |  Method | count |     Mean |     Error |    StdDev |   Median |
    |-------- |------ |---------:|----------:|----------:|---------:|
    |   Alpha |  1000 | 5.098 ms | 0.0967 ms | 0.1615 ms | 5.069 ms |
    | Charlie |  1000 | 3.594 ms | 0.0652 ms | 0.0670 ms | 3.591 ms |
    |   Delta |  1000 | 4.127 ms | 0.0812 ms | 0.1505 ms | 4.097 ms |
    |    Echo |  1000 | 4.036 ms | 0.0777 ms | 0.1138 ms | 4.026 ms |
    | Foxtrot |  1000 | 1.478 ms | 0.0294 ms | 0.0755 ms | 1.453 ms |
    |    Golf |  1000 | 1.042 ms | 0.0211 ms | 0.0610 ms | 1.030 ms | *
    |   Hotel |  1000 | 3.044 ms | 0.0602 ms | 0.0900 ms | 3.026 ms |

    |  Method | count |       Mean |     Error |    StdDev |     Median |
    |-------- |------ |-----------:|----------:|----------:|-----------:|
    |   Alpha |  1000 | 5,066.0 us | 100.84 us | 254.84 us | 5,020.0 us |
    | Charlie |  1000 | 3,591.0 us | 121.90 us | 341.83 us | 3,493.6 us |
    |   Delta |  1000 | 4,121.3 us |  82.17 us | 229.07 us | 4,078.1 us |
    |    Echo |  1000 | 4,054.2 us |  80.96 us | 204.61 us | 4,017.9 us |
    | Foxtrot |  1000 | 1,410.4 us |  27.80 us |  42.45 us | 1,402.7 us |
    |    Golf |  1000 |   986.0 us |  19.25 us |  18.00 us |   988.0 us | *
    |   Hotel |  1000 | 3,021.5 us |  59.89 us | 131.46 us | 2,987.0 us |
    */
    internal class Program
    {
        // for where the winning method will be used, we need only accept the
        // single untranslated version after it is translated, we can do
        // whatever with it so string -> ??? is a given
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<MethodRuns>();
        }
    }

    public class MethodRuns
    {
        public IEnumerable<int> Count => new[] { 1000 };

#pragma warning disable CS8618 // Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable.  GlobalSetupAttribute can't be applied to a ctor, so we suppress this warning.  The BenchmarkRunner will let us know at runtime if the test tries to access a null or undefined value.  :D
        private Random _insecureRandom;
        private byte[] _buffer;
#pragma warning restore CS8618

        [GlobalSetup]
        public void GlobalSetup()
        {
            _insecureRandom = new Random();
            _buffer = new byte[256];
        }

        private string GetTestString()
        {
            _insecureRandom.NextBytes(_buffer);
            return Convert.ToBase64String(_buffer);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Count))]
        public void Alpha(int count)
        {
            for (int i = 0; i < count; i++)
            {
                string discard = new string(Methods.Alpha(GetTestString()).ToArray());
            }
        }

        [Benchmark]
        [ArgumentsSource(nameof(Count))]
        public void Charlie(int count)
        {
            for (int i = 0; i < count; i++)
            {
                string discard = new string(Methods.Charlie(GetTestString()).ToArray());
            }
        }

        [Benchmark]
        [ArgumentsSource(nameof(Count))]
        public void Delta(int count)
        {
            for (int i = 0; i < count; i++)
            {
                string discard = new string(Methods.Delta(GetTestString()).ToArray());
            }
        }

        [Benchmark]
        [ArgumentsSource(nameof(Count))]
        public void Echo(int count)
        {
            for (int i = 0; i < count; i++)
            {
                string discard = new string(Methods.Echo(GetTestString()).ToArray());
            }
        }

        [Benchmark]
        [ArgumentsSource(nameof(Count))]
        public void Foxtrot(int count)
        {
            for (int i = 0; i < count; i++)
            {
                string discard = new string(Methods.Foxtrot(GetTestString()).ToArray());
            }
        }

        [Benchmark]
        [ArgumentsSource(nameof(Count))]
        public void Golf(int count)
        {
            for (int i = 0; i < count; i++)
            {
                string discard = new string(Methods.Golf(GetTestString()).ToArray());
            }
        }

        [Benchmark]
        [ArgumentsSource(nameof(Count))]
        public void Hotel(int count)
        {
            for (int i = 0; i < count; i++)
            {
                string discard = new string(Methods.Hotel(GetTestString()).ToArray());
            }
        }
    }
}