using SourceGUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SourceGUI
{
    public partial class MainForm : Form
    {
        private List<int> originalArray = new List<int>();
        private List<int> sortedArray = new List<int>();
        private Random randomGenerator = new Random();

        // Конструктор формы
        public MainForm()
        {
            InitializeComponent(); // Этот метод генерируется дизайнером
            WireUpEventHandlers(); // Добавляем обработчики событий вручную
        }

        private void WireUpEventHandlers()
        {
            this.Load += MainForm_Load; // Событие загрузки формы

            rbManualInput.CheckedChanged += InputMode_Changed;
            rbRandomGenerate.CheckedChanged += InputMode_Changed;

            btnSubmitManual.Click += btnSubmitManual_Click;
            btnGenerateRandom.Click += btnGenerateRandom_Click;

            btnSort.Click += btnSort_Click;
            btnSaveFile.Click += btnSaveFile_Click;
            btnSaveDB.Click += btnSaveDB_Click;
            btnViewDB.Click += btnViewDB_Click;
            btnExit.Click += btnExit_Click;
        }


        // Загрузка окна
        private void MainForm_Load(object? sender, EventArgs e)
        {
            lblGreeting.Text = "Чудов Константин Александрович / Корзинин Михаил Андреевич\n" +
                               "Группа 434\n" +
                               "Лабораторная работа N2\n" +
                               "Вариант 11\n" +
                               "Цель работы:\n" +
                               "Разработка программы сортировки при помощи способа быстрой сортировки (QuickSort).\n" +
                               "=======================================================================";

            if (!DatabaseHelper.InitializeDatabase())
            {
                MessageBox.Show("Не удалось инициализировать базу данных. Функции работы с БД будут недоступны.", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSaveDB.Enabled = false;
                btnViewDB.Enabled = false;
            }

            UpdateInputModeUI();
        }

        // --- Управление режимом ввода ---
        private void InputMode_Changed(object? sender, EventArgs e)
        {
            UpdateInputModeUI();
        }

        private void UpdateInputModeUI()
        {
            bool isManual = rbManualInput.Checked;
            gbManualInput.Visible = isManual;
            gbRandomGenerate.Visible = !isManual;
        }

        private void ClearArraysAndResults()
        {
            originalArray.Clear();
            sortedArray.Clear();
            txtOriginalArray.Text = string.Empty;
            txtSortedArray.Text = string.Empty;
            txtManualInput.Text = string.Empty;
            btnSort.Enabled = false;
            // Проверяем доступность БД перед включением кнопки
            btnSaveDB.Enabled = false;
            btnSaveFile.Enabled = false;
        }

        // --- Генерация и создание массивов ---
        private void btnSubmitManual_Click(object? sender, EventArgs e)
        {
            string inputText = txtManualInput.Text.Trim(); // Get the text from the textbox and remove extra spaces
            string[] elementStrings = inputText.Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries); // Split the text into individual numbers

            var tempArray = new List<int>(); // Create a list to store the integers

            foreach (string strElement in elementStrings)
            {
                if (int.TryParse(strElement, out int element))
                {
                    tempArray.Add(element); // Add the parsed integer to the list
                }
                else
                {
                    MessageBox.Show($"Ошибка при чтении элемента '{strElement}'. Пожалуйста, вводите только целые числа.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            originalArray = tempArray; // Assign the list to the original array
            DisplayArray(originalArray, txtOriginalArray); // Display the array in the textbox
            txtSortedArray.Text = string.Empty;
            btnSort.Enabled = true;
            btnSaveDB.Enabled = false;
            btnSaveFile.Enabled = false;
        }

        private void btnGenerateRandom_Click(object? sender, EventArgs e)
        {
            ClearArraysAndResults();

            int size = randomGenerator.Next(1, 201);
            var tempArray = new List<int>(size);

            for (int i = 0; i < size; i++)
            {
                tempArray.Add(randomGenerator.Next(-1000, 1001));
            }

            originalArray = tempArray;
            DisplayArray(originalArray, txtOriginalArray);
            btnSort.Enabled = true;
            btnSaveDB.Enabled = false;
            btnSaveFile.Enabled = false;
        }

        // --- Сортировка и сохранение ---
        private void btnSort_Click(object? sender, EventArgs e)
        {
            if (originalArray == null || originalArray.Count == 0)
            {
                MessageBox.Show("Сначала создайте или сгенерируйте массив.", "Нет данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var arrayToSort = new List<int>(originalArray);
            sortedArray = SortAlgorithm.QuickSort(arrayToSort);

            DisplayArray(sortedArray, txtSortedArray);
            // Проверяем доступность БД перед включением кнопки
            bool dbAvailable = DatabaseHelper.CheckDbConnection(); // Добавим метод проверки
            btnSaveDB.Enabled = dbAvailable;
            btnSaveFile.Enabled = true;
            if (!dbAvailable && btnSaveDB.Visible) // Если кнопка видима, но БД недоступна
            {
                // Можно добавить ToolTip или изменить текст кнопки, чтобы показать, что БД недоступна
                // toolTip1.SetToolTip(btnSaveDB, "База данных недоступна");
            }
        }

        private void btnSaveFile_Click(object? sender, EventArgs e)
        {
            if (sortedArray == null || sortedArray.Count == 0)
            {
                MessageBox.Show("Нет отсортированного массива для сохранения.", "Нет данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Используем SaveFileDialog из System.Windows.Forms
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                sfd.Title = "Сохранить отсортированный массив";
                sfd.FileName = "sorted_array.txt";

                if (sfd.ShowDialog() == DialogResult.OK) // ShowDialog() для WinForms возвращает DialogResult
                {
                    string filePath = sfd.FileName;
                    try
                    {
                        using (var writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8))
                        {
                            writer.WriteLine(sortedArray.Count);
                            writer.WriteLine(string.Join(" ", sortedArray));
                        }
                        MessageBox.Show($"Массив успешно сохранен в файл:\n{filePath}", "Сохранение завершено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении файла:\n{ex.Message}", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } // using автоматически вызовет Dispose для sfd
        }

        private void btnSaveDB_Click(object? sender, EventArgs e)
        {
            if (originalArray != null && sortedArray != null && sortedArray.Count > 0)
            {
                if (DatabaseHelper.SaveSortResult(originalArray, sortedArray))
                {
                    MessageBox.Show("Результаты успешно сохранены в базу данных.", "Сохранение в БД", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось сохранить результаты в базу данных.", "Ошибка сохранения в БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Нет данных для сохранения (исходный или отсортированный массив пуст).", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // --- История и Выход ---
        private void btnViewDB_Click(object? sender, EventArgs e)
        {
            // Создаем экземпляр dataBaseForm
            using (var dataBaseForm = new DatabaseForm())
            {
                // Показываем форму как модальное диалоговое окно
                DialogResult dialogResult = dataBaseForm.ShowDialog(this); // Указываем владельца

                // Проверяем результат диалога
                if (dialogResult == DialogResult.OK)
                {
                    if (dataBaseForm.LoadedOriginalArray != null && dataBaseForm.LoadedSortedArray != null)
                    {
                        originalArray = dataBaseForm.LoadedOriginalArray;
                        sortedArray = dataBaseForm.LoadedSortedArray;

                        DisplayArray(originalArray, txtOriginalArray);
                        DisplayArray(sortedArray, txtSortedArray);

                        btnSort.Enabled = true;
                        bool dbAvailable = DatabaseHelper.CheckDbConnection();
                        btnSaveDB.Enabled = dbAvailable;
                        btnSaveFile.Enabled = true;

                        MessageBox.Show("Данные из истории успешно загружены.", "Загрузка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Окно истории вернуло 'OK', но не удалось получить загруженные данные.", "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            } // using автоматически вызовет Dispose для dataBaseForm
        }

        private void btnExit_Click(object? sender, EventArgs e)
        {
            Application.Exit(); // Корректный способ закрыть WinForms приложение
        }



        // --- Вспомогательные методы ---
        private void DisplayArray(List<int> arr, TextBox targetTextBox)
        {
            if (arr == null || arr.Count == 0)
            {
                targetTextBox.Text = "(пусто)";
            }
            else
            {
                targetTextBox.Text = string.Join(" ", arr);
            }
        }
    }
}