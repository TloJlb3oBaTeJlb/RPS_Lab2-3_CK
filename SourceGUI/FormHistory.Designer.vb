<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormHistory
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvHistory = New System.Windows.Forms.DataGridView()
        Me.tplMain = New System.Windows.Forms.TableLayoutPanel()
        Me.flpButtons = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnLoadSelected = New System.Windows.Forms.Button()
        CType(Me.dgvHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tplMain.SuspendLayout()
        Me.flpButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvHistory
        '
        Me.dgvHistory.AllowUserToAddRows = False
        Me.dgvHistory.AllowUserToDeleteRows = False
        Me.dgvHistory.AllowUserToResizeRows = False
        Me.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvHistory.Location = New System.Drawing.Point(3, 3)
        Me.dgvHistory.MultiSelect = False
        Me.dgvHistory.Name = "dgvHistory"
        Me.dgvHistory.ReadOnly = True
        Me.dgvHistory.RowHeadersVisible = False
        Me.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvHistory.Size = New System.Drawing.Size(794, 409)
        Me.dgvHistory.TabIndex = 0
        '
        'tplMain
        '
        Me.tplMain.ColumnCount = 1
        Me.tplMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tplMain.Controls.Add(Me.dgvHistory, 0, 0)
        Me.tplMain.Controls.Add(Me.flpButtons, 0, 1)
        Me.tplMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tplMain.Location = New System.Drawing.Point(0, 0)
        Me.tplMain.Name = "tplMain"
        Me.tplMain.RowCount = 2
        Me.tplMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tplMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tplMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tplMain.Size = New System.Drawing.Size(800, 450)
        Me.tplMain.TabIndex = 1
        '
        'flpButtons
        '
        Me.flpButtons.AutoSize = True
        Me.flpButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpButtons.Controls.Add(Me.btnClose)
        Me.flpButtons.Controls.Add(Me.btnLoadSelected)
        Me.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpButtons.Location = New System.Drawing.Point(3, 418)
        Me.flpButtons.Name = "flpButtons"
        Me.flpButtons.Size = New System.Drawing.Size(794, 29)
        Me.flpButtons.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(716, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Закрыть"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnLoadSelected
        '
        Me.btnLoadSelected.Location = New System.Drawing.Point(635, 3)
        Me.btnLoadSelected.Name = "btnLoadSelected"
        Me.btnLoadSelected.Size = New System.Drawing.Size(75, 23)
        Me.btnLoadSelected.TabIndex = 0
        Me.btnLoadSelected.Text = "Загрузить"
        Me.btnLoadSelected.UseVisualStyleBackColor = True
        '
        'FormHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.tplMain)
        Me.Name = "FormHistory"
        Me.Text = "FormHistory"
        CType(Me.dgvHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tplMain.ResumeLayout(False)
        Me.tplMain.PerformLayout()
        Me.flpButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvHistory As DataGridView
    Friend WithEvents tplMain As TableLayoutPanel
    Friend WithEvents flpButtons As FlowLayoutPanel
    Friend WithEvents btnClose As Button
    Friend WithEvents btnLoadSelected As Button
End Class
