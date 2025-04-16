using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security;
using SourceGUI; // Пространство имен вашего проекта

public class DatabaseTests
{
    // Функция для генерации случайных массивов
    static List<int> GenerateRandomArray(int size)
    {
        Random rand = new Random();
        List<int> arr = new List<int>();
        for (int i = 0; i < size; i++)
        {
            arr.Add(rand.Next(-1000, 1001)); // Генерация чисел от -1000 до 1000
        }
        return arr;
    }

    // Тест a, b, c: Добавление массивов в БД
    static void TestAddArrays(int numberOfArrays)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        bool success = true;
        for (int i = 0; i < numberOfArrays; i++)
        {
            List<int> randomArray = GenerateRandomArray(new Random().Next(10, 50)); // Случайный размер массива от 10 до 50
            bool saved = DatabaseHelper.SaveSortResult(randomArray, SortAlgorithm.QuickSort(new List<int>(randomArray))); // Сортируем копию массива
            if (!saved)
            {
                success = false;
            }
        }

        stopwatch.Stop();
        TimeSpan ts = stopwatch.Elapsed;
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

        Console.WriteLine($"Тест добавления {numberOfArrays} массивов: " + (success ? "Успех" : "Провал") + ", Время: " + elapsedTime);
    }

    static void TestFetchAndSortRandomArrays(int numberOfArrays)
    {
        Stopwatch totalStopwatch = new Stopwatch();
        totalStopwatch.Start();

        bool success = true;
        List<long> randomIds = new List<long>();
        long historyCount = DatabaseHelper.GetHistoryCount();
        if (historyCount <= 0)
        {
            Console.WriteLine("База данных пуста, невозможно выполнить тест выгрузки.");
            return;
        }

        Random rand = new Random();
        for (int i = 0; i < 100; i++) // Выгружаем 100 случайных массивов
        {
            long randomId = rand.Next(1, (int)historyCount + 1);
            randomIds.Add(randomId);
        }

        List<TimeSpan> individualTimes = new List<TimeSpan>();

        foreach (long id in randomIds)
        {
            Stopwatch individualStopwatch = new Stopwatch();
            individualStopwatch.Start();

            MainTableEntry? entry = DatabaseHelper.GetSortResultById(id);
            if (entry == null)
            {
                success = false;
                break;
            }

            // Сортировка массива
            List<int> sortedArray = SortAlgorithm.QuickSort(entry.OriginalArray);

            // Обновление записи в базе данных
            bool updated = DatabaseHelper.UpdateSortResult(entry.ID, entry.OriginalArray, sortedArray);
            if (!updated)
            {
                success = false;
                Console.WriteLine($"Не удалось обновить запись с ID: {entry.ID}");
                break;
            }

            individualStopwatch.Stop();
            individualTimes.Add(individualStopwatch.Elapsed);
        }

        totalStopwatch.Stop();
        TimeSpan totalTs = totalStopwatch.Elapsed;
        string totalElapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", totalTs.Hours, totalTs.Minutes, totalTs.Seconds, totalTs.Milliseconds / 10);

        double averageTicks = individualTimes.Average(t => t.Ticks);
        TimeSpan averageTime = TimeSpan.FromTicks((long)averageTicks);
        string averageTimeString = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", averageTime.Hours, averageTime.Minutes, averageTime.Seconds, averageTime.Milliseconds / 10);

        Console.WriteLine($"Тест выгрузки, сортировки и обновления 100 массивов из базы с {numberOfArrays} записями: " + (success ? "Успех" : "Провал") +
                          ", Общее время: " + totalElapsedTime + ", Среднее время на массив: " + averageTimeString);
    }

    // Тест e: Очистка базы данных
    static void TestClearDatabase(int numberOfArrays)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        bool success = true;
        long historyCount = DatabaseHelper.GetHistoryCount();
        if (historyCount <= 0)
        {
            Console.WriteLine("База данных уже пуста.");
            return;
        }

        for (int i = (int)historyCount; i >= 1; i--) // Удаляем в обратном порядке
        {
            bool deleted = DatabaseHelper.DeleteSortResult(i);
            if (!deleted)
            {
                success = false;
            }
        }

        stopwatch.Stop();
        TimeSpan ts = stopwatch.Elapsed;
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

        Console.WriteLine($"Тест очистки базы данных ({numberOfArrays} записей): " + (success ? "Успех" : "Провал") + ", Время: " + elapsedTime);
    }

    static void Main(string[] args)
    {
        // Инициализация БД
        DatabaseHelper.InitializeDatabase();

        TestAddArrays(100);
        TestFetchAndSortRandomArrays(100);
        TestClearDatabase(100);

        TestAddArrays(1000);
        TestFetchAndSortRandomArrays(1000);
        TestClearDatabase(1000);

        TestAddArrays(10000);
        TestFetchAndSortRandomArrays(10000);
        TestClearDatabase(10000);
    }
}