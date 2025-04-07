Imports System.IO
Imports System.Windows.Forms.VisualStyles ' Для работы с файлами

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
        If Not DatabaseHelper.EnsureTableExists() Then
            MessageBox.Show("Не удалось инициализировать базу данных. Данные невозможно сохранить.", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            btnSaveDB.Visible = False ' заблокировать кнопку сохранения в БД
        End If
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
        btnSaveDB.Enabled = False
        btnSaveFile.Enabled = False
    End Sub

    ' Кнопка "Создать массив" (ручной ввод)
    Private Sub btnSubmitManual_Click(sender As Object, e As EventArgs) Handles btnSubmitManual.Click
        ClearArraysAndResults()
        Dim elementsText As String = txtManualInput.Text.Trim()
        Dim elementStrings As String() = elementsText.Split(New Char() {" ", vbCrLf, vbTab}, StringSplitOptions.RemoveEmptyEntries)

        If elementStrings.Length < 1 Then
            MessageBox.Show($"Размер массива не может быть меньше 1. Пожалуйста, введите корректное количество элементов.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
        btnSaveDB.Enabled = True
        btnSaveFile.Enabled = True ' Разрешаем сохранение
    End Sub

    ' Кнопка "Сохранить отсортированный..."
    Private Sub btnSaveFile_Click(sender As Object, e As EventArgs) Handles btnSaveFile.Click
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

    Private Sub btnSaveDB_Click(sender As Object, e As EventArgs) Handles btnSaveDB.Click
        If sortedArray IsNot Nothing AndAlso sortedArray.Count > 0 Then ' Убедимся, что есть что сохранять
            If DatabaseHelper.SaveSortResult(originalArray, sortedArray) Then
                MessageBox.Show("Результаты успешно сохранены в базу данных.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Не удалось сохранить результаты в базу данных.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Нет данных для сохранения.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnOpenDatabase_Click(sender As Object, e As EventArgs) Handles btnOpenDatabase.Click
        ' Используем Using для автоматического освобождения ресурсов формы истории
        Using historyForm As New FormHistory()

            ' Открываем форму истории как модальное диалоговое окно
            ' Это означает, что пользователь не сможет взаимодействовать с Form1, пока FormHistory открыта
            Dim result As DialogResult = historyForm.ShowDialog(Me) ' Me - указываем владельца окна

            ' Проверяем, закрыл ли пользователь форму нажатием "Загрузить выбранное"
            If result = DialogResult.OK Then
                ' Получаем загруженные данные из публичных свойств historyForm
                Dim loadedOriginal As List(Of Integer) = historyForm.LoadedOriginalArray
                Dim loadedSorted As List(Of Integer) = historyForm.LoadedSortedArray

                ' Проверяем, что данные действительно были загружены (на всякий случай)
                If loadedOriginal IsNot Nothing AndAlso loadedSorted IsNot Nothing Then
                    ' Присваиваем загруженные данные массивам текущей формы
                    originalArray = loadedOriginal
                    sortedArray = loadedSorted

                    ' Отображаем загруженные массивы в текстовых полях
                    DisplayArray(originalArray, txtOriginalArray)
                    DisplayArray(sortedArray, txtSortedArray)
                    DisplayArray(originalArray, txtManualInput)

                    If rbRandomGenerate.Checked Then
                        rbRandomGenerate.Checked = False
                        rbManualInput.Checked = True
                        gbManualInput.Visible = True
                        gbRandomGenerate.Visible = False
                    End If

                    ' Разрешаем действия с загруженными данными
                    btnSort.Enabled = (originalArray.Count > 0)
                    btnSaveDB.Enabled = (sortedArray.Count > 0) ' Уже сохранены, но можно разрешить пересохранение
                    btnSaveFile.Enabled = (sortedArray.Count > 0)

                    MessageBox.Show("Данные из базы успешно загружены.", "Загрузка завершена", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    ' Это не должно произойти, если DialogResult = OK, но лучше проверить
                    MessageBox.Show("Произошла внутренняя ошибка при передаче данных из формы истории.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ClearArraysAndResults() ' Очищаем поля в случае ошибки
                End If
            Else
                ' Пользователь закрыл форму истории кнопкой "Закрыть" или крестиком (DialogResult будет Cancel или None)
                ' Ничего не делаем, просто возвращаемся к Form1
            End If

        End Using ' historyForm будет автоматически уничтожена здесь (Dispose)
    End Sub
End Class