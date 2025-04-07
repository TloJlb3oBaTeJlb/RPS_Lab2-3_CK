Imports System.Data.SQLite
Imports System.IO
Imports System.Runtime.CompilerServices ' Для удобства логирования
Imports System.Data

Public Module DatabaseHelper

    ' Имя файла базы данных
    Private Const dbFileName As String = "SortHistory.sqlite"

    ' Функция для получения полного пути к файлу БД
    ' Размещает БД в той же папке, где находится .exe файл приложения
    Private Function GetDatabasePath() As String
        'Dim executablePath As String = Application.StartupPath
        'Dim projectDirectory As String = Directory.GetParent(executablePath).Parent.FullName
        Return Path.Combine(Application.StartupPath, dbFileName)
    End Function

    ' Функция для получения строки подключения
    Public Function GetConnectionString() As String
        ' Строка подключения для System.Data.SQLite
        Return $"Data Source={GetDatabasePath()}"
    End Function

    ''' <summary>
    ''' Проверяет, существует ли файл базы данных SQLite по ожидаемому пути.
    ''' </summary>
    ''' <returns>True, если файл существует, иначе False.</returns>
    ''' <remarks>
    ''' Фактическое создание файла БД обычно происходит автоматически при первом открытии соединения
    ''' (например, в функции EnsureTableExists). Эта функция полезна для проверки перед соединением.
    ''' </remarks>
    Public Function DatabaseFileExists() As Boolean
        Dim dbPath As String = GetDatabasePath()
        Try
            Return File.Exists(dbPath)
        Catch ex As Exception
            LogError($"Ошибка при проверке существования файла БД по пути '{dbPath}'.", ex)
            ' В случае ошибки проверки считаем, что файла нет (или обрабатываем иначе)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Гарантирует, что таблица 'SortHistory' существует в базе данных.
    ''' Создает файл БД (если отсутствует) и таблицу (если отсутствует).
    ''' Эту функцию рекомендуется вызывать один раз при запуске приложения.
    ''' </summary>
    ''' <returns>True, если файл и таблица существуют или были успешно созданы, иначе False.</returns>
    Public Function EnsureTableExists() As Boolean
        Dim dbPath As String = GetDatabasePath() ' Получаем путь для логирования
        Dim fileExistedBeforeConnect As Boolean = DatabaseFileExists() ' Проверяем до соединения

        ' SQL запрос для создания таблицы, если она еще не существует
        Dim sql As String = "CREATE TABLE IF NOT EXISTS SortHistory (" &
                            "ID INTEGER PRIMARY KEY AUTOINCREMENT, " &
                            "Timestamp TEXT NOT NULL, " &
                            "OriginalArray TEXT NULL, " &
                            "SortedArray TEXT NULL);"

        Dim connectionString = GetConnectionString()
        Try
            ' Используем Using для автоматического закрытия и освобождения ресурсов
            Using conn As New SqliteConnection(connectionString)
                ' !!! Вот здесь происходит неявное создание файла БД, если его не было !!!
                conn.Open() ' Открываем соединение

                ' Логируем, если файл был только что создан
                If Not fileExistedBeforeConnect AndAlso File.Exists(dbPath) Then
                    LogInfo($"Файл базы данных '{dbPath}' не найден и был создан.")
                End If

                ' Теперь создаем таблицу в (возможно, только что созданном) файле
                Using cmd As New SqliteCommand(sql, conn)
                    cmd.ExecuteNonQuery() ' Выполняем команду создания таблицы
                End Using ' cmd освобождается
            End Using ' conn закрывается и освобождается
            Return True ' Успех
        Catch ex As Exception
            LogError("Ошибка при проверке/создании таблицы SortHistory.", ex)
            Return False ' Неудача
        End Try
    End Function

    ''' <summary>
    ''' Сохраняет исходный и отсортированный массивы в таблицу SortHistory.
    ''' </summary>
    ''' <param name="originalArray">Список целых чисел - исходный массив.</param>
    ''' <param name="sortedArray">Список целых чисел - отсортированный массив.</param>
    ''' <returns>True, если сохранение прошло успешно, иначе False.</returns>

    Public Function SaveSortResult(originalArray As List(Of Integer), sortedArray As List(Of Integer)) As Boolean
        If originalArray Is Nothing OrElse sortedArray Is Nothing Then
            LogError("Попытка сохранить пустые массивы (Nothing).")
            Return False
        End If

        ' Преобразуем списки в строки, разделенные запятыми
        Dim originalStr As String = String.Join(",", originalArray)
        Dim sortedStr As String = String.Join(",", sortedArray)
        ' Получаем текущее время и форматируем в стандарт ISO 8601 ("s")
        Dim timestampStr As String = DateTime.Now.ToString("s") ' Пример: "2025-04-07T01:27:00"

        ' SQL запрос для вставки данных с использованием параметров
        Dim sql As String = "INSERT INTO SortHistory (Timestamp, OriginalArray, SortedArray) VALUES (@Timestamp, @Original, @Sorted)"

        Dim connectionString = GetConnectionString()
        Try
            Using conn As New SQLiteConnection(connectionString)
                conn.Open()
                Using cmd As New SQLiteCommand(sql, conn)
                    ' Добавляем параметры. Это ВАЖНО для предотвращения SQL-инъекций!
                    cmd.Parameters.AddWithValue("@Timestamp", timestampStr)
                    cmd.Parameters.AddWithValue("@Original", originalStr)
                    cmd.Parameters.AddWithValue("@Sorted", sortedStr)

                    cmd.ExecuteNonQuery() ' Выполняем команду вставки
                End Using ' cmd освобождается
            End Using ' conn закрывается и освобождается
            Return True ' Успех
        Catch ex As Exception
            LogError("Ошибка при сохранении результатов сортировки в БД.", ex)
            Return False ' Неудача
        End Try
    End Function

    ''' <summary>
    '''  Получает все записи из истории сортировки, включая исходный и отсортированный массивы.
    ''' </summary>
    ''' <returns>DataTable содержащий все данные истории сортировки.</returns>
    Public Function GetAllSortHistoryData() As DataTable
        Dim historyData As New DataTable()
        Dim connectionString = GetConnectionString()

        Try
            Using conn As New SQLiteConnection(connectionString)
                conn.Open()
                ' Измененный SQL запрос для выбора всех столбцов
                Dim sql As String = "SELECT ID, Timestamp, OriginalArray, SortedArray FROM SortHistory"
                Using cmd As New SQLiteCommand(sql, conn)
                    Dim adapter As New SQLiteDataAdapter(cmd)
                    adapter.Fill(historyData)
                End Using
            End Using
        Catch ex As Exception
            LogError("Ошибка при получении данных истории сортировки.", ex)
            Return Nothing
        End Try
        Return historyData
    End Function

    ''' <summary>
    ''' Загружает исходный и отсортированный массивы для указанной записи ID.
    ''' </summary>
    ''' <param name="id">ID записи в таблице SortHistory.</param>
    ''' <returns>Кортеж (Tuple) с двумя списками List(Of Integer): (OriginalArray, SortedArray).
    ''' Возвращает Nothing, если запись не найдена или произошла ошибка.</returns>
    Public Function LoadSortResultById(id As Integer) As Tuple(Of List(Of Integer), List(Of Integer))
        Dim sql As String = "SELECT OriginalArray, SortedArray FROM SortHistory WHERE ID = @ID"
        Dim connectionString = GetConnectionString()
        Dim originalStr As String = Nothing
        Dim sortedStr As String = Nothing

        Try
            Using conn As New SQLiteConnection(connectionString)
                conn.Open()
                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@ID", id) ' Используем параметр для безопасности

                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        If reader.Read() Then ' Если запись найдена
                            ' Получаем строки, проверяя на DBNull
                            If Not reader.IsDBNull(0) Then originalStr = reader.GetString(0)
                            If Not reader.IsDBNull(1) Then sortedStr = reader.GetString(1)
                        Else
                            LogInfo($"Запись с ID={id} не найдена в SortHistory.")
                            Return Nothing ' Запись не найдена
                        End If
                    End Using ' reader освобождается
                End Using ' cmd освобождается
            End Using ' conn закрывается и освобождается

            ' Конвертируем строки обратно в списки
            Dim originalList As List(Of Integer) = ConvertStringToList(originalStr)
            Dim sortedList As List(Of Integer) = ConvertStringToList(sortedStr)

            ' Возвращаем результат в виде кортежа
            Return New Tuple(Of List(Of Integer), List(Of Integer))(originalList, sortedList)

        Catch ex As Exception
            LogError($"Ошибка при загрузке записи с ID={id} из БД.", ex)
            Return Nothing ' Возвращаем Nothing при ошибке
        End Try
    End Function

    ''' <summary>
    ''' Вспомогательная функция для конвертации строки с числами через запятую в List(Of Integer).
    ''' </summary>
    ''' <param name="arrayString">Строка с числами, разделенными запятыми.</param>
    ''' <returns>Список List(Of Integer) или пустой список, если строка пуста или содержит ошибки.</returns>
    Private Function ConvertStringToList(arrayString As String) As List(Of Integer)
        Dim resultList As New List(Of Integer)()
        If String.IsNullOrWhiteSpace(arrayString) Then
            Return resultList ' Возвращаем пустой список, если строка пустая
        End If

        Dim parts() As String = arrayString.Split(","c) ' Разделяем по запятой
        For Each part As String In parts
            Dim number As Integer
            If Integer.TryParse(part.Trim(), number) Then ' Пытаемся преобразовать каждую часть в число
                resultList.Add(number)
            Else
                ' Логируем ошибку, если часть строки не является числом, но продолжаем обработку остальных
                LogError($"Ошибка конвертации '{part}' в число при загрузке массива из строки '{arrayString}'. Элемент пропущен.")
                ' Можно выбрать другую стратегию: вернуть Nothing или выбросить исключение,
                ' но пропуск элемента может быть более устойчивым вариантом.
            End If
        Next
        Return resultList
    End Function

    ' --- Добавьте также эту функцию для информационных сообщений ---
    ' Простой вспомогательный метод для логирования информационных сообщений
    Private Sub LogInfo(message As String, <CallerMemberName> Optional memberName As String = "")
        Dim infoMsg As String = $"[{DateTime.Now:G}] [{memberName}] {message}"

        ' Выводим в окно Output в Visual Studio
        Console.WriteLine("--- INFO ---")
        Console.WriteLine(infoMsg)
        Console.WriteLine("------------")
    End Sub

    ' Простой вспомогательный метод для логирования ошибок (можно расширить)
    Public Sub LogError(message As String, Optional ex As Exception = Nothing, <CallerMemberName> Optional memberName As String = "")
        Dim errorMsg As String = $"[{DateTime.Now:G}] [{memberName}] {message}"
        If ex IsNot Nothing Then
            errorMsg &= $"{vbCrLf}   Exception: {ex.GetType().Name} - {ex.Message}"

            ' --- Добавлено: Логирование вложенных исключений ---
            Dim innerEx As Exception = ex.InnerException
            Dim level As Integer = 1
            While innerEx IsNot Nothing
                errorMsg &= $"{vbCrLf}   InnerException (Level {level}): {innerEx.GetType().Name} - {innerEx.Message}"
                ' При необходимости можно добавить и StackTrace для InnerException
                ' errorMsg &= $"{vbCrLf}      Inner StackTrace: {innerEx.StackTrace}"
                innerEx = innerEx.InnerException
                level += 1
            End While
            ' --- Конец добавленного кода ---

            ' Основной StackTrace может быть очень длинным, оставим его опциональным или уберем пока
            ' errorMsg &= $"{vbCrLf}   StackTrace: {ex.StackTrace}"
        End If

        Console.WriteLine("--- ERROR ---")
        Console.WriteLine(errorMsg)
        Console.WriteLine("-------------")

        ' MessageBox.Show(message & If(ex IsNot Nothing, vbCrLf & ex.Message, ""), "Ошибка Базы Данных", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

End Module