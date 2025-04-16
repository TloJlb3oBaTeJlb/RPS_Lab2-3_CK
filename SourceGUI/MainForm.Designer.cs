namespace SourceGUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblGreeting = new Label();
            gbInputButtons = new GroupBox();
            rbRandomGenerate = new RadioButton();
            rbManualInput = new RadioButton();
            gbManualInput = new GroupBox();
            btnSubmitManual = new Button();
            txtManualInput = new TextBox();
            label1 = new Label();
            gbRandomGenerate = new GroupBox();
            btnGenerateRandom = new Button();
            label2 = new Label();
            groupBox2 = new GroupBox();
            txtOriginalArray = new TextBox();
            groupBox3 = new GroupBox();
            txtSortedArray = new TextBox();
            btnSort = new Button();
            btnSaveFile = new Button();
            btnSaveDB = new Button();
            btnViewDB = new Button();
            btnExit = new Button();
            tlpMain = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            gbButtons = new GroupBox();
            gbDBButtons = new GroupBox();
            gbSortButton = new GroupBox();
            gbInputButtons.SuspendLayout();
            gbManualInput.SuspendLayout();
            gbRandomGenerate.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            tlpMain.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            gbButtons.SuspendLayout();
            gbDBButtons.SuspendLayout();
            gbSortButton.SuspendLayout();
            SuspendLayout();
            // 
            // lblGreeting
            // 
            lblGreeting.AutoSize = true;
            lblGreeting.Dock = DockStyle.Fill;
            lblGreeting.Location = new Point(3, 0);
            lblGreeting.Name = "lblGreeting";
            lblGreeting.Size = new Size(778, 15);
            lblGreeting.TabIndex = 0;
            lblGreeting.Text = "label0";
            lblGreeting.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gbInputButtons
            // 
            gbInputButtons.Controls.Add(rbRandomGenerate);
            gbInputButtons.Controls.Add(rbManualInput);
            gbInputButtons.Dock = DockStyle.Fill;
            gbInputButtons.Location = new Point(3, 3);
            gbInputButtons.Name = "gbInputButtons";
            gbInputButtons.Size = new Size(772, 48);
            gbInputButtons.TabIndex = 1;
            gbInputButtons.TabStop = false;
            gbInputButtons.Text = "Режим ввода";
            // 
            // rbRandomGenerate
            // 
            rbRandomGenerate.AutoSize = true;
            rbRandomGenerate.Location = new Point(103, 17);
            rbRandomGenerate.Name = "rbRandomGenerate";
            rbRandomGenerate.Size = new Size(145, 19);
            rbRandomGenerate.TabIndex = 1;
            rbRandomGenerate.Text = "Случайная генерация";
            rbRandomGenerate.UseVisualStyleBackColor = true;
            // 
            // rbManualInput
            // 
            rbManualInput.AutoSize = true;
            rbManualInput.Checked = true;
            rbManualInput.Location = new Point(4, 17);
            rbManualInput.Name = "rbManualInput";
            rbManualInput.Size = new Size(94, 19);
            rbManualInput.TabIndex = 0;
            rbManualInput.TabStop = true;
            rbManualInput.Text = "Ручной ввод";
            rbManualInput.UseVisualStyleBackColor = true;
            // 
            // gbManualInput
            // 
            gbManualInput.Controls.Add(btnSubmitManual);
            gbManualInput.Controls.Add(txtManualInput);
            gbManualInput.Controls.Add(label1);
            gbManualInput.Dock = DockStyle.Fill;
            gbManualInput.Location = new Point(3, 19);
            gbManualInput.Name = "gbManualInput";
            gbManualInput.Size = new Size(766, 161);
            gbManualInput.TabIndex = 2;
            gbManualInput.TabStop = false;
            gbManualInput.Text = "Ручной ввод";
            // 
            // btnSubmitManual
            // 
            btnSubmitManual.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSubmitManual.Location = new Point(3, 135);
            btnSubmitManual.Name = "btnSubmitManual";
            btnSubmitManual.Size = new Size(760, 23);
            btnSubmitManual.TabIndex = 2;
            btnSubmitManual.Text = "Создать массив";
            btnSubmitManual.UseVisualStyleBackColor = true;
            // 
            // txtManualInput
            // 
            txtManualInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtManualInput.Location = new Point(3, 40);
            txtManualInput.Multiline = true;
            txtManualInput.Name = "txtManualInput";
            txtManualInput.ScrollBars = ScrollBars.Vertical;
            txtManualInput.Size = new Size(760, 89);
            txtManualInput.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 22);
            label1.Name = "label1";
            label1.Size = new Size(308, 15);
            label1.TabIndex = 0;
            label1.Text = "Введите целые числа через пробел или новую строку:";
            // 
            // gbRandomGenerate
            // 
            gbRandomGenerate.Controls.Add(btnGenerateRandom);
            gbRandomGenerate.Controls.Add(label2);
            gbRandomGenerate.Dock = DockStyle.Fill;
            gbRandomGenerate.Location = new Point(3, 19);
            gbRandomGenerate.Name = "gbRandomGenerate";
            gbRandomGenerate.Size = new Size(766, 161);
            gbRandomGenerate.TabIndex = 3;
            gbRandomGenerate.TabStop = false;
            gbRandomGenerate.Text = "Случайная генерация";
            gbRandomGenerate.Visible = false;
            // 
            // btnGenerateRandom
            // 
            btnGenerateRandom.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGenerateRandom.Dock = DockStyle.Top;
            btnGenerateRandom.Location = new Point(3, 34);
            btnGenerateRandom.Name = "btnGenerateRandom";
            btnGenerateRandom.Size = new Size(760, 23);
            btnGenerateRandom.TabIndex = 1;
            btnGenerateRandom.Text = "Сгенерировать";
            btnGenerateRandom.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Location = new Point(3, 19);
            label2.Name = "label2";
            label2.Size = new Size(299, 15);
            label2.TabIndex = 0;
            label2.Text = "От 1 до 200 элементов в промежутке от -1000 до 1000";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtOriginalArray);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(383, 186);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Исходный массив";
            // 
            // txtOriginalArray
            // 
            txtOriginalArray.Dock = DockStyle.Fill;
            txtOriginalArray.Location = new Point(3, 19);
            txtOriginalArray.Multiline = true;
            txtOriginalArray.Name = "txtOriginalArray";
            txtOriginalArray.ReadOnly = true;
            txtOriginalArray.ScrollBars = ScrollBars.Vertical;
            txtOriginalArray.Size = new Size(377, 164);
            txtOriginalArray.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtSortedArray);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(392, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(383, 186);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Отсортированный массив";
            // 
            // txtSortedArray
            // 
            txtSortedArray.Dock = DockStyle.Fill;
            txtSortedArray.Location = new Point(3, 19);
            txtSortedArray.Multiline = true;
            txtSortedArray.Name = "txtSortedArray";
            txtSortedArray.ReadOnly = true;
            txtSortedArray.ScrollBars = ScrollBars.Vertical;
            txtSortedArray.Size = new Size(377, 164);
            txtSortedArray.TabIndex = 0;
            // 
            // btnSort
            // 
            btnSort.Enabled = false;
            btnSort.Location = new Point(6, 22);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(88, 23);
            btnSort.TabIndex = 0;
            btnSort.Text = "Сортировать";
            btnSort.UseVisualStyleBackColor = true;
            // 
            // btnSaveFile
            // 
            btnSaveFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveFile.Enabled = false;
            btnSaveFile.Location = new Point(263, 22);
            btnSaveFile.Name = "btnSaveFile";
            btnSaveFile.Size = new Size(134, 23);
            btnSaveFile.TabIndex = 1;
            btnSaveFile.Text = "Сохранить в файл...";
            btnSaveFile.UseVisualStyleBackColor = true;
            // 
            // btnSaveDB
            // 
            btnSaveDB.Enabled = false;
            btnSaveDB.Location = new Point(6, 51);
            btnSaveDB.Name = "btnSaveDB";
            btnSaveDB.Size = new Size(110, 23);
            btnSaveDB.TabIndex = 2;
            btnSaveDB.Text = "Сохранить в БД";
            btnSaveDB.UseVisualStyleBackColor = true;
            // 
            // btnViewDB
            // 
            btnViewDB.Location = new Point(6, 22);
            btnViewDB.Name = "btnViewDB";
            btnViewDB.Size = new Size(166, 23);
            btnViewDB.TabIndex = 3;
            btnViewDB.Text = "Посмотреть базу данных";
            btnViewDB.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExit.Location = new Point(322, 58);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 7;
            btnExit.Text = "Выход";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(lblGreeting, 0, 0);
            tlpMain.Controls.Add(tableLayoutPanel1, 0, 2);
            tlpMain.Controls.Add(tableLayoutPanel2, 0, 1);
            tlpMain.Controls.Add(tableLayoutPanel3, 0, 3);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 4;
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.Size = new Size(784, 561);
            tlpMain.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(groupBox3, 1, 0);
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 267);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(778, 192);
            tableLayoutPanel1.TabIndex = 9;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(gbInputButtons, 0, 0);
            tableLayoutPanel2.Controls.Add(groupBox1, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 18);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(778, 243);
            tableLayoutPanel2.TabIndex = 10;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(gbManualInput);
            groupBox1.Controls.Add(gbRandomGenerate);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 57);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(772, 183);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(gbButtons, 2, 0);
            tableLayoutPanel3.Controls.Add(gbDBButtons, 1, 0);
            tableLayoutPanel3.Controls.Add(gbSortButton, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Bottom;
            tableLayoutPanel3.Location = new Point(3, 465);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(778, 93);
            tableLayoutPanel3.TabIndex = 11;
            // 
            // gbButtons
            // 
            gbButtons.Controls.Add(btnExit);
            gbButtons.Controls.Add(btnSaveFile);
            gbButtons.Dock = DockStyle.Fill;
            gbButtons.Location = new Point(372, 3);
            gbButtons.Name = "gbButtons";
            gbButtons.Size = new Size(403, 87);
            gbButtons.TabIndex = 11;
            gbButtons.TabStop = false;
            // 
            // gbDBButtons
            // 
            gbDBButtons.Controls.Add(btnSaveDB);
            gbDBButtons.Controls.Add(btnViewDB);
            gbDBButtons.Dock = DockStyle.Fill;
            gbDBButtons.Location = new Point(113, 3);
            gbDBButtons.Name = "gbDBButtons";
            gbDBButtons.Size = new Size(253, 87);
            gbDBButtons.TabIndex = 1;
            gbDBButtons.TabStop = false;
            // 
            // gbSortButton
            // 
            gbSortButton.Controls.Add(btnSort);
            gbSortButton.Dock = DockStyle.Fill;
            gbSortButton.Location = new Point(3, 3);
            gbSortButton.Name = "gbSortButton";
            gbSortButton.Size = new Size(104, 87);
            gbSortButton.TabIndex = 12;
            gbSortButton.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(tlpMain);
            MinimumSize = new Size(600, 470);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Сортировка QuickSort (C# WinForms .NET 8)";
            gbInputButtons.ResumeLayout(false);
            gbInputButtons.PerformLayout();
            gbManualInput.ResumeLayout(false);
            gbManualInput.PerformLayout();
            gbRandomGenerate.ResumeLayout(false);
            gbRandomGenerate.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            tlpMain.ResumeLayout(false);
            tlpMain.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            gbButtons.ResumeLayout(false);
            gbDBButtons.ResumeLayout(false);
            gbSortButton.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblGreeting;
        private GroupBox gbInputButtons;
        private RadioButton rbRandomGenerate;
        private RadioButton rbManualInput;
        private GroupBox gbManualInput;
        private Label label1;
        private TextBox txtManualInput;
        private GroupBox gbRandomGenerate;
        private Label label2;
        private Button btnGenerateRandom;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private TextBox txtOriginalArray;
        private TextBox txtSortedArray;
        private Button btnSort;
        private Button btnSaveFile;
        private Button btnSaveDB;
        private Button btnViewDB;
        private Button btnExit;
        private Button btnSubmitManual;
        private TableLayoutPanel tlpMain;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox groupBox1;
        private GroupBox gbButtons;
        private TableLayoutPanel tableLayoutPanel3;
        private GroupBox gbDBButtons;
        private GroupBox gbSortButton;
    }
}