namespace SourceGUI
{
    partial class DatabaseForm
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
            dataBaseGrid = new DataGridView();
            tlpMain = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnClose = new Button();
            btnEditSelected = new Button();
            btnLoadSelected = new Button();
            ((System.ComponentModel.ISupportInitialize)dataBaseGrid).BeginInit();
            tlpMain.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataBaseGrid
            // 
            dataBaseGrid.AllowUserToAddRows = false;
            dataBaseGrid.AllowUserToDeleteRows = false;
            dataBaseGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataBaseGrid.Dock = DockStyle.Fill;
            dataBaseGrid.Location = new Point(3, 3);
            dataBaseGrid.MultiSelect = false;
            dataBaseGrid.Name = "dataBaseGrid";
            dataBaseGrid.ReadOnly = true;
            dataBaseGrid.ScrollBars = ScrollBars.Vertical;
            dataBaseGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataBaseGrid.Size = new Size(578, 371);
            dataBaseGrid.TabIndex = 0;
            // 
            // tlpMain
            // 
            tlpMain.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(dataBaseGrid, 0, 0);
            tlpMain.Controls.Add(flowLayoutPanel1, 0, 1);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 2;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.Size = new Size(584, 411);
            tlpMain.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnClose);
            flowLayoutPanel1.Controls.Add(btnEditSelected);
            flowLayoutPanel1.Controls.Add(btnLoadSelected);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(3, 380);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(578, 28);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(500, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 0;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnEditSelected
            // 
            btnEditSelected.Enabled = false;
            btnEditSelected.Location = new Point(320, 3);
            btnEditSelected.Name = "btnEditSelected";
            btnEditSelected.Size = new Size(174, 23);
            btnEditSelected.TabIndex = 1;
            btnEditSelected.Text = "Редактировать выбранное";
            btnEditSelected.UseVisualStyleBackColor = true;
            // 
            // btnLoadSelected
            // 
            btnLoadSelected.Location = new Point(171, 3);
            btnLoadSelected.Name = "btnLoadSelected";
            btnLoadSelected.Size = new Size(143, 23);
            btnLoadSelected.TabIndex = 2;
            btnLoadSelected.Text = "Загрузить выбранное";
            btnLoadSelected.UseVisualStyleBackColor = true;
            // 
            // DatabaseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 411);
            Controls.Add(tlpMain);
            MinimumSize = new Size(440, 200);
            Name = "DatabaseForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "База Данных";
            ((System.ComponentModel.ISupportInitialize)dataBaseGrid).EndInit();
            tlpMain.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataBaseGrid;
        private TableLayoutPanel tlpMain;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnClose;
        private Button btnEditSelected;
        private Button btnLoadSelected;
    }
}