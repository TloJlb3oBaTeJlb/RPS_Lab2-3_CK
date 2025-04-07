<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.lblGreeting = New System.Windows.Forms.Label()
        Me.gbInputMode = New System.Windows.Forms.GroupBox()
        Me.rbRandomGenerate = New System.Windows.Forms.RadioButton()
        Me.rbManualInput = New System.Windows.Forms.RadioButton()
        Me.pnlInputDetails = New System.Windows.Forms.Panel()
        Me.gbRandomGenerate = New System.Windows.Forms.GroupBox()
        Me.btnGenerateRandom = New System.Windows.Forms.Button()
        Me.gbManualInput = New System.Windows.Forms.GroupBox()
        Me.btnSubmitManual = New System.Windows.Forms.Button()
        Me.txtManualInput = New System.Windows.Forms.TextBox()
        Me.lblArrayManual = New System.Windows.Forms.Label()
        Me.gbArrays = New System.Windows.Forms.GroupBox()
        Me.tlpArrayDisplay = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOriginalArray = New System.Windows.Forms.TextBox()
        Me.txtSortedArray = New System.Windows.Forms.TextBox()
        Me.flpButtons = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnOpenDatabase = New System.Windows.Forms.Button()
        Me.btnSaveDB = New System.Windows.Forms.Button()
        Me.btnSaveFile = New System.Windows.Forms.Button()
        Me.btnSort = New System.Windows.Forms.Button()
        Me.sfdSaveArray = New System.Windows.Forms.SaveFileDialog()
        Me.tlpMain.SuspendLayout()
        Me.gbInputMode.SuspendLayout()
        Me.pnlInputDetails.SuspendLayout()
        Me.gbRandomGenerate.SuspendLayout()
        Me.gbManualInput.SuspendLayout()
        Me.gbArrays.SuspendLayout()
        Me.tlpArrayDisplay.SuspendLayout()
        Me.flpButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 1
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Controls.Add(Me.lblGreeting, 0, 0)
        Me.tlpMain.Controls.Add(Me.gbInputMode, 0, 1)
        Me.tlpMain.Controls.Add(Me.pnlInputDetails, 0, 2)
        Me.tlpMain.Controls.Add(Me.gbArrays, 0, 3)
        Me.tlpMain.Controls.Add(Me.flpButtons, 0, 4)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 5
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMain.Size = New System.Drawing.Size(797, 593)
        Me.tlpMain.TabIndex = 0
        '
        'lblGreeting
        '
        Me.lblGreeting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGreeting.Location = New System.Drawing.Point(3, 0)
        Me.lblGreeting.Name = "lblGreeting"
        Me.lblGreeting.Size = New System.Drawing.Size(791, 104)
        Me.lblGreeting.TabIndex = 0
        Me.lblGreeting.Text = "Label1"
        Me.lblGreeting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbInputMode
        '
        Me.gbInputMode.AutoSize = True
        Me.gbInputMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gbInputMode.Controls.Add(Me.rbRandomGenerate)
        Me.gbInputMode.Controls.Add(Me.rbManualInput)
        Me.gbInputMode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbInputMode.Location = New System.Drawing.Point(3, 107)
        Me.gbInputMode.Name = "gbInputMode"
        Me.gbInputMode.Size = New System.Drawing.Size(791, 55)
        Me.gbInputMode.TabIndex = 1
        Me.gbInputMode.TabStop = False
        Me.gbInputMode.Text = "Выбор режима"
        '
        'rbRandomGenerate
        '
        Me.rbRandomGenerate.AutoSize = True
        Me.rbRandomGenerate.Location = New System.Drawing.Point(158, 19)
        Me.rbRandomGenerate.Name = "rbRandomGenerate"
        Me.rbRandomGenerate.Size = New System.Drawing.Size(200, 17)
        Me.rbRandomGenerate.TabIndex = 1
        Me.rbRandomGenerate.Text = "Сгенерировать случайный массив"
        Me.rbRandomGenerate.UseVisualStyleBackColor = True
        '
        'rbManualInput
        '
        Me.rbManualInput.AutoSize = True
        Me.rbManualInput.Checked = True
        Me.rbManualInput.Location = New System.Drawing.Point(6, 19)
        Me.rbManualInput.Name = "rbManualInput"
        Me.rbManualInput.Size = New System.Drawing.Size(146, 17)
        Me.rbManualInput.TabIndex = 0
        Me.rbManualInput.TabStop = True
        Me.rbManualInput.Text = "Ввести массив вручную"
        Me.rbManualInput.UseVisualStyleBackColor = True
        '
        'pnlInputDetails
        '
        Me.pnlInputDetails.AutoSize = True
        Me.pnlInputDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlInputDetails.Controls.Add(Me.gbRandomGenerate)
        Me.pnlInputDetails.Controls.Add(Me.gbManualInput)
        Me.pnlInputDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInputDetails.Location = New System.Drawing.Point(3, 168)
        Me.pnlInputDetails.Name = "pnlInputDetails"
        Me.pnlInputDetails.Size = New System.Drawing.Size(791, 236)
        Me.pnlInputDetails.TabIndex = 2
        '
        'gbRandomGenerate
        '
        Me.gbRandomGenerate.Controls.Add(Me.btnGenerateRandom)
        Me.gbRandomGenerate.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbRandomGenerate.Location = New System.Drawing.Point(0, 136)
        Me.gbRandomGenerate.Name = "gbRandomGenerate"
        Me.gbRandomGenerate.Size = New System.Drawing.Size(791, 100)
        Me.gbRandomGenerate.TabIndex = 1
        Me.gbRandomGenerate.TabStop = False
        Me.gbRandomGenerate.Text = "Случайная генерация"
        '
        'btnGenerateRandom
        '
        Me.btnGenerateRandom.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnGenerateRandom.Location = New System.Drawing.Point(3, 16)
        Me.btnGenerateRandom.Name = "btnGenerateRandom"
        Me.btnGenerateRandom.Size = New System.Drawing.Size(785, 23)
        Me.btnGenerateRandom.TabIndex = 0
        Me.btnGenerateRandom.Text = "Сгенерировать"
        Me.btnGenerateRandom.UseVisualStyleBackColor = True
        '
        'gbManualInput
        '
        Me.gbManualInput.Controls.Add(Me.btnSubmitManual)
        Me.gbManualInput.Controls.Add(Me.txtManualInput)
        Me.gbManualInput.Controls.Add(Me.lblArrayManual)
        Me.gbManualInput.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbManualInput.Location = New System.Drawing.Point(0, 0)
        Me.gbManualInput.Name = "gbManualInput"
        Me.gbManualInput.Size = New System.Drawing.Size(791, 136)
        Me.gbManualInput.TabIndex = 0
        Me.gbManualInput.TabStop = False
        Me.gbManualInput.Text = "Ручной ввод"
        '
        'btnSubmitManual
        '
        Me.btnSubmitManual.Location = New System.Drawing.Point(668, 100)
        Me.btnSubmitManual.Name = "btnSubmitManual"
        Me.btnSubmitManual.Size = New System.Drawing.Size(114, 23)
        Me.btnSubmitManual.TabIndex = 4
        Me.btnSubmitManual.Text = "Создать массив"
        Me.btnSubmitManual.UseVisualStyleBackColor = True
        '
        'txtManualInput
        '
        Me.txtManualInput.Location = New System.Drawing.Point(6, 52)
        Me.txtManualInput.Multiline = True
        Me.txtManualInput.Name = "txtManualInput"
        Me.txtManualInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtManualInput.Size = New System.Drawing.Size(776, 42)
        Me.txtManualInput.TabIndex = 3
        '
        'lblArrayManual
        '
        Me.lblArrayManual.AutoSize = True
        Me.lblArrayManual.Location = New System.Drawing.Point(3, 36)
        Me.lblArrayManual.Name = "lblArrayManual"
        Me.lblArrayManual.Size = New System.Drawing.Size(287, 13)
        Me.lblArrayManual.TabIndex = 1
        Me.lblArrayManual.Text = "Элементы массива (через пробел или с новой строки):"
        '
        'gbArrays
        '
        Me.gbArrays.Controls.Add(Me.tlpArrayDisplay)
        Me.gbArrays.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbArrays.Location = New System.Drawing.Point(3, 410)
        Me.gbArrays.Name = "gbArrays"
        Me.gbArrays.Size = New System.Drawing.Size(791, 120)
        Me.gbArrays.TabIndex = 3
        Me.gbArrays.TabStop = False
        Me.gbArrays.Text = "Массивы"
        '
        'tlpArrayDisplay
        '
        Me.tlpArrayDisplay.ColumnCount = 2
        Me.tlpArrayDisplay.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpArrayDisplay.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpArrayDisplay.Controls.Add(Me.Label1, 0, 0)
        Me.tlpArrayDisplay.Controls.Add(Me.Label2, 0, 1)
        Me.tlpArrayDisplay.Controls.Add(Me.txtOriginalArray, 1, 0)
        Me.tlpArrayDisplay.Controls.Add(Me.txtSortedArray, 1, 1)
        Me.tlpArrayDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpArrayDisplay.Location = New System.Drawing.Point(3, 16)
        Me.tlpArrayDisplay.Name = "tlpArrayDisplay"
        Me.tlpArrayDisplay.RowCount = 2
        Me.tlpArrayDisplay.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpArrayDisplay.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpArrayDisplay.Size = New System.Drawing.Size(785, 101)
        Me.tlpArrayDisplay.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Исходный массив:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Отсортированный массив:"
        '
        'txtOriginalArray
        '
        Me.txtOriginalArray.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOriginalArray.Location = New System.Drawing.Point(152, 3)
        Me.txtOriginalArray.Multiline = True
        Me.txtOriginalArray.Name = "txtOriginalArray"
        Me.txtOriginalArray.ReadOnly = True
        Me.txtOriginalArray.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOriginalArray.Size = New System.Drawing.Size(630, 44)
        Me.txtOriginalArray.TabIndex = 2
        '
        'txtSortedArray
        '
        Me.txtSortedArray.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSortedArray.Location = New System.Drawing.Point(152, 53)
        Me.txtSortedArray.Multiline = True
        Me.txtSortedArray.Name = "txtSortedArray"
        Me.txtSortedArray.ReadOnly = True
        Me.txtSortedArray.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSortedArray.Size = New System.Drawing.Size(630, 45)
        Me.txtSortedArray.TabIndex = 3
        '
        'flpButtons
        '
        Me.flpButtons.AutoSize = True
        Me.flpButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpButtons.Controls.Add(Me.btnExit)
        Me.flpButtons.Controls.Add(Me.btnOpenDatabase)
        Me.flpButtons.Controls.Add(Me.btnSaveDB)
        Me.flpButtons.Controls.Add(Me.btnSaveFile)
        Me.flpButtons.Controls.Add(Me.btnSort)
        Me.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpButtons.Location = New System.Drawing.Point(3, 536)
        Me.flpButtons.Name = "flpButtons"
        Me.flpButtons.Size = New System.Drawing.Size(791, 54)
        Me.flpButtons.TabIndex = 4
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(713, 28)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(0, 28, 3, 3)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Выход"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnOpenDatabase
        '
        Me.btnOpenDatabase.Location = New System.Drawing.Point(579, 3)
        Me.btnOpenDatabase.Name = "btnOpenDatabase"
        Me.btnOpenDatabase.Size = New System.Drawing.Size(131, 23)
        Me.btnOpenDatabase.TabIndex = 4
        Me.btnOpenDatabase.Text = "Открыть Базу Данных"
        Me.btnOpenDatabase.UseVisualStyleBackColor = True
        '
        'btnSaveDB
        '
        Me.btnSaveDB.Location = New System.Drawing.Point(466, 3)
        Me.btnSaveDB.Name = "btnSaveDB"
        Me.btnSaveDB.Size = New System.Drawing.Size(107, 23)
        Me.btnSaveDB.TabIndex = 3
        Me.btnSaveDB.Text = "Сохранить в БД"
        Me.btnSaveDB.UseVisualStyleBackColor = True
        '
        'btnSaveFile
        '
        Me.btnSaveFile.Enabled = False
        Me.btnSaveFile.Location = New System.Drawing.Point(344, 3)
        Me.btnSaveFile.Margin = New System.Windows.Forms.Padding(3, 3, 1, 3)
        Me.btnSaveFile.Name = "btnSaveFile"
        Me.btnSaveFile.Size = New System.Drawing.Size(118, 23)
        Me.btnSaveFile.TabIndex = 1
        Me.btnSaveFile.Text = "Сохранить в файл"
        Me.btnSaveFile.UseVisualStyleBackColor = True
        '
        'btnSort
        '
        Me.btnSort.Enabled = False
        Me.btnSort.Location = New System.Drawing.Point(244, 3)
        Me.btnSort.Name = "btnSort"
        Me.btnSort.Size = New System.Drawing.Size(94, 23)
        Me.btnSort.TabIndex = 0
        Me.btnSort.Text = "Сортировать"
        Me.btnSort.UseVisualStyleBackColor = True
        '
        'sfdSaveArray
        '
        Me.sfdSaveArray.DefaultExt = "txt"
        Me.sfdSaveArray.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*"
        Me.sfdSaveArray.Title = "Сохранить отсортированный массив"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 593)
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.gbInputMode.ResumeLayout(False)
        Me.gbInputMode.PerformLayout()
        Me.pnlInputDetails.ResumeLayout(False)
        Me.gbRandomGenerate.ResumeLayout(False)
        Me.gbManualInput.ResumeLayout(False)
        Me.gbManualInput.PerformLayout()
        Me.gbArrays.ResumeLayout(False)
        Me.tlpArrayDisplay.ResumeLayout(False)
        Me.tlpArrayDisplay.PerformLayout()
        Me.flpButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpMain As TableLayoutPanel
    Friend WithEvents lblGreeting As Label
    Friend WithEvents gbInputMode As GroupBox
    Friend WithEvents rbRandomGenerate As RadioButton
    Friend WithEvents rbManualInput As RadioButton
    Friend WithEvents pnlInputDetails As Panel
    Friend WithEvents gbRandomGenerate As GroupBox
    Friend WithEvents gbManualInput As GroupBox
    Friend WithEvents lblArrayManual As Label
    Friend WithEvents txtManualInput As TextBox
    Friend WithEvents btnSubmitManual As Button
    Friend WithEvents btnGenerateRandom As Button
    Friend WithEvents gbArrays As GroupBox
    Friend WithEvents tlpArrayDisplay As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtOriginalArray As TextBox
    Friend WithEvents txtSortedArray As TextBox
    Friend WithEvents flpButtons As FlowLayoutPanel
    Friend WithEvents btnExit As Button
    Friend WithEvents btnSaveFile As Button
    Friend WithEvents btnSort As Button
    Friend WithEvents sfdSaveArray As SaveFileDialog
    Friend WithEvents btnSaveDB As Button
    Friend WithEvents btnOpenDatabase As Button
End Class
