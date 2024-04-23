using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Lab_19_OOP_Dykyi
{
    public partial class Form1 : Form
    {
        private Dictionary<char, int> charCount = new Dictionary<char, int>();

        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button2.Click += button2_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;

            // Перевірка на пустий ввід
            if (string.IsNullOrWhiteSpace(input))
            {
                ShowErrorMessage("Введіть рядок для обчислення.");
                return;
            }

            // Перевірка на наявність лише пробілів
            if (input.Trim() == "")
            {
                ShowErrorMessage("Введено лише пробіли. Введіть коректний рядок.");
                return;
            }

            // Очищаємо попередні дані
            charCount.Clear();

            // Лічильник кількості повторень букв
            foreach (char c in input)
            {
                if (!charCount.ContainsKey(c))
                {
                    charCount[c] = 1;
                }
                else
                {
                    charCount[c]++;
                }
            }

            // Виводимо результат у текстове поле
            textBox2.Clear();
            foreach (var pair in charCount)
            {
                textBox2.Text += $"Символ: {pair.Key}, кількість: {pair.Value}\r\n";
            }

            // Підрахунок кількості букв, які зустрілися двічі або більше
            int countOfRepeatedChars = charCount.Count(pair => pair.Value >= 2);
            label2.Text = $"Кількість букв, які зустрілися двічі або більше: {countOfRepeatedChars}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Очищаємо текстові поля і змінні
            textBox1.Clear();
            textBox2.Clear();
            label2.Text = "Кількість букв, які зустрілися двічі або більше: ";
            charCount.Clear();
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
