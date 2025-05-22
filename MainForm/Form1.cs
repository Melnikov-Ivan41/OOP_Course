using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using CourseWorkSort; // Підключення простору імен, в якому знаходяться класи ArrayGenerator і SortingManager

namespace MainForm
{
    public partial class Form1 : Form
    {
        private int[] currentArray = null; // Поточний масив, який буде генеруватися та сортуватися
        private readonly ArrayGenerator generator = new ArrayGenerator(); // Об'єкт для генерації випадкових масивів
        private readonly SortingManager sorter = new SortingManager(); // Об'єкт для виконання сортування
        private Stopwatch stopwatch = new Stopwatch(); // Таймер для вимірювання часу сортування

        public Form1()
        {
            InitializeComponent(); // Ініціалізація компонентів форми
            SetupEventHandlers(); // Прив'язка обробників подій до кнопок
        }

        private void SetupEventHandlers()
        {
            // Обробники подій для натискання на кнопки
            btnGenerate.Click += (s, e) => GenerateArray(); // Кнопка генерації масиву
            btnPrint.Click += (s, e) => PrintArray(); // Кнопка виведення масиву
            btnBucketSort.Click += (s, e) => SortArray(3); // Сортування BucketSort
            btnCountingSort.Click += (s, e) => SortArray(4); // Сортування CountingSort
            btnRadixSort.Click += (s, e) => SortArray(5); // Сортування RadixSort
            btnFlashSort.Click += (s, e) => SortArray(6); // Сортування FlashSort
        }

        private void GenerateArray()
        {
            try
            {
                // Отримання значень з елементів введення
                int size = (int)numSize.Value;
                int min = (int)numMin.Value;
                int max = (int)numMax.Value;

                if (min >= max)
                {
                    lblStatus.Text = "Error: Min must be less than Max!";
                    return;
                }

                // Генерація масиву
                currentArray = generator.GenerateRandomArray(size, min, max);

                // Збереження згенерованого масиву у файл
                File.WriteAllText("generated_array.txt", string.Join(", ", currentArray));

                // Активація кнопок сортування та виводу
                btnPrint.Enabled = true;
                btnBucketSort.Enabled = true;
                btnCountingSort.Enabled = true;
                btnRadixSort.Enabled = true;
                btnFlashSort.Enabled = true;

                lblStatus.Text = $"Array of {size} elements generated and saved!";
                txtOutput.Clear(); // Очищення вікна виводу
                lblComplexity.Text = "Theoretical Complexity: N/A";
                lblMetrics.Text = "Metrics: N/A";
            }
            catch (Exception ex)
            {
                // Обробка помилок
                lblStatus.Text = $"Error: {ex.Message}";
            }
        }

        private void PrintArray()
        {
            if (currentArray != null)
            {
                // Виведення поточного масиву у текстове поле
                txtOutput.Text = string.Join(", ", currentArray);
                lblStatus.Text = "Array printed";
            }
        }

        private void SortArray(int algorithmId)
        {
            if (currentArray != null)
            {
                try
                {
                    // Визначення порядку сортування (за зростанням чи спаданням)
                    var order = rbAscending.Checked ? ArrSortOrder.Ascending : ArrSortOrder.Descending;

                    stopwatch.Restart(); // Початок відліку часу

                    // Виклик сортування і отримання метрик
                    SortMetrics metrics = sorter.PerformSort(algorithmId, currentArray, order);

                    stopwatch.Stop(); // Завершення таймера

                    // Виведення часу сортування
                    lblTime.Text = $"Time: {stopwatch.Elapsed.TotalMilliseconds:F3} ms";

                    // Виведення теоретичної складності
                    lblComplexity.Text = $"Theoretical Complexity: {metrics.TheoreticalComplexity}";

                    // Виведення метрик
                    string metricsText = $"Comparisons: {metrics.Comparisons}, Swaps: {metrics.Swaps}, Assignments: {metrics.Assignments}";
                    if (!string.IsNullOrEmpty(metrics.AdditionalInfo))
                    {
                        metricsText += $", {metrics.AdditionalInfo}";
                    }
                    lblMetrics.Text = metricsText;

                    lblStatus.Text = $"Array sorted using {GetAlgorithmName(algorithmId)}!";

                    // Збереження відсортованого масиву та метрик у файл
                    string resultText = $"Sorted by {GetAlgorithmName(algorithmId)}:\n" +
                                       $"Theoretical Complexity: {metrics.TheoreticalComplexity}\n" +
                                       $"Metrics: {metricsText}\n" +
                                       $"Time: {stopwatch.Elapsed.TotalMilliseconds:F3} ms\n\n" +
                                       $"Array: {string.Join(", ", currentArray)}";
                    File.WriteAllText("result.txt", resultText);

                    // Оновлення статусу про збереження результату
                    lblStatus.Text += " Result saved to result.txt";
                }
                catch (Exception ex)
                {
                    lblStatus.Text = $"Error: {ex.Message}";
                }
            }
        }

        private string GetAlgorithmName(int algorithmId)
        {
            // Повертає назву алгоритму сортування залежно від ID
            return algorithmId switch
            {
                3 => "Bucket Sort",
                4 => "Counting Sort",
                5 => "Radix Sort",
                6 => "Flash Sort",
                _ => "Unknown Algorithm"
            };
        }
    }
}
