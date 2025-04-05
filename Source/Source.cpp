#include <iostream>
#include "SortAlgorithm.h"
#include "MenuInterface.h"

int main() {

	system("chcp 1251>nul");

	ShowGreeting();

	ChooseMainMenuOption();

	std::vector<int> TestVectorW = { 12, 56, -4, 15, 0, 6, -11, 3, 89, 1000, 565, -787, 121, 1, -2, 0, 45, 65, 77, -66 };
	std::vector<int> TestVectorS = QuickSort(TestVectorW);
	for (int num : TestVectorS) {
		std::cout << num << " ";
	}

	system("PAUSE");
}