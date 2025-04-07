Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Diagnostics
Imports System.Collections.Generic
Imports SourceGUI
Imports System.Data.SQLite

<TestClass()>
Public Class DatabaseTests

    ' --- Вспомогательные функции ---

    ' Функция для генерации случайного массива целых чисел
    Private Function GenerateRandomArray(size As Integer) As List(Of Integer)
        Dim rand As New Random()
        Dim arr As New List(Of Integer)()
        For i As Integer = 1 To size
            arr.Add(rand.Next(-1000, 1001)) ' Генерация чисел от -1000 до 1000
        Next
        Return arr
    End Function

    ' Функция для преобразования массива в строку
    Private Function ArrayToString(arr As List(Of Integer)) As String
        Return String.Join(",", arr)
    End Function

    ' --- Тесты ---

    <TestMethod()>
    Public Sub Test_Add_100_Arrays()
        ' Arrange
        Dim testCount As Integer = 100
        Dim watch As Stopwatch = Stopwatch.StartNew()

        ' Act
        Dim successCount As Integer = 0
        For i As Integer = 1 To testCount
            Dim arraySize As Integer = New Random().Next(10, 50) ' Случайный размер массива от 10 до 50
            Dim originalArray As List(Of Integer) = GenerateRandomArray(arraySize)
            Dim sortedArray As List(Of Integer) = GenerateRandomArray(arraySize) ' Для теста не важно, что это "отсортированный"

            If DatabaseHelper.SaveSortResult(originalArray, sortedArray) Then
                successCount += 1
            End If
        Next
        watch.Stop()

        ' Assert
        Assert.AreEqual(testCount, successCount, $"Не все массивы были успешно добавлены. Успешно добавлено: {successCount}/{testCount}")
        Console.WriteLine($"Тест добавления 100 массивов: Успех - {successCount = testCount}, Время выполнения - {watch.ElapsedMilliseconds} мс")
    End Sub

    <TestMethod()>
    Public Sub Test_Add_1000_Arrays()
        ' Arrange
        Dim testCount As Integer = 1000
        Dim watch As Stopwatch = Stopwatch.StartNew()

        ' Act
        Dim successCount As Integer = 0
        For i As Integer = 1 To testCount
            Dim arraySize As Integer = New Random().Next(10, 50)
            Dim originalArray As List(Of Integer) = GenerateRandomArray(arraySize)
            Dim sortedArray As List(Of Integer) = GenerateRandomArray(arraySize)

            If DatabaseHelper.SaveSortResult(originalArray, sortedArray) Then
                successCount += 1
            End If
        Next
        watch.Stop()

        ' Assert
        Assert.AreEqual(testCount, successCount, $"Не все массивы были успешно добавлены. Успешно добавлено: {successCount}/{testCount}")
        Console.WriteLine($"Тест добавления 1000 массивов: Успех - {successCount = testCount}, Время выполнения - {watch.ElapsedMilliseconds} мс")
    End Sub

    <TestMethod()>
    Public Sub Test_Add_10000_Arrays()
        ' Arrange
        Dim testCount As Integer = 10000
        Dim watch As Stopwatch = Stopwatch.StartNew()

        ' Act
        Dim successCount As Integer = 0
        For i As Integer = 1 To testCount
            Dim arraySize As Integer = New Random().Next(10, 50)
            Dim originalArray As List(Of Integer) = GenerateRandomArray(arraySize)
            Dim sortedArray As List(Of Integer) = GenerateRandomArray(arraySize)

            If DatabaseHelper.SaveSortResult(originalArray, sortedArray) Then
                successCount += 1
            End If
        Next
        watch.Stop()

        ' Assert
        Assert.AreEqual(testCount, successCount, $"Не все массивы были успешно добавлены. Успешно добавлено: {successCount}/{testCount}")
        Console.WriteLine($"Тест добавления 10000 массивов: Успех - {successCount = testCount}, Время выполнения - {watch.ElapsedMilliseconds} мс")
    End Sub

    <TestMethod()>
    Public Sub Test_Load_And_Sort_100_Random_Arrays()
        ' Arrange
        Dim testCount As Integer = 100
        Dim watch As Stopwatch = Stopwatch.StartNew()
        Dim totalSortTime As Double = 0

        ' Act
        Dim successCount As Integer = 0
        For i As Integer = 1 To testCount
            ' 1.  Получить случайный ID (предполагаем, что у вас есть функция для этого в DatabaseHelper)
            Dim randomId As Integer = GetRandomIdFromDatabase() ' !!!  Нужно реализовать GetRandomIdFromDatabase !!!
            If randomId = -1 Then ' Предположим, что -1 означает ошибку получения ID
                Continue For ' Переходим к следующей итерации, если не удалось получить ID
            End If

            ' 2.  Загрузить данные по ID
            Dim loadedData As Tuple(Of List(Of Integer), List(Of Integer)) = DatabaseHelper.LoadSortResultById(randomId)

            If loadedData IsNot Nothing Then
                ' 3.  Сортировка
                Dim sortWatch As Stopwatch = Stopwatch.StartNew()
                Dim sortedArray As List(Of Integer) = Algorithm.QuickSort(New List(Of Integer)(loadedData.Item1)) ' Сортируем исходный массив
                sortWatch.Stop()
                totalSortTime += sortWatch.ElapsedMilliseconds

                ' 4.  Проверка (простая проверка на "не Null" для примера)
                If sortedArray IsNot Nothing Then
                    successCount += 1
                End If
            End If
        Next
        watch.Stop()

        ' Assert
        Assert.AreEqual(testCount, successCount, $"Не все массивы были успешно загружены и отсортированы. Успешно: {successCount}/{testCount}")
        Dim avgSortTime As Double = If(testCount > 0, totalSortTime / testCount, 0)
        Console.WriteLine($"Тест загрузки и сортировки 100 массивов: Успех - {successCount = testCount}, Общее время - {watch.ElapsedMilliseconds} мс, Среднее время сортировки - {avgSortTime} мс")
    End Sub

    <TestMethod()>
    Public Sub Test_Clear_Database()
        ' Arrange
        Dim watch As Stopwatch = Stopwatch.StartNew()

        ' Act
        Dim success As Boolean = ClearDatabase() ' !!! Нужно реализовать ClearDatabase !!!
        watch.Stop()

        ' Assert
        Assert.IsTrue(success, "Не удалось очистить базу данных.")
        Console.WriteLine($"Тест очистки базы данных: Успех - {success}, Время выполнения - {watch.ElapsedMilliseconds} мс")
    End Sub

    ' --- Функции, которые вам нужно добавить в DatabaseHelper ---

    '  !!!  ВАЖНО:  Эти функции нужно реализовать в модуле DatabaseHelper  !!!

    ''' <summary>
    '''  Получает случайный ID из таблицы SortHistory.
    ''' </summary>
    ''' <returns>Случайный ID или -1, если произошла ошибка или таблица пуста.</returns>
    Public Function GetRandomIdFromDatabase() As Integer
        Dim randomId As Integer = -1
        Dim connectionString = GetConnectionString()

        Try
            Using conn As New SQLiteConnection(connectionString)
                conn.Open()
                Dim sql As String = "SELECT ID FROM SortHistory ORDER BY RANDOM() LIMIT 1"
                Using cmd As New SQLiteCommand(sql, conn)
                    Dim reader As SQLiteDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        If Not IsDBNull(reader("ID")) Then
                            Integer.TryParse(reader("ID").ToString(), randomId)
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            LogError("Ошибка при получении случайного ID.", ex)
        End Try

        Return randomId
    End Function

    ''' <summary>
    '''  Очищает все данные из таблицы SortHistory.
    ''' </summary>
    ''' <returns>True, если очистка прошла успешно, иначе False.</returns>
    Public Function ClearDatabase() As Boolean
        Dim connectionString = GetConnectionString()

        Try
            Using conn As New SQLiteConnection(connectionString)
                conn.Open()
                Dim sql As String = "DELETE FROM SortHistory"
                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            LogError("Ошибка при очистке базы данных.", ex)
            Return False
        End Try
    End Function

End Class