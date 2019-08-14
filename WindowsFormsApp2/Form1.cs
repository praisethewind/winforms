using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace SortAnalysis
{
    public partial class Form1 : Form
    {
        static int[] arrayToSort;
        bool isDraw = true;
        public Form1()
        {
            InitializeComponent();
            textBox4.Text = String.Format("{0}", 1000);
            arrayToSort = new int[Int32.Parse(textBox4.Text)];
            //GenerateNumbers();
        }

        //Отрисовка массива в текстбоксе
        private void DrawArray()
        {
            textBox1.Text = "";
            int a = 500;
            if (Int32.Parse(textBox4.Text) < 500) a = Int32.Parse(textBox4.Text);
            for (int n = 0; n < a; n++)
                textBox1.Text += arrayToSort[n] + ", ";
        }

        //Генерация чисел
        private void GenerateNumbers()
        {
            Array.Resize(ref arrayToSort, Int32.Parse(textBox4.Text));
            Random rd = new Random();
            for (int i = 0; i < arrayToSort.Length; ++i)
            {
                arrayToSort[i] = rd.Next(Int32.Parse(textBox8.Text), Int32.Parse(textBox9.Text));
            }
            textBox6.Text = "Массив сгенерирован";
            textBox10.Text = "";
        }

        private void StopTimerAndCountIt(Stopwatch timer)
        {
            timer.Stop();
            textBox2.Text = String.Format("{0}  миллисекунд", timer.ElapsedMilliseconds);
            if (isDraw)
                DrawArray();
            textBox6.Text = "";
            textBox10.Text = "Sorted";
        }

        // Сортировка вставками
        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch timer = Stopwatch.StartNew();
            Sort.InsertionSort(arrayToSort);
            StopTimerAndCountIt(timer);
        }

        // Сортировка пузырьком
        private void button2_Click_1(object sender, EventArgs e)
        {
            Stopwatch timer = Stopwatch.StartNew();
            Sort.BubbleSort(arrayToSort);
            StopTimerAndCountIt(timer);
        }

        // Сортировка Шелла
        private void button3_Click(object sender, EventArgs e)
        {
            Stopwatch timer = Stopwatch.StartNew();
            Sort.ShellSort(arrayToSort);
            StopTimerAndCountIt(timer);
        }

        // Быстрая сортировка
        private void button4_Click_1(object sender, EventArgs e)
        {
            Stopwatch timer = Stopwatch.StartNew();
            Sort.QuickSort(arrayToSort, 0, arrayToSort.Length - 1);
            StopTimerAndCountIt(timer);
        }

        // Генерация массива случайных чисел
        private void button5_Click_1(object sender, EventArgs e)
        {
            GenerateNumbers();
            if (isDraw)
                DrawArray();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            isDraw = checkBox1.Checked;
            if (!isDraw)
                textBox1.Text = "Вывод элементов массива выключен.";
            else
                textBox1.Text = "Вывод включен. Для вывода массива может потребоваться некоторое время.";
        }

        private void Exit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Укажите входные данные." + Environment.NewLine + "2. Нажмите кнопку 'генерация чисел'"
                + Environment.NewLine + "3. Нажатием соответствующей кнопки выберите алгоритм сортировки");
        }
    }
}
