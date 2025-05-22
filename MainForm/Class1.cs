// Простір імен для сортування та генерації масивів
namespace CourseWorkSort
{
    // Перерахування для вказання порядку сортування
    public enum ArrSortOrder
    {
        Ascending = 1,   // Сортування за зростанням
        Descending = 2   // Сортування за спаданням
    }

    // Клас для зберігання метрик сортування
    public class SortMetrics
    {
        public int Comparisons { get; set; } = 0;     // Кількість порівнянь
        public int Swaps { get; set; } = 0;           // Кількість перестановок
        public int Assignments { get; set; } = 0;     // Кількість присвоєнь
        public string TheoreticalComplexity { get; set; } = ""; // Теоретична складність
        public string AdditionalInfo { get; set; } = "";        // Додаткова інформація
    }

    // Клас для генерації випадкових масивів
    public class ArrayGenerator
    {
        // Метод для генерації випадкового масиву в заданому діапазоні
        public int[] GenerateRandomArray(int size, int minValue = 1, int maxValue = 5001)
        {
            if (size < 100 || size > 50000)
                throw new ArgumentException("Size should be between 100 and 50000"); // Захист від некоректних розмірів

            int[] array = new int[size];
            Random rnd = new Random(); // Генератор випадкових чисел

            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(minValue, maxValue); // Заповнення масиву випадковими числами
            }

            return array;
        }
    }

    // Інтерфейс, який реалізують усі алгоритми сортування
    public interface ISortAlgorithm
    {
        // Метод сортування, який повертає метрики
        SortMetrics Sort(int[] array, ArrSortOrder order);

        // Метод для отримання теоретичної складності алгоритму
        string GetTheoreticalComplexity();
    }

    // Клас сортування методом "Bucket Sort"
    public class BucketSort : ISortAlgorithm
    {
        public SortMetrics Sort(int[] array, ArrSortOrder order)
        {
            // Створюємо об'єкт для збору метрик
            SortMetrics metrics = new SortMetrics();
            metrics.TheoreticalComplexity = GetTheoreticalComplexity();

            // Перевірка на null або на малий розмір
            if (array == null || array.Length <= 1)
                return metrics;

            // Знаходження максимального та мінімального значень
            int maxValue = array.Max();
            int minValue = array.Min();
            metrics.Comparisons += array.Length * 2; // Порівняння для знаходження max і min

            // Створення "відер" (bucket'ів) для кожного можливого значення
            List<int>[] buckets = new List<int>[maxValue - minValue + 1];

            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<int>();
            }

            // Розміщення кожного елемента в його відро
            foreach (int item in array)
            {
                buckets[item - minValue].Add(item);
                metrics.Assignments++; // Присвоєння при додаванні в bucket
            }

            // Збирання елементів назад у масив у вказаному порядку
            int index = 0;
            if (order == ArrSortOrder.Ascending)
            {
                foreach (var bucket in buckets)
                {
                    foreach (var item in bucket)
                    {
                        array[index++] = item;
                        metrics.Assignments++; // Присвоєння при поверненні в масив
                    }
                }
            }
            else
            {
                for (int i = buckets.Length - 1; i >= 0; i--)
                {
                    foreach (var item in buckets[i])
                    {
                        array[index++] = item;
                        metrics.Assignments++; // Присвоєння при поверненні в масив
                    }
                }
            }

            metrics.AdditionalInfo = $"Кількість відер (buckets): {buckets.Length}";
            return metrics;
        }

        public string GetTheoreticalComplexity()
        {
            return "O(n + k), де n - розмір масиву, k - діапазон значень";
        }
    }

    // Клас сортування методом "Counting Sort"
    public class CountingSort : ISortAlgorithm
    {
        public SortMetrics Sort(int[] array, ArrSortOrder order)
        {
            // Створюємо об'єкт для збору метрик
            SortMetrics metrics = new SortMetrics();
            metrics.TheoreticalComplexity = GetTheoreticalComplexity();

            if (array == null || array.Length <= 1)
                return metrics;

            int max = array.Max(); // Найбільше значення в масиві
            metrics.Comparisons += array.Length; // Порівняння для знаходження max

            int[] count = new int[max + 1]; // Масив лічильників

            foreach (int item in array)
            {
                count[item]++; // Підрахунок кількості кожного числа
                metrics.Assignments++; // Збільшення лічильника
            }

            int currentIndex = 0;
            if (order == ArrSortOrder.Ascending)
            {
                for (int i = 0; i < count.Length; i++)
                {
                    while (count[i] > 0)
                    {
                        array[currentIndex++] = i;
                        metrics.Assignments++; // Присвоєння при поверненні в масив
                        count[i]--;
                        metrics.Assignments++; // Зменшення лічильника
                    }
                }
            }
            else
            {
                for (int i = count.Length - 1; i >= 0; i--)
                {
                    while (count[i] > 0)
                    {
                        array[currentIndex++] = i;
                        metrics.Assignments++; // Присвоєння при поверненні в масив
                        count[i]--;
                        metrics.Assignments++; // Зменшення лічильника
                    }
                }
            }

            metrics.AdditionalInfo = $"Розмір масиву лічильників: {count.Length}";
            return metrics;
        }

        public string GetTheoreticalComplexity()
        {
            return "O(n + k), де n - розмір масиву, k - максимальне значення в масиві";
        }
    }

    // Клас сортування методом "Radix Sort"
    public class RadixSort : ISortAlgorithm
    {
        public SortMetrics Sort(int[] array, ArrSortOrder order)
        {
            // Створюємо об'єкт для збору метрик
            SortMetrics metrics = new SortMetrics();
            metrics.TheoreticalComplexity = GetTheoreticalComplexity();

            if (array == null || array.Length <= 1)
                return metrics;

            int max = array.Max(); // Знаходимо найбільше число для визначення кількості розрядів
            metrics.Comparisons += array.Length; // Порівняння для знаходження max

            int digitCount = 0;
            int temp = max;
            while (temp > 0)
            {
                digitCount++;
                temp /= 10;
            }

            // Проходимо по кожному розряду (одиниці, десятки, сотні, ...)
            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                metrics = CountingSortByDigit(array, exp, order, metrics);
            }

            metrics.AdditionalInfo = $"Кількість розрядів: {digitCount}";
            return metrics;
        }

        // Допоміжний метод — сортування за окремим розрядом
        private SortMetrics CountingSortByDigit(int[] array, int exp, ArrSortOrder order, SortMetrics metrics)
        {
            int[] output = new int[array.Length];
            int[] count = new int[10]; // 10 можливих цифр (0-9)

            foreach (int item in array)
            {
                count[(item / exp) % 10]++;
                metrics.Assignments++; // Збільшення лічильника
            }

            if (order == ArrSortOrder.Ascending)
            {
                for (int i = 1; i < 10; i++)
                {
                    count[i] += count[i - 1];
                    metrics.Assignments++; // Присвоєння при обчисленні префіксної суми
                }
            }
            else
            {
                for (int i = 8; i >= 0; i--)
                {
                    count[i] += count[i + 1];
                    metrics.Assignments++; // Присвоєння при обчисленні префіксної суми
                }
            }

            for (int i = array.Length - 1; i >= 0; i--)
            {
                output[count[(array[i] / exp) % 10] - 1] = array[i];
                metrics.Assignments++; // Присвоєння при розміщенні в вихідний масив
                count[(array[i] / exp) % 10]--;
                metrics.Assignments++; // Зменшення лічильника
            }

            Array.Copy(output, array, array.Length);
            metrics.Assignments += array.Length; // Присвоєння при копіюванні назад у вхідний масив

            return metrics;
        }

        public string GetTheoreticalComplexity()
        {
            return "O(d * (n + k)), де n - розмір масиву, k - діапазон цифр (10), d - кількість розрядів";
        }
    }

    // Клас сортування методом "Flash Sort"
    public class FlashSort : ISortAlgorithm
    {
        public SortMetrics Sort(int[] array, ArrSortOrder order)
        {
            // Створюємо об'єкт для збору метрик
            SortMetrics metrics = new SortMetrics();
            metrics.TheoreticalComplexity = GetTheoreticalComplexity();

            if (array == null || array.Length <= 1)
                return metrics;

            int n = array.Length;
            int m = (int)(0.45 * n); // Кількість класів (груп), приблизно 45% від розміру
            int[] l = new int[m];

            int min = array.Min();
            int max = array.Max();
            metrics.Comparisons += n * 2; // Порівняння для знаходження min і max

            if (min == max) return metrics;

            double c = (double)(m - 1) / (max - min); // Співвідношення для обчислення індексу класу

            // Крок 1: підрахунок кількості елементів у кожному класі
            for (int i = 0; i < n; i++)
            {
                int k = (int)(c * (array[i] - min));
                l[k]++;
                metrics.Assignments++; // Збільшення лічильника
            }

            // Крок 2: Префіксна сума для визначення меж класів
            for (int i = 1; i < m; i++)
            {
                l[i] += l[i - 1];
                metrics.Assignments++; // Присвоєння при обчисленні префіксної суми
            }

            int move = 0;
            int j = 0;
            int k1 = m - 1;
            int flash;

            // Крок 3: Переміщення елементів у правильні позиції
            while (move < (n - 1))
            {
                while (j > (l[k1] - 1))
                {
                    j++;
                    k1 = (int)(c * (array[j] - min));
                    metrics.Comparisons++; // Порівняння в циклі
                }

                flash = array[j];
                metrics.Assignments++; // Присвоєння flash

                while (j != l[k1])
                {
                    k1 = (int)(c * (flash - min));
                    int hold = array[--l[k1]];
                    array[l[k1]] = flash;
                    flash = hold;
                    move++;
                    metrics.Swaps++; // Перестановка елементів
                    metrics.Assignments += 3; // Присвоєння hold, array[l[k1]] і flash
                    metrics.Comparisons++; // Порівняння в циклі
                }
            }

            // Крок 4: Завершальне сортування вставками
            metrics = InsertionSort(array, order, metrics);

            metrics.AdditionalInfo = $"Кількість класів (m): {m}, Кількість переміщень: {move}";

            // Якщо порядок спадання, інвертуємо масив
            if (order == ArrSortOrder.Descending)
            {
                Array.Reverse(array);
                metrics.Assignments += n / 2; // Приблизна кількість операцій при реверсі
            }

            return metrics;
        }

        // Метод сортування вставками (на завершення FlashSort)
        private SortMetrics InsertionSort(int[] array, ArrSortOrder order, SortMetrics metrics)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;
                metrics.Assignments++; // Присвоєння key

                if (order == ArrSortOrder.Ascending)
                {
                    while (j >= 0 && array[j] > key)
                    {
                        array[j + 1] = array[j];
                        j--;
                        metrics.Comparisons++; // Порівняння в циклі
                        metrics.Assignments++; // Присвоєння array[j+1]
                        metrics.Swaps++; // Перестановка елементів
                    }
                }
                else
                {
                    while (j >= 0 && array[j] < key)
                    {
                        array[j + 1] = array[j];
                        j--;
                        metrics.Comparisons++; // Порівняння в циклі
                        metrics.Assignments++; // Присвоєння array[j+1]
                        metrics.Swaps++; // Перестановка елементів
                    }
                }

                array[j + 1] = key;
                metrics.Assignments++; // Присвоєння array[j+1]
            }

            return metrics;
        }

        public string GetTheoreticalComplexity()
        {
            return "O(n) в середньому, O(n²) в гіршому випадку";
        }
    }

    // Клас, який об'єднує всі алгоритми та виконує їх на запит
    public class SortingManager
    {
        // Словник, який зберігає реалізації алгоритмів за їх ідентифікаторами
        private readonly Dictionary<int, ISortAlgorithm> _sortAlgorithms;

        public SortingManager()
        {
            _sortAlgorithms = new Dictionary<int, ISortAlgorithm>
            {
                { 3, new BucketSort() },
                { 4, new CountingSort() },
                { 5, new RadixSort() },
                { 6, new FlashSort() }
            };
        }

        // Метод виконує сортування відповідно до вибраного алгоритму і повертає метрики
        public SortMetrics PerformSort(int choice, int[] array, ArrSortOrder order)
        {
            if (_sortAlgorithms.TryGetValue(choice, out var algorithm))
            {
                SortMetrics metrics = algorithm.Sort(array, order); // Виклик відповідного методу сортування
                Console.WriteLine($"Array sorted using {algorithm.GetType().Name}!");
                return metrics;
            }
            else
            {
                throw new ArgumentException("Invalid sorting algorithm choice");
            }
        }
    }
}


