#include <iostream>
#include <vector>
#include "FileWork.h"
#include "InputCheck.h"
#include "SortAlgorithm.h"
#include "RandomArrayGeneration.h"

using namespace std;

void ShowGreeting() {
	cout << "����� ���������� ������������� / �������� ������ ���������" << endl;
	cout << "������ 434" << endl;
	cout << "������������ ������ N2" << endl;
	cout << "������� 11" << endl;
	cout << "���� ������:" << endl;
	cout << "���������� ��������� ���������� ��� ������ ������� ������� ���������� (QuickSort)." << endl;
	cout << "==========================================================================" << endl;
}

void ShowMainMenuOptions() {
	cout << endl << "~ ������� ���� ~" << endl;
	cout << "����������, �������� ����� ����:" << endl;
	cout << "1 - ��������� ������ �������." << endl;
	cout << "2 - ������������� ��������� ������." << endl;
	cout << "3 - �����" << endl;
	cout << "��� �����: ";
}

void ShowResultSaveMenu() {
	cout << endl << "~ ���� ���������� ������� ~" << endl;
	cout << "����������, �������� ����� ����:" << endl;
	cout << "1 - ��������� ������." << endl;
	cout << "2 - ���������� ��� ����������." << endl;
	cout << "��� �����: ";
}

void SaveResultMenu(const vector<int> sortedVector) {
	SaveResultMenuItems userChoice = static_cast<SaveResultMenuItems>(0);
	ShowResultSaveMenu();
	do
	{
		userChoice = GetSaveResultMenuItem();
		switch (userChoice)
		{
		case SAVE_RESULT:
			OutputData(sortedVector);
			ShowMainMenuOptions();
			break;
		case CONTINUE_WITHOUT_SAVING:
			ShowMainMenuOptions();
			break;
		default:
			cout << endl << "������� ������ ���� �� ����������." << endl << endl;
			break;
		}
	} while (userChoice != CONTINUE_WITHOUT_SAVING && userChoice != SAVE_RESULT);
}

void ChooseMainMenuOption() {
	MainMenuItems userChoice = static_cast<MainMenuItems>(0);
	ShowMainMenuOptions();
	vector<int> rawVector;
	do {
		userChoice = GetMainMenuItems();
		switch (userChoice) {
		case MANUAL_INPUT:
			cout << endl;
			rawVector = GetUserVector();
			SortVector(rawVector);
			SaveResultMenu(rawVector);
			break;
		case RANDOM_ARRAY:
			cout << endl;
			rawVector = RandomVectorGenerator();
			SortVector(rawVector);
			SaveResultMenu(rawVector);
			break;
		case QUIT:
			cout << endl;
			cout << "���������� ������" << endl;
			break;
		default:
			cout << endl << "������� ������ ���� �� ����������. ����������, �������� ���� �� ������������ ���������." << endl;
			break;
		}
	} while (userChoice != QUIT);
}