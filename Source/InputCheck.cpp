#include <iostream>
#include <string>
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