using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.Sqlite;
using System.IO;


namespace SourceGUI
{
    /// <summary>
    /// Представляет полные данные одной записи истории сортировки. Упрщеннные форматы для удобства ввода/вывода
    /// </summary>
    public class MainTableMetadata
    {
        public long ID { get; set; }
        public string Timestamp { get; set; } = string.Empty;
        public string Original { get; set; } = string.Empty;
        public string Sorted { get; set; } = string.Empty;
    }

    /// <summary>
    /// Представляет полные данные одной записи истории сортировки. Системные форматы для корректности данных
    /// </summary>
    public class MainTableEntry
    {
        public long ID { get; set; }
        public DateTime Timestamp { get; set; }
        public List<int> OriginalArray { get; set; } = new List<int>();
        public List<int> SortedArray { get; set; } = new List<int>();
    }


    /// <summary>
    /// Статический класс для работы с базой данных SQLite (MainDB.sqlite).
    /// </summary>
    public static class DatabaseHelper
    {
        private static string dbFileName = "MainDB.sqlite";

        /// <summary>
        /// Получает полный путь к файлу базы данных.
        /// БД располагается в директории запуска приложения.
        /// </summary>
        public static string GetDatabasePath()
        {
            return Path.Combine(AppContext.BaseDirectory, dbFileName);
        }

        /// <summary>
        /// Формирует строку подключения к SQLite.
        /// </summary>
        private static string GetConnectionString()
        {
            return $"Data Source={GetDatabasePath()}";
        }

        /// <summary>
        /// Гарантирует, что файл БД и таблица 'MainTable' существуют.
        /// Создает их при необходимости.
        /// </summary>
        /// <returns>True, если инициализация прошла успешно, иначе False.</returns>
        public static bool InitializeDatabase()
        {
            string sql = @"
                CREATE TABLE IF NOT EXISTS MainTable (
                    ID            INTEGER PRIMARY KEY,
                    Timestamp     TEXT NOT NULL,
                    OriginalArray TEXT NULL,
                    SortedArray   TEXT NULL
                );";

            try
            {
                using (var connection = new SqliteConnection(GetConnectionString()))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = sql;
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка инициализации БД: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Сохраняет результат сортировки в базу данных.
        /// </summary>
        /// <param name="originalArray">Исходный массив.</param>
        /// <param name="sortedArray">Отсортированный массив.</param>
        /// <returns>True при успехе, иначе False.</returns>
        public static bool SaveSortResult(List<int> originalArray, List<int> sortedArray)
        {
            if (originalArray == null || sortedArray == null) return false;

            string originalStr = string.Join(",", originalArray);
            string sortedStr = string.Join(",", sortedArray);
            string timestampStr = DateTime.UtcNow.ToString("o");
            string sql = @"INSERT INTO MainTable (ID, Timestamp, OriginalArray, SortedArray) VALUES (@ID, @Timestamp, @Original, @Sorted)";

            try
            {
                using (var connection = new SqliteConnection(GetConnectionString()))
                {
                    connection.Open();

                    // 1. Get the next ID
                    long nextId = 1; // Default ID for the first record
                    using (var command = new SqliteCommand("SELECT MAX(ID) FROM MainTable", connection))
                    {
                        object? result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            nextId = Convert.ToInt64(result) + 1;
                        }
                    }

                    // 2. Insert the new record
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = sql;
                        command.Parameters.AddWithValue("@ID", nextId);
                        command.Parameters.AddWithValue("@Timestamp", timestampStr);
                        command.Parameters.AddWithValue("@Original", (object?)originalStr ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Sorted", (object?)sortedStr ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сохранения в БД: {ex.Message}");
                return false;
            }
        }


        /// <summary>
        /// Получает метаданные всех записей истории для отображения в гриде.
        /// </summary>
        /// <returns>Список метаданных или пустой список при ошибке/отсутствии данных.</returns>
        public static List<MainTableMetadata> GetAllMainTableMetadata()
        {
            var historyList = new List<MainTableMetadata>();
            string sql = "SELECT * FROM MainTable ORDER BY Timestamp DESC"; // Сортируем по убыванию даты

            try
            {
                using (var connection = new SqliteConnection(GetConnectionString()))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = sql;
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string timestampStr = reader.GetString(1);
                                DateTime timestamp = DateTime.Parse(timestampStr).ToLocalTime();
                                string formattedTimestamp = timestamp.ToString("yyyy-MM-dd HH:mm:ss");

                                historyList.Add(new MainTableMetadata
                                {
                                    ID = reader.GetInt64(0), // ID - INTEGER PRIMARY KEY -> long
                                    Timestamp = formattedTimestamp,
                                    Original = reader.GetString(2),
                                    Sorted = reader.GetString(3),
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения истории из БД: {ex.Message}");
                // Возвращаем пустой список в случае ошибки
            }
            return historyList;
        }

        /// <summary>
        /// Загружает полную запись истории (с массивами) по её ID.
        /// </summary>
        /// <param name="id">ID записи.</param>
        /// <returns>Объект MainTableEntry или null, если запись не найдена или произошла ошибка.</returns>
        public static MainTableEntry? GetSortResultById(long id)
        {
            MainTableEntry? entry = null;
            string sql = "SELECT Timestamp, OriginalArray, SortedArray FROM MainTable WHERE ID = @ID";

            try
            {
                using (var connection = new SqliteConnection(GetConnectionString()))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = sql;
                        command.Parameters.AddWithValue("@ID", id);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string timestampStr = reader.GetString(0);
                                string originalStr = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                                string sortedStr = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);

                                entry = new MainTableEntry
                                {
                                    ID = id,
                                    Timestamp = DateTime.Parse(timestampStr).ToLocalTime(), // Преобразуем в DateTime
                                    OriginalArray = ParseIntListFromString(originalStr),
                                    SortedArray = ParseIntListFromString(sortedStr)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки записи {id} из БД: {ex.Message}");
            }
            return entry;
        }

        /// <summary>
        /// Обновляет существующую запись в базе данных.
        /// </summary>
        /// <param name="id">ID записи для обновления.</param>
        /// <param name="originalArray">Новый исходный массив.</param>
        /// <param name="sortedArray">Новый отсортированный массив.</param>
        /// <returns>True при успехе, иначе False.</returns>
        public static bool UpdateSortResult(long id, List<int> originalArray, List<int> sortedArray)
        {
            if (originalArray == null || sortedArray == null) return false;

            string originalStr = string.Join(",", originalArray);
            string sortedStr = string.Join(",", sortedArray);
            // Можно обновить и Timestamp, если это требуется по логике
            string timestampStr = DateTime.UtcNow.ToString("o");

            string sql = @"
                UPDATE MainTable
                SET Timestamp = @Timestamp,
                    OriginalArray = @Original,
                    SortedArray = @Sorted
                WHERE ID = @ID";

            try
            {
                using (var connection = new SqliteConnection(GetConnectionString()))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = sql;
                        command.Parameters.AddWithValue("@Timestamp", timestampStr);
                        command.Parameters.AddWithValue("@Original", (object?)originalStr ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Sorted", (object?)sortedStr ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ID", id);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0; // Успех, если хотя бы одна строка была обновлена
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка обновления записи {id} в БД: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Вспомогательный метод для парсинга строки с числами через запятую в список int.
        /// </summary>
        private static List<int> ParseIntListFromString(string? data)
        {
            var list = new List<int>();
            if (string.IsNullOrWhiteSpace(data))
            {
                return list; // Возвращаем пустой список, если строка пуста или null
            }

            string[] parts = data.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string part in parts)
            {
                if (int.TryParse(part.Trim(), out int number))
                {
                    list.Add(number);
                }
                else
                {
                    Console.WriteLine($"Предупреждение: не удалось распарсить элемент '{part}' в число.");
                }
            }
            return list;
        }

        /// <summary>
        /// Получает одну случайную полную запись из истории.
        /// </summary>
        /// <returns>Объект MainTableEntry или null, если таблица пуста или произошла ошибка.</returns>
        public static MainTableEntry? GetRandomSortResult()
        {
            MainTableEntry? entry = null;
            // Используем ORDER BY RANDOM() LIMIT 1 для получения случайной строки в SQLite
            string sql = "SELECT ID, Timestamp, OriginalArray, SortedArray FROM MainTable ORDER BY RANDOM() LIMIT 1";

            try
            {
                using (var connection = new SqliteConnection(GetConnectionString()))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = sql;

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Если запись найдена
                            {
                                long id = reader.GetInt64(0);
                                string timestampStr = reader.GetString(1);
                                string originalStr = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                                string sortedStr = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);

                                entry = new MainTableEntry
                                {
                                    ID = id,
                                    Timestamp = DateTime.Parse(timestampStr).ToLocalTime(),
                                    OriginalArray = ParseIntListFromString(originalStr),
                                    SortedArray = ParseIntListFromString(sortedStr)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка получения случайной записи из БД: {ex.Message}");
                // Возвращаем null в случае ошибки
            }
            return entry;
        }

        /// <summary>
        /// Получает количество записей в таблице MainTable.
        /// </summary>
        /// <returns>Количество записей или -1 при ошибке.</returns>
        public static long GetHistoryCount()
        {
            string sql = "SELECT COUNT(*) FROM MainTable";
            try
            {
                 using (var connection = new SqliteConnection(GetConnectionString()))
                 {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = sql;
                        // ExecuteScalar возвращает первое поле первой строки (или null)
                        object? result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToInt64(result);
                        }
                    }
                 }
                 return 0; // Если таблица пуста, COUNT вернет 0
            }
            catch (Exception ex)
            {
                 Console.WriteLine($"Ошибка получения количества записей из БД: {ex.Message}");
                 return -1; // Признак ошибки
            }
        }

        public static bool DeleteSortResult(long id)
        {
            string deleteSql = "DELETE FROM MainTable WHERE ID = @Id;";
            string updateSql = "UPDATE MainTable SET ID = ID - 1 WHERE ID > @Id;";
            try
            {
                using (var connection = new SqliteConnection(GetConnectionString()))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction()) // Используем транзакцию для целостности
                    {
                        using (var deleteCommand = new SqliteCommand(deleteSql, connection, transaction))
                        {
                            deleteCommand.Parameters.AddWithValue("@Id", id);
                            deleteCommand.ExecuteNonQuery();
                        }
                        using (var updateCommand = new SqliteCommand(updateSql, connection, transaction))
                        {
                            updateCommand.Parameters.AddWithValue("@Id", id);
                            updateCommand.ExecuteNonQuery();
                        }

                        transaction.Commit(); // Подтверждаем транзакцию, если обе операции прошли успешно
                    }
                    connection.Close(); // Явно закрываем соединение
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении записи с ID={id}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Проверяет доступность соединения с БД.
        /// </summary>
        /// <returns>True, если соединение успешно открыто и закрыто.</returns>
        public static bool CheckDbConnection()
        {
            try
            {
                 using (var connection = new SqliteConnection(GetConnectionString()))
                 {
                     connection.Open();
                     return true; // Соединение успешно
                 }
            }
            catch (Exception)
            {
                 return false; // Ошибка соединения
            }
        }
    }
}
