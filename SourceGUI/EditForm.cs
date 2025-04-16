using SourceGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SourceGUI
{
    public partial class EditForm : Form
    {
        private readonly long entryId;
        private MainTableEntry? currentEntry;

        public EditForm(long id)
        {
            InitializeComponent();
            WireUpEventHandlers();
            entryId = id;
        }

        private void WireUpEventHandlers()
        {
            this.Load += EditForm_Load;
            btnSaveEdit.Click += btnSaveEdit_Click;
            btnDelete.Click += btnDelete_Click;
            // btnCancelEdit обрабатывается свойством CancelButton формы
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (currentEntry == null)
            {
                MessageBox.Show("Нечего удалять. Запись не загружена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Вы уверены, что хотите БЕЗВОЗВРАТНО удалить запись с ID={currentEntry.ID}?",
                                             "Подтверждение удаления",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (DatabaseHelper.DeleteSortResult(currentEntry.ID))
                {
                    MessageBox.Show("Запись успешно удалена.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Не удалось удалить запись с ID={currentEntry.ID}.", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EditForm_Load(object? sender, EventArgs e)
        {
            currentEntry = DatabaseHelper.GetSortResultById(entryId);

            if (currentEntry != null)
            {
                lblInfo.Text = $"Редактирование записи ID: {currentEntry.ID}";
                lblTimestamp.Text = $"Дата сохранения: {currentEntry.Timestamp:yyyy-MM-dd HH:mm:ss}";

                txtEditOriginal.Text = string.Join(",", currentEntry.OriginalArray ?? new List<int>());
                txtEditSorted.Text = string.Join(",", currentEntry.SortedArray ?? new List<int>());
            }
            else
            {
                MessageBox.Show($"Не удалось загрузить данные для записи с ID={entryId}. Окно будет закрыто.",
                                "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnSaveEdit_Click(object? sender, EventArgs e)
        {
            List<int> newOriginal;
            List<int> newSorted;

            try
            {
                newOriginal = ParseIntListFromString(txtEditOriginal.Text);
                newSorted = SortAlgorithm.QuickSort(new List<int>(newOriginal));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обработке введенных данных: {ex.Message}\nПожалуйста, убедитесь, что введены только целые числа, разделенные запятыми.",
                                "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DatabaseHelper.UpdateSortResult(entryId, newOriginal, newSorted))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show($"Не удалось сохранить изменения для записи ID={entryId} в базе данных.",
                                "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // btnCancelEdit_Click не нужен, если установлено свойство CancelButton формы

        private static List<int> ParseIntListFromString(string? data)
        {
            var list = new List<int>();
            if (string.IsNullOrWhiteSpace(data)) return list;
            string[] parts = data.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string part in parts)
            {
                if (int.TryParse(part.Trim(), out int number)) list.Add(number);
                else throw new FormatException($"Не удалось преобразовать '{part.Trim()}' в целое число.");
            }
            return list;
        }
    }
}