#include <iostream>
#include <string>
#include <vector>
#include "MenuItems.h"

using namespace std;

template<typename T>
T GetInput() {
	T userInput{};
	cin >> userInput;
	if (cin.fail()) {
		while (cin.fail()) {
			cout << "Ошибка ввода. Пожалуйста, попробуйте другой тип данных." << endl;
			cin.clear();
			cin.ignore(LLONG_MAX, '\n');
			cin >> userInput;
		}
	}
	cin.ignore(LLONG_MAX, '\n');
	return userInput;
}

int GetInt() {
	return GetInput<int>();
}

MainMenuItems GetMainMenuItems() {
	return static_cast<MainMenuItems>(GetInt());
}

vector<int> GetUserVector() {
	vector<int> userVector;
	int numberOfElements;
	bool isInputCorrect = false;
	do {
		std::cout << "Введите количесто элементов массива: ";
		numberOfElements = GetInt();
		if (numberOfElements < 1) {
			cout << "количество элементов не может быть меньше 1." << endl;
			continue;
		}
		else {
			isInputCorrect = true;
		}
	} while (!isInputCorrect);
	for (int i = 0; i < numberOfElements; ++i) {
		cout << "Введите " << i + 1 << " элемент массива: ";
		int element = GetInt();
		userVector.push_back(element);
	}
	cout << endl << "Ввод завершен. Полученный массив: ";
	for (int element : userVector) {
		cout << element << " ";
	}
	cout << endl;
	return userVector;
}