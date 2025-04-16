namespace SourceGUI
{
    partial class EditForm
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
            lblTimestamp = new Label();
            lblInfo = new Label();
            tblMain = new TableLayoutPanel();
            gbInfo = new GroupBox();
            gbOriginal = new GroupBox();
            txtEditOriginal = new TextBox();
            gbSorted = new GroupBox();
            txtEditSorted = new TextBox();
            flpButtons = new FlowLayoutPanel();
            btnSaveEdit = new Button();
            btnDelete = new Button();
            btnCancelEdit = new Button();
            tblMain.SuspendLayout();
            gbInfo.SuspendLayout();
            gbOriginal.SuspendLayout();
            gbSorted.SuspendLayout();
            flpButtons.SuspendLayout();
            SuspendLayout();
            // 
            // lblTimestamp
            // 
            lblTimestamp.Dock = DockStyle.Top;
            lblTimestamp.Location = new Point(3, 34);
            lblTimestamp.Name = "lblTimestamp";
            lblTimestamp.Size = new Size(472, 15);
            lblTimestamp.TabIndex = 1;
            lblTimestamp.Text = "Дата сохранения: ";
            // 
            // lblInfo
            // 
            lblInfo.Dock = DockStyle.Top;
            lblInfo.Location = new Point(3, 19);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(472, 15);
            lblInfo.TabIndex = 0;
            lblInfo.Text = "Редактирование записи ID: ";
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(gbInfo, 0, 0);
            tblMain.Controls.Add(gbOriginal, 0, 1);
            tblMain.Controls.Add(gbSorted, 0, 2);
            tblMain.Controls.Add(flpButtons, 0, 3);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 4;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.Size = new Size(484, 361);
            tblMain.TabIndex = 0;
            // 
            // gbInfo
            // 
            gbInfo.Controls.Add(lblTimestamp);
            gbInfo.Controls.Add(lblInfo);
            gbInfo.Dock = DockStyle.Top;
            gbInfo.Location = new Point(3, 3);
            gbInfo.Name = "gbInfo";
            gbInfo.Size = new Size(478, 53);
            gbInfo.TabIndex = 2;
            gbInfo.TabStop = false;
            // 
            // gbOriginal
            // 
            gbOriginal.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            gbOriginal.Controls.Add(txtEditOriginal);
            gbOriginal.Dock = DockStyle.Fill;
            gbOriginal.Location = new Point(3, 62);
            gbOriginal.Name = "gbOriginal";
            gbOriginal.Size = new Size(478, 127);
            gbOriginal.TabIndex = 3;
            gbOriginal.TabStop = false;
            gbOriginal.Text = "Исходный массив";
            // 
            // txtEditOriginal
            // 
            txtEditOriginal.Dock = DockStyle.Fill;
            txtEditOriginal.Location = new Point(3, 19);
            txtEditOriginal.Multiline = true;
            txtEditOriginal.Name = "txtEditOriginal";
            txtEditOriginal.ScrollBars = ScrollBars.Vertical;
            txtEditOriginal.Size = new Size(472, 105);
            txtEditOriginal.TabIndex = 0;
            // 
            // gbSorted
            // 
            gbSorted.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            gbSorted.Controls.Add(txtEditSorted);
            gbSorted.Dock = DockStyle.Fill;
            gbSorted.Location = new Point(3, 195);
            gbSorted.Name = "gbSorted";
            gbSorted.Size = new Size(478, 127);
            gbSorted.TabIndex = 4;
            gbSorted.TabStop = false;
            gbSorted.Text = "Отсортированный массив";
            // 
            // txtEditSorted
            // 
            txtEditSorted.Dock = DockStyle.Fill;
            txtEditSorted.Location = new Point(3, 19);
            txtEditSorted.Multiline = true;
            txtEditSorted.Name = "txtEditSorted";
            txtEditSorted.ReadOnly = true;
            txtEditSorted.ScrollBars = ScrollBars.Vertical;
            txtEditSorted.Size = new Size(472, 105);
            txtEditSorted.TabIndex = 0;
            // 
            // flpButtons
            // 
            flpButtons.Controls.Add(btnSaveEdit);
            flpButtons.Controls.Add(btnDelete);
            flpButtons.Controls.Add(btnCancelEdit);
            flpButtons.Dock = DockStyle.Bottom;
            flpButtons.FlowDirection = FlowDirection.RightToLeft;
            flpButtons.Location = new Point(3, 328);
            flpButtons.Name = "flpButtons";
            flpButtons.Size = new Size(478, 30);
            flpButtons.TabIndex = 5;
            // 
            // btnSaveEdit
            // 
            btnSaveEdit.Location = new Point(329, 3);
            btnSaveEdit.Name = "btnSaveEdit";
            btnSaveEdit.Size = new Size(146, 23);
            btnSaveEdit.TabIndex = 0;
            btnSaveEdit.Text = "Сохранить изменения";
            btnSaveEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(204, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(119, 23);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Удалить запись";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnCancelEdit
            // 
            btnCancelEdit.Location = new Point(123, 3);
            btnCancelEdit.Name = "btnCancelEdit";
            btnCancelEdit.Size = new Size(75, 23);
            btnCancelEdit.TabIndex = 1;
            btnCancelEdit.Text = "Отмена";
            btnCancelEdit.UseVisualStyleBackColor = true;
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelEdit;
            ClientSize = new Size(484, 361);
            Controls.Add(tblMain);
            MinimumSize = new Size(400, 350);
            Name = "EditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Редактирование записи";
            tblMain.ResumeLayout(false);
            gbInfo.ResumeLayout(false);
            gbOriginal.ResumeLayout(false);
            gbOriginal.PerformLayout();
            gbSorted.ResumeLayout(false);
            gbSorted.PerformLayout();
            flpButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTimestamp;
        private Label lblInfo;
        private TableLayoutPanel tblMain;
        private GroupBox gbInfo;
        private GroupBox gbOriginal;
        private TextBox txtEditOriginal;
        private GroupBox gbSorted;
        private TextBox txtEditSorted;
        private FlowLayoutPanel flpButtons;
        private Button btnSaveEdit;
        private Button btnCancelEdit;
        private Button btnDelete;
    }
}