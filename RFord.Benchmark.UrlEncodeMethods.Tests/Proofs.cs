using RFord.Benchmark.UrlEncodeMethods.Core;

namespace RFord.Benchmark.UrlEncodeMethods.Tests
{
    public class Proofs
    {
        private const string source = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ+/";
        private const string reference = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-_";

        [Fact] public void Alpha() => Assert.Equal(expected: reference, actual: Methods.Alpha(source));
        //[Fact] public void Bravo() => Assert.Equal(expected: reference, actual: Methods.Bravo(source));
        [Fact] public void Charlie() => Assert.Equal(expected: reference, actual: Methods.Charlie(source));
        [Fact] public void Delta() => Assert.Equal(expected: reference, actual: Methods.Delta(source));
        [Fact] public void Echo() => Assert.Equal(expected: reference, actual: Methods.Echo(source));
        [Fact] public void Foxtrot() => Assert.Equal(expected: reference, actual: new string(Methods.Foxtrot(source)));
        [Fact] public void Golf() => Assert.Equal(expected: reference, actual: new string(Methods.Golf(source)));
        [Fact] public void Hotel() => Assert.Equal(expected: reference, actual: Methods.Hotel(source));
    }
}