using SourceGUI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SourceGUI
{
    public partial class DatabaseForm : Form
    {
        public List<int>? LoadedOriginalArray { get; private set; } = null;
        public List<int>? LoadedSortedArray { get; private set; } = null;

        public DatabaseForm()
        {
            InitializeComponent();
            WireUpEventHandlers();
        }

        private void WireUpEventHandlers()
        {
            this.Load += DatabaseForm_Load;
            dataBaseGrid.SelectionChanged += dataBaseGrid_SelectionChanged; // Событие изменения выбора
            btnLoadSelected.Click += btnLoadSelected_Click;
            btnEditSelected.Click += btnEditSelected_Click;
            btnClose.Click += btnClose_Click;
            this.Resize += DatabaseForm_Resize;
        }

        private void DatabaseForm_Load(object? sender, EventArgs e)
        {
            dataBaseGrid.AutoGenerateColumns = true;
            LoaddataBaseGridData();
            ResizeColumns();
        }

        private void ResizeColumns()
        {
            if (dataBaseGrid.Columns.Count < 4) return;

            dataBaseGrid.Columns[0].Width = 60;
            dataBaseGrid.Columns[1].Width = 115;

            int totalWidth = dataBaseGrid.ClientSize.Width;
            int fixedColumnsWidth = dataBaseGrid.Columns[0].Width + dataBaseGrid.Columns[1].Width + dataBaseGrid.RowHeadersWidth;
            int remainingWidth = totalWidth - fixedColumnsWidth;
            int flexibleColumnsCount = dataBaseGrid.Columns.Count - 2;

            if (flexibleColumnsCount > 0)
            {
                int flexibleColumnWidth = remainingWidth / flexibleColumnsCount;
                for (int i = 2; i < dataBaseGrid.Columns.Count; i++)
                {
                    dataBaseGrid.Columns[i].Width = flexibleColumnWidth;
                }
            }
        }

        private void DatabaseForm_Resize(object? sender, EventArgs e)
        {
            ResizeColumns();
        }

        private void LoaddataBaseGridData()
        {
            List<MainTableMetadata> tableData = DatabaseHelper.GetAllMainTableMetadata();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = tableData;
            dataBaseGrid.DataSource = bindingSource;

            UpdateActionButtonsState();
        }

        private void UpdateActionButtonsState()
        {
            bool isItemSelected = dataBaseGrid.SelectedRows.Count > 0;
            btnLoadSelected.Enabled = isItemSelected;
            btnEditSelected.Enabled = isItemSelected;
        }

        private void dataBaseGrid_SelectionChanged(object? sender, EventArgs e)
        {
            UpdateActionButtonsState();
        }

        private MainTableMetadata? GetSelectedItem()
        {
            if (dataBaseGrid.SelectedRows.Count > 0)
            {
                // Получаем связанный объект данных для выбранной строки
                if (dataBaseGrid.SelectedRows[0].DataBoundItem is MainTableMetadata selectedItem)
                {
                    return selectedItem;
                }
            }
            return null;
        }


        private void btnLoadSelected_Click(object? sender, EventArgs e)
        {
            var selectedItem = GetSelectedItem();
            if (selectedItem != null)
            {
                MainTableEntry? fullEntry = DatabaseHelper.GetSortResultById(selectedItem.ID);
                if (fullEntry != null)
                {
                    LoadedOriginalArray = fullEntry.OriginalArray;
                    LoadedSortedArray = fullEntry.SortedArray;
                    this.DialogResult = DialogResult.OK; // Устанавливаем результат для вызывающей формы
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Не удалось загрузить полные данные для записи с ID={selectedItem.ID}.", "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для загрузки.", "Нет выбора", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEditSelected_Click(object? sender, EventArgs e)
        {
            var selectedItem = GetSelectedItem();
            if (selectedItem != null)
            {
                using (var editForm = new EditForm(selectedItem.ID))
                {
                    DialogResult editResult = editForm.ShowDialog(this); // Показываем как диалог
                    if (editResult == DialogResult.OK)
                    {
                        LoaddataBaseGridData(); // Обновляем данные в гриде
                        MessageBox.Show("Запись успешно обновлена.", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для редактирования.", "Нет выбора", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnClose_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Устанавливаем результат
            this.Close();
        }
    }
}