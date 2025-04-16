using System;
using System.Collections.Generic;
using System.Linq;

namespace SourceGUI
{
    /// <summary>
    /// Содержит реализацию алгоритма быстрой сортировки (QuickSort).
     /// </summary>
    public static class SortAlgorithm
    {
        /// <summary>
        /// Сортирует список целых чисел с использованием алгоритма QuickSort.
        /// </summary>
        public static List<int> QuickSort(List<int> list)
        {
            // Базовый случай рекурсии: пустой список или список из одного элемента уже отсортирован.
            if (list == null || list.Count <= 1)
            {
                return list ?? new List<int>(); // Возвращаем копию или новый пустой список, если исходный был null
            }

            // Выбираем опорный элемент (pivot)
            int pivotIndex = list.Count / 2;
            int pivotValue = list[pivotIndex];

            // Создаем списки для элементов меньше, равных и больше опорного.
            var less = new List<int>();
            var equal = new List<int>();
            var greater = new List<int>();

            // Распределяем элементы исходного списка по трем новым спискам.
            foreach (int item in list)
            {
                if (item < pivotValue)
                {
                    less.Add(item);
                }
                else if (item == pivotValue)
                {
                    equal.Add(item);
                }
                else // item > pivotValue
                {
                    greater.Add(item);
                }
            }

            // Рекурсивно сортируем списки "меньших" и "больших" элементов.
            List<int> sortedLess = QuickSort(less);
            List<int> sortedGreater = QuickSort(greater);

            // Объединяем отсортированные части и список "равных" элементов.
            var result = new List<int>(sortedLess.Count + equal.Count + sortedGreater.Count); // Оптимизация: задаем емкость
            result.AddRange(sortedLess);
            result.AddRange(equal); // Добавляем все элементы, равные опорному
            result.AddRange(sortedGreater);

            return result;
        }
    }
}
