// Простір імен для сортування та генерації масивів
namespace CourseWorkSort
{
    // Перерахування для вказання порядку сортування
    public enum ArrSortOrder
    {
        Ascending = 1,   // Сортування за зростанням
        Descending = 2   // Сортування за спаданням
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
        void Sort(int[] array, ArrSortOrder order); // Метод сортування
    }

    // Клас сортування методом "Bucket Sort"
    public class BucketSort : ISortAlgorithm
    {
        public void Sort(int[] array, ArrSortOrder order)
        {
            // Перевірка на null або на малий розмір
            if (array == null || array.Length <= 1)
                return;

            // Знаходження максимального та мінімального значень
            int maxValue = array.Max();
            int minValue = array.Min();

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
                    }
                }
            }
        }
    }

    // Клас сортування методом "Counting Sort"
    public class CountingSort : ISortAlgorithm
    {
        public void Sort(int[] array, ArrSortOrder order)
        {
            if (array == null || array.Length <= 1)
                return;

            int max = array.Max(); // Найбільше значення в масиві
            int[] count = new int[max + 1]; // Масив лічильників

            foreach (int item in array)
            {
                count[item]++; // Підрахунок кількості кожного числа
            }

            int currentIndex = 0;
            if (order == ArrSortOrder.Ascending)
            {
                for (int i = 0; i < count.Length; i++)
                {
                    while (count[i] > 0)
                    {
                        array[currentIndex++] = i;
                        count[i]--;
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
                        count[i]--;
                    }
                }
            }
        }
    }

    // Клас сортування методом "Radix Sort"
    public class RadixSort : ISortAlgorithm
    {
        public void Sort(int[] array, ArrSortOrder order)
        {
            if (array == null || array.Length <= 1)
                return;

            int max = array.Max(); // Знаходимо найбільше число для визначення кількості розрядів

            // Проходимо по кожному розряду (одиниці, десятки, сотні, ...)
            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                CountingSortByDigit(array, exp, order);
            }
        }

        // Допоміжний метод — сортування за окремим розрядом
        private void CountingSortByDigit(int[] array, int exp, ArrSortOrder order)
        {
            int[] output = new int[array.Length];
            int[] count = new int[10]; // 10 можливих цифр (0-9)

            foreach (int item in array)
            {
                count[(item / exp) % 10]++;
            }

            if (order == ArrSortOrder.Ascending)
            {
                for (int i = 1; i < 10; i++)
                {
                    count[i] += count[i - 1];
                }
            }
            else
            {
                for (int i = 8; i >= 0; i--)
                {
                    count[i] += count[i + 1];
                }
            }

            for (int i = array.Length - 1; i >= 0; i--)
            {
                output[count[(array[i] / exp) % 10] - 1] = array[i];
                count[(array[i] / exp) % 10]--;
            }

            Array.Copy(output, array, array.Length);
        }
    }

    // Клас сортування методом "Flash Sort"
    public class FlashSort : ISortAlgorithm
    {
        public void Sort(int[] array, ArrSortOrder order)
        {
            if (array == null || array.Length <= 1)
                return;

            int n = array.Length;
            int m = (int)(0.45 * n); // Кількість класів (груп), приблизно 45% від розміру
            int[] l = new int[m];

            int min = array.Min();
            int max = array.Max();

            if (min == max) return;

            double c = (double)(m - 1) / (max - min); // Співвідношення для обчислення індексу класу

            // Крок 1: підрахунок кількості елементів у кожному класі
            for (int i = 0; i < n; i++)
            {
                int k = (int)(c * (array[i] - min));
                l[k]++;
            }

            // Крок 2: Префіксна сума для визначення меж класів
            for (int i = 1; i < m; i++)
            {
                l[i] += l[i - 1];
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
                }

                flash = array[j];

                while (j != l[k1])
                {
                    k1 = (int)(c * (flash - min));
                    int hold = array[--l[k1]];
                    array[l[k1]] = flash;
                    flash = hold;
                    move++;
                }
            }

            // Крок 4: Завершальне сортування вставками
            InsertionSort(array, order);
        }

        // Метод сортування вставками (на завершення FlashSort)
        private void InsertionSort(int[] array, ArrSortOrder order)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;

                if (order == ArrSortOrder.Ascending)
                {
                    while (j >= 0 && array[j] > key)
                    {
                        array[j + 1] = array[j];
                        j--;
                    }
                }
                else
                {
                    while (j >= 0 && array[j] < key)
                    {
                        array[j + 1] = array[j];
                        j--;
                    }
                }

                array[j + 1] = key;
            }
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

        // Метод виконує сортування відповідно до вибраного алгоритму
        public void PerformSort(int choice, int[] array, ArrSortOrder order)
        {
            if (_sortAlgorithms.TryGetValue(choice, out var algorithm))
            {
                algorithm.Sort(array, order); // Виклик відповідного методу сортування
                Console.WriteLine($"Array sorted using {algorithm.GetType().Name}!");
            }
            else
            {
                throw new ArgumentException("Invalid sorting algorithm choice");
            }
        }
    }


}


