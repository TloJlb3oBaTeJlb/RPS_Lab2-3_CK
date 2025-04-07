Imports System.IO ' Для работы с файлами
Imports SourceGUI.Algorithm

Public Class Form1

    ' Списки для хранения чисел
    Private originalArray As List(Of Integer) = New List(Of Integer)()
    Private sortedArray As List(Of Integer) = New List(Of Integer)()
    Private randomGenerator As New Random() ' Генератор случайных чисел

    ' Загрузка формы - начальная настройка
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Устанавливаем текст приветствия
        lblGreeting.Text = "Чудов Константин Александрович / Корзинин Михаил Андреевич" & vbCrLf &
                           "Группа 434" & vbCrLf &
                           "Лабораторная работа N2" & vbCrLf &
                           "Вариант 11" & vbCrLf &
                           "Цель работы:" & vbCrLf &
                           "Разработка программы сортировки при помощи способа быстрой сортировки (QuickSort)." & vbCrLf &
                           "=========================================================================="

        ' Начальная настройка видимости панелей ввода
        UpdateInputMode()
    End Sub

    ' Обновление интерфейса при смене режима ввода
    Private Sub RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles rbManualInput.CheckedChanged, rbRandomGenerate.CheckedChanged
        UpdateInputMode()
    End Sub

    Private Sub UpdateInputMode()
        If rbManualInput.Checked Then
            gbManualInput.Visible = True
            gbRandomGenerate.Visible = False
        Else ' rbRandomGenerate.Checked
            gbManualInput.Visible = False
            gbRandomGenerate.Visible = True
        End If
        ' Сбрасываем массивы и кнопки при смене режима
        ClearArraysAndResults()
    End Sub

    ' Очистка массивов и полей вывода
    Private Sub ClearArraysAndResults()
        originalArray.Clear()
        sortedArray.Clear()
        txtOriginalArray.Text = ""
        txtSortedArray.Text = ""
        btnSort.Enabled = False
        btnSave.Enabled = False
    End Sub

    ' Кнопка "Создать массив" (ручной ввод)
    Private Sub btnSubmitManual_Click(sender As Object, e As EventArgs) Handles btnSubmitManual.Click
        ClearArraysAndResults()
        Dim size As Integer = CInt(nudArraySize.Value)
        Dim elementsText As String = txtManualInput.Text.Trim()
        Dim elementStrings As String() = elementsText.Split(New Char() {" ", vbCrLf, vbTab}, StringSplitOptions.RemoveEmptyEntries)

        If elementStrings.Length <> size Then
            MessageBox.Show($"Ожидалось {size} элементов, но введено {elementStrings.Length}. Пожалуйста, введите корректное количество элементов.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim tempArray As New List(Of Integer)()
        For Each strElement As String In elementStrings
            Dim element As Integer
            If Integer.TryParse(strElement, element) Then
                tempArray.Add(element)
            Else
                MessageBox.Show($"Ошибка при чтении элемента '{strElement}'. Пожалуйста, вводите только целые числа.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return ' Прерываем, если есть ошибка
            End If
        Next

        originalArray = tempArray
        DisplayArray(originalArray, txtOriginalArray)
        btnSort.Enabled = True ' Разрешаем сортировку
    End Sub

    ' Кнопка "Сгенерировать" (случайный массив)
    Private Sub btnGenerateRandom_Click(sender As Object, e As EventArgs) Handles btnGenerateRandom.Click
        ClearArraysAndResults()
        Dim size As Integer = randomGenerator.Next(1, 201) ' Размер от 1 до 200 включительно
        Dim tempArray As New List(Of Integer)()

        For i As Integer = 1 To size
            tempArray.Add(randomGenerator.Next(-1000, 1001)) ' Элементы от -1000 до 1000 включительно
        Next

        originalArray = tempArray
        DisplayArray(originalArray, txtOriginalArray)
        btnSort.Enabled = True ' Разрешаем сортировку
    End Sub

    ' Кнопка "Сортировать"
    Private Sub btnSort_Click(sender As Object, e As EventArgs) Handles btnSort.Click
        If originalArray Is Nothing OrElse originalArray.Count = 0 Then
            MessageBox.Show("Сначала создайте или сгенерируйте массив.", "Нет данных", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Копируем оригинальный массив, чтобы не изменять его
        Dim arrayToSort As New List(Of Integer)(originalArray)

        ' Выполняем сортировку
        sortedArray = Algorithm.QuickSort(arrayToSort)

        ' Отображаем результат
        DisplayArray(sortedArray, txtSortedArray)
        btnSave.Enabled = True ' Разрешаем сохранение
    End Sub

    ' Кнопка "Сохранить отсортированный..."
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If sortedArray Is Nothing OrElse sortedArray.Count = 0 Then
            MessageBox.Show("Нет отсортированного массива для сохранения.", "Нет данных", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Показываем диалог сохранения файла
        If sfdSaveArray.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = sfdSaveArray.FileName
            Try
                ' Используем StreamWriter для записи в файл с указанием кодировки (UTF-8 по умолчанию)
                Using writer As New StreamWriter(filePath, False) ' False означает перезапись файла, если он существует
                    ' Записываем размер массива
                    writer.WriteLine(sortedArray.Count)
                    ' Записываем элементы массива через пробел в одной строке
                    writer.WriteLine(String.Join(" ", sortedArray))
                End Using

                MessageBox.Show($"Массив успешно сохранен в файл:{vbCrLf}{filePath}", "Сохранение завершено", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show($"Ошибка при сохранении файла:{vbCrLf}{ex.Message}", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' Кнопка "Выход"
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close() ' Закрыть текущую форму (и приложение, если это главная форма)
    End Sub

    ' Вспомогательная функция для отображения массива в TextBox
    Private Sub DisplayArray(arr As List(Of Integer), displayTextBox As TextBox)
        If arr Is Nothing OrElse arr.Count = 0 Then
            displayTextBox.Text = "(пусто)"
        Else
            ' Преобразуем список в строку с элементами через пробел
            displayTextBox.Text = String.Join(" ", arr)
        End If
    End Sub

End Class