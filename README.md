# Під час виконання завдання використовувався ChatGPT.
# SHA-1 Гешування власною реалізацією

Цей проект містить власну реалізацію алгоритму гешування SHA-1 на мові програмування C#. Він дозволяє обчислювати геш-значення для довільних вхідних даних та порівнювати їх з геш-значеннями, обчисленими за допомогою бібліотечної реалізації SHA-1.
## Вміст

- [Вимоги](#вимоги)
- [Інструкція зі збірки](#інструкція-зі-збірки)
- [Використання](#використання)
- [Порівняння швидкодії](#порівняння-швидкодії)

## Вимоги

Для використання цього програмного забезпечення вам знадобиться:

- .NET Framework 4.5 або вище.

## Інструкція зі збірки

1. Склонуйте цей репозиторій на свій комп'ютер.

2. Відкрийте проект у вашій улюбленій інтегрованій середовищі розробки для C#, наприклад, Visual Studio.

3. Збудуйте проект.

## Використання

### Обчислення геш-значення

Ви можете використовувати цю бібліотеку для обчислення геш-значення з допомогою вашої власної реалізації SHA-1. Ось приклад виклику методу для обчислення геш-значення:

```csharp
string input = "Hello, World!";
byte[] data = Encoding.UTF8.GetBytes(input);

byte[] customHash = SHA1Hash.ComputeSHA1(data);

Console.WriteLine("SHA-1 Hash (Custom Implementation): " + SHA1Hash.BytesToHex(customHash));
```

### Порівняння геш-значень
Ви можете також порівнювати геш-значення, обчислені вашою реалізацією SHA-1, з геш-значеннями, обчисленими бібліотечною реалізацією. Ось приклад порівняння:

```csharp
byte[] customHash = SHA1Hash.ComputeSHA1(data);
byte[] systemHash = CalculateSHA1HashSystem(data);

if (CompareHashes(customHash, systemHash))
{
    Console.WriteLine("Hashes Match!");
}
else
{
    Console.WriteLine("Hashes Do Not Match!");
}
```

### Порівняння швидкодії
Для порівняння швидкості обчислення геш-значення вашою реалізацією SHA-1 з бібліотечною реалізацією, ви можете використовувати клас Stopwatch для вимірювання часу виконання. Ось приклад вимірювання:

```csharp
Stopwatch customHashStopwatch = new Stopwatch();
customHashStopwatch.Start();
byte[] customHash = SHA1Hash.ComputeSHA1(data);
customHashStopwatch.Stop();
long customHashTime = customHashStopwatch.ElapsedMilliseconds;

// Проводимо вимірювання часу для бібліотечної реалізації SHA-1
Stopwatch systemHashStopwatch = new Stopwatch();
systemHashStopwatch.Start();
byte[] systemHash = CalculateSHA1HashSystem(data);
systemHashStopwatch.Stop();
long systemHashTime = systemHashStopwatch.ElapsedMilliseconds;

Console.WriteLine("Time taken by Custom Implementation: " + customHashTime + " milliseconds");
Console.WriteLine("Time taken by System Implementation: " + systemHashTime + " milliseconds");
```
