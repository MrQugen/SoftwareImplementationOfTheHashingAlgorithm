using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace SoftwareImplementationOfTheHashingAlgorithm;

public static class Program
{
    public static void Main()
    {
        const string input1 = "Hello, World!";
        const string input2 = "This is a test message.";
        const string input3 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";

        var data1 = Encoding.UTF8.GetBytes(input1);
        var data2 = Encoding.UTF8.GetBytes(input2);
        var data3 = Encoding.UTF8.GetBytes(input3);

        // Ваша реалізація SHA-1
        var customHash1 = Sha1Hash.ComputeSha1(data1);
        var customHash2 = Sha1Hash.ComputeSha1(data2);
        var customHash3 = Sha1Hash.ComputeSha1(data3);

        // Бібліотечна реалізація SHA-1
        var systemHash1 = CalculateSha1HashSystem(data1);
        var systemHash2 = CalculateSha1HashSystem(data2);
        var systemHash3 = CalculateSha1HashSystem(data3);

        // Порівнюємо геш-значення
        var match1 = CompareHashes(customHash1, systemHash1);
        var match2 = CompareHashes(customHash2, systemHash2);
        var match3 = CompareHashes(customHash3, systemHash3);

        Console.WriteLine("Message 1 Hashes Match: " + match1);
        Console.WriteLine("Message 2 Hashes Match: " + match2);
        Console.WriteLine("Message 3 Hashes Match: " + match3);
        
        var input = "Hello, World!";
        var data = Encoding.UTF8.GetBytes(input);

        // Проводимо вимірювання часу для вашої реалізації SHA-1
        var customHashStopwatch = new Stopwatch();
        customHashStopwatch.Start();
        var customHash = Sha1Hash.ComputeSha1(data);
        customHashStopwatch.Stop();
        var customHashTime = customHashStopwatch.ElapsedMilliseconds;

        // Проводимо вимірювання часу для бібліотечної реалізації SHA-1
        var systemHashStopwatch = new Stopwatch();
        systemHashStopwatch.Start();
        var systemHash = CalculateSha1HashSystem(data);
        systemHashStopwatch.Stop();
        var systemHashTime = systemHashStopwatch.ElapsedMilliseconds;

        Console.WriteLine("SHA-1 Hash (Custom Implementation): " + Sha1Hash.BytesToHex(customHash));
        Console.WriteLine("SHA-1 Hash (System Implementation): " + Sha1Hash.BytesToHex(systemHash));

        Console.WriteLine("Time taken by Custom Implementation: " + customHashTime + " milliseconds");
        Console.WriteLine("Time taken by System Implementation: " + systemHashTime + " milliseconds");

        Console.WriteLine(CompareHashes(customHash, systemHash) ? "Hashes Match!" : "Hashes Do Not Match!");
    }

    private static byte[] CalculateSha1HashSystem(byte[] data)
    {
        using var sha1 = SHA1.Create();
        return sha1.ComputeHash(data);
    }

    private static bool CompareHashes(IReadOnlyList<byte> hash1, IReadOnlyList<byte> hash2)
    {
        if (hash1.Count != hash2.Count)
            return false;

        for (var i = 0; i < hash1.Count; i++)
        {
            if (hash1[i] != hash2[i])
                return false;
        }

        return true;
    }
}
