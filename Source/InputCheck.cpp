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
			cout << "������ �����. ����������, ���������� ������ ��� ������." << endl;
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
		std::cout << "������� ��������� ��������� �������: ";
		numberOfElements = GetInt();
		if (numberOfElements < 1) {
			cout << "���������� ��������� �� ����� ���� ������ 1." << endl;
			continue;
		}
		else {
			isInputCorrect = true;
		}
	} while (!isInputCorrect);
	for (int i = 0; i < numberOfElements; ++i) {
		cout << "������� " << i + 1 << " ������� �������: ";
		int element = GetInt();
		userVector.push_back(element);
	}
	cout << endl << "���� ��������. ���������� ������: ";
	for (int element : userVector) {
		cout << element << " ";
	}
	cout << endl;
	return userVector;
}