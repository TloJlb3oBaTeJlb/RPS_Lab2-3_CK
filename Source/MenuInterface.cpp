#include <iostream>
#include "InputCheck.h"

#include "RandomIntegerGeneration.h"//

using namespace std;

void ShowGreeting() {
	cout << "����� ���������� ������������� / �������� ������ ���������" << endl;
	cout << "������ 434" << endl;
	cout << "������������ ������ N2" << endl;
	cout << "������� 11" << endl;
	cout << "���� ������:" << endl;
	cout << "���������� ��������� ���������� ��� ������ ������� ������� ���������� (QuickSort)." << endl;
	cout << "==========================================================================" << endl << endl;
}

void ShowMainMenuOptions() {
	cout << "~ ������� ���� ~" << endl;
	cout << "����������, �������� ����� ����:" << endl;
	cout << "1 - ��������� ������ �������." << endl;
	cout << "2 - ������������� ��������� ������." << endl;
	cout << "3 - �����" << endl;
	cout << "��� �����: ";
}

void ChooseMainMenuOption() {
	MainMenuItems userChoice = static_cast<MainMenuItems>(0);
	ShowMainMenuOptions();
	do {
		userChoice = GetMainMenuItems();
		switch (userChoice) {
		case MANUAL_INPUT:
			cout << endl;
			cout << "Manual input function" << endl;
			break;
		case RANDOM_ARRAY:
			cout << endl;
			RandomIntGenerator();
			break;
		case QUIT:
			cout << endl;
			cout << "���������� ������" << endl;
			break;
		default:
			cout << "������� ������ ���� �� ����������." << endl << endl;
			break;
		}
	} while (userChoice != QUIT);
}