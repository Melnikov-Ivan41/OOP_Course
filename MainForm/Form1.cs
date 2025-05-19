using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using CourseWorkSort; // ϳ��������� �������� ����, � ����� ����������� ����� ArrayGenerator � SortingManager

namespace MainForm
{
    public partial class Form1 : Form
    {
        private int[] currentArray = null; // �������� �����, ���� ���� ������������ �� �����������
        private readonly ArrayGenerator generator = new ArrayGenerator(); // ��'��� ��� ��������� ���������� ������
        private readonly SortingManager sorter = new SortingManager(); // ��'��� ��� ��������� ����������
        private Stopwatch stopwatch = new Stopwatch(); // ������ ��� ���������� ���� ����������

        public Form1()
        {
            InitializeComponent(); // ����������� ���������� �����
            SetupEventHandlers(); // ����'���� ��������� ���� �� ������
        }

        private void SetupEventHandlers()
        {
            // ��������� ���� ��� ���������� �� ������
            btnGenerate.Click += (s, e) => GenerateArray(); // ������ ��������� ������
            btnPrint.Click += (s, e) => PrintArray(); // ������ ��������� ������
            btnBucketSort.Click += (s, e) => SortArray(3); // ���������� BucketSort
            btnCountingSort.Click += (s, e) => SortArray(4); // ���������� CountingSort
            btnRadixSort.Click += (s, e) => SortArray(5); // ���������� RadixSort
            btnFlashSort.Click += (s, e) => SortArray(6); // ���������� FlashSort
        }

        private void GenerateArray()
        {
            try
            {
                // ��������� ������� � �������� ��������
                int size = (int)numSize.Value;
                int min = (int)numMin.Value;
                int max = (int)numMax.Value;

                if (min >= max)
                {
                    lblStatus.Text = "Error: Min must be less than Max!";
                    return;
                }

                // ��������� ������
                currentArray = generator.GenerateRandomArray(size, min, max);

                // ���������� ������������� ������ � ����
                File.WriteAllText("generated_array.txt", string.Join(", ", currentArray));

                // ��������� ������ ���������� �� ������
                btnPrint.Enabled = true;
                btnBucketSort.Enabled = true;
                btnCountingSort.Enabled = true;
                btnRadixSort.Enabled = true;
                btnFlashSort.Enabled = true;

                lblStatus.Text = $"Array of {size} elements generated and saved!";
                txtOutput.Clear(); // �������� ���� ������
            }
            catch (Exception ex)
            {
                // ������� �������
                lblStatus.Text = $"Error: {ex.Message}";
            }
        }


        private void PrintArray()
        {
            if (currentArray != null)
            {
                // ��������� ��������� ������ � �������� ����
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
                    // ���������� ������� ���������� (�� ���������� �� ���������)
                    var order = rbAscending.Checked ? ArrSortOrder.Ascending : ArrSortOrder.Descending;

                    stopwatch.Restart(); // ������� ����� ����
                    sorter.PerformSort(algorithmId, currentArray, order); // ������ ����������
                    stopwatch.Stop(); // ���������� �������

                    // ��������� ���� ����������
                    lblTime.Text = $"Time: {stopwatch.Elapsed.TotalMilliseconds:F3} ms";
                    lblStatus.Text = $"Array sorted using {GetAlgorithmName(algorithmId)}!";

                    // ���������� ������������� ������ � ����
                    string resultText = $"Sorted by {GetAlgorithmName(algorithmId)}: {string.Join(", ", currentArray)}";
                    File.WriteAllText("result.txt", resultText);

                    // ��������� ������� ��� ���������� ����������
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
            // ������� ����� ��������� ���������� ������� �� ID
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
