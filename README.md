# Під час виконання завдання використовувався ChatGPT!
# Під час виконання завдання використовувався ChatGPT!
# Під час виконання завдання використовувався ChatGPT!
# Під час виконання завдання використовувався ChatGPT!
# Під час виконання завдання використовувався ChatGPT!

# SHA-1
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

### Клас SHA1Hash
Цей клас містить реалізацію алгоритму гешування SHA-1. Давайте розглянемо основні методи та їх функції:

- **public static byte[] ComputeSHA1(byte[] data)**: Цей метод обчислює геш-значення SHA-1 для вхідних даних, які подаються як масив байтів. Цей метод викликається зовнішнім кодом для обчислення геш-значення.

- **private static byte[] PadData(byte[] data)**: Цей метод використовується для доповнення вхідних даних перед обчисленням геш-значення згідно зі специфікацією SHA-1. Він додає до вхідних даних байти, щоб розмір вхідних даних був кратним 64 байтам.

- **private static void ProcessBlock(uint[] h, byte[] block)**: Цей метод обробляє окремий блок даних. Він розглядає кожен блок даних і виконує раунди обчислення хешу SHA-1 на цьому блоку.

- **private static uint F(int t, uint b, uint c, uint d)**: Ця функція визначає, яку операцію обчислення SHA-1 виконувати на кожному раунді. Вона залежить від номера раунду та значень b, c і d.

- **private static uint K(int t)**: Ця функція визначає константи K(t), які використовуються в обчисленні SHA-1 на кожному раунді.

- **private static uint LeftRotate(uint value, int offset)**: Ця функція виконує циклічний зсув числа вліво на певну кількість бітів.

- **public static string BytesToHex(byte[] bytes)**: Цей метод перетворює масив байтів у шістнадцятковий рядок, щоб геш-значення можна було легше відображати.

### Клас Program
Клас Program містить точку входу в програму і деякі додаткові методи:

- **static void Main()**: Це головний метод програми. В ньому проводяться вимірювання часу виконання обчислення геш-значення за допомогою власної реалізації та бібліотечної реалізації SHA-1. Результати порівнюються і виводяться на екран.

- **static byte[] CalculateSHA1HashSystem(byte[] data)**: Цей метод використовує бібліотечну реалізацію SHA-1 для обчислення геш-значення для вхідних даних.

- **static bool CompareHashes(byte[] hash1, byte[] hash2)**: Цей метод порівнює два геш-значення, щоб переконатися, що вони співпадають.
