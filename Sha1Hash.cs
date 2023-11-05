using System.Text;

namespace SoftwareImplementationOfTheHashingAlgorithm;

public static class Sha1Hash
{
    public static byte[] ComputeSha1(byte[] data)
    {
        // Ініціалізуємо початкові значення H0-H4, які визначені в специфікації SHA-1.
        var h = new uint[5];
        h[0] = 0x67452301;
        h[1] = 0xEFCDAB89;
        h[2] = 0x98BADCFE;
        h[3] = 0x10325476;
        h[4] = 0xC3D2E1F0;

        // Перетворюємо вхідні дані в байти
        var paddedData = PadData(data);

        // Обробляємо кожний блок даних
        for (var i = 0; i < paddedData.Length; i += 64)
        {
            var block = new byte[64];
            Array.Copy(paddedData, i, block, 0, 64);
            ProcessBlock(h, block);
        }

        // Кінцеві значення хешу
        var result = new byte[20];
        for (var i = 0; i < 5; i++)
        {
            result[i * 4] = (byte)(h[i] >> 24);
            result[i * 4 + 1] = (byte)(h[i] >> 16);
            result[i * 4 + 2] = (byte)(h[i] >> 8);
            result[i * 4 + 3] = (byte)h[i];
        }

        return result;
    }

    private static byte[] PadData(byte[] data)
    {
        var originalLength = data.Length;
        var originalBits = (long)originalLength * 8;
        var padLength = originalLength % 64 < 56 ? 56 - originalLength % 64 : 120 - originalLength % 64;
        var paddedData = new byte[originalLength + padLength + 8];
        Array.Copy(data, paddedData, originalLength);
        paddedData[originalLength] = 0x80; // Додаємо байт 0x80
        for (var i = 0; i < 8; i++)
        {
            paddedData[paddedData.Length - 8 + i] = (byte)(originalBits >> (56 - i * 8));
        }
        return paddedData;
    }

    private static void ProcessBlock(uint[] h, byte[] block)
    {
        var w = new uint[80];

        // Розширюємо блок 16 слівами в 80 слів
        for (var t = 0; t < 16; t++)
        {
            w[t] = (uint)(block[t * 4] << 24) |
                   (uint)(block[t * 4 + 1] << 16) |
                   (uint)(block[t * 4 + 2] << 8) |
                   block[t * 4 + 3];
        }
        for (var t = 16; t < 80; t++)
        {
            w[t] = LeftRotate(w[t - 3] ^ w[t - 8] ^ w[t - 14] ^ w[t - 16], 1);
        }

        // Ініціалізація тимчасових змінних
        var a = h[0];
        var b = h[1];
        var c = h[2];
        var d = h[3];
        var e = h[4];

        // Основний цикл
        for (var t = 0; t < 80; t++)
        {
            var temp = LeftRotate(a, 5) + F(t, b, c, d) + e + w[t] + K(t);
            e = d;
            d = c;
            c = LeftRotate(b, 30);
            b = a;
            a = temp;
        }

        // Оновлюємо значення хешу
        h[0] = h[0] + a;
        h[1] = h[1] + b;
        h[2] = h[2] + c;
        h[3] = h[3] + d;
        h[4] = h[4] + e;
    }

    private static uint F(int t, uint b, uint c, uint d)
    {
        return t switch
        {
            < 20 => (b & c) | ((~b) & d),
            < 40 => b ^ c ^ d,
            < 60 => (b & c) | (b & d) | (c & d),
            _ => b ^ c ^ d
        };
    }

    private static uint K(int t)
    {
        return t < 20 ? 0x5A827999 : t < 40 ? 0x6ED9EBA1 : t < 60 ? 0x8F1BBCDC : 0xCA62C1D6;
    }

    private static uint LeftRotate(uint value, int offset)
    {
        return (value << offset) | (value >> (32 - offset));
    }

    public static string BytesToHex(byte[] bytes)
    {
        var hex = new StringBuilder(bytes.Length * 2);
        foreach (var b in bytes)
        {
            hex.Append($"{b:x2}");
        }
        return hex.ToString();
    }
}