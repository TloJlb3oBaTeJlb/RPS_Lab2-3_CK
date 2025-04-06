#include <vector>
#include <iostream>

std::vector<int> QuickSort(const std::vector<int>& array) {
    if (array.size() <= 1) {
        return array;
    }

    const int pivot = array[array.size() / 2];

    std::vector<int> less, equal, greater;
    for (const int num : array) {
        if (num < pivot) {
            less.push_back(num);
        }
        else if (num == pivot) {
            equal.push_back(num);
        }
        else {
            greater.push_back(num);
        }
    }

    auto sortedLess = QuickSort(less);
    const auto sortedGreater = QuickSort(greater);

    sortedLess.insert(sortedLess.end(), equal.begin(), equal.end());
    sortedLess.insert(sortedLess.end(), sortedGreater.begin(), sortedGreater.end());

    return sortedLess;
}

void SortVector(const std::vector<int>& vector) {
	std::vector<int> sortedVector = QuickSort(vector);
    std::cout << "Отсортированный массив: ";
	for (const int num : sortedVector) {
		std::cout << num << " ";
	}
	std::cout << std::endl;
}