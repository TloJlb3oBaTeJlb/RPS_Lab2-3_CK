#include <iostream>
#include <vector>
#include "FileWork.h"
#include "InputCheck.h"
#include "SortAlgorithm.h"
#include "RandomArrayGeneration.h"

using namespace std;

void ShowGreeting() {
	cout << "Чудов Константин Александрович / Корзинин Михаил Андреевич" << endl;
	cout << "Группа 434" << endl;
	cout << "Лабораторная работа N2" << endl;
	cout << "Вариант 11" << endl;
	cout << "Цель работы:" << endl;
	cout << "Разработка программы сортировки при помощи способа быстрой сортировки (QuickSort)." << endl;
	cout << "==========================================================================" << endl;
}

void ShowMainMenuOptions() {
	cout << endl << "~ Главное меню ~" << endl;
	cout << "Пожалуйста, выбирите пункт меню:" << endl;
	cout << "1 - Заполнить массив вручную." << endl;
	cout << "2 - Сгенерировать случайный массив." << endl;
	cout << "3 - Выйти" << endl;
	cout << "Ваш выбор: ";
}

void ShowResultSaveMenu() {
	cout << endl << "~ Меню сохранения массива ~" << endl;
	cout << "Пожалуйста, выбирите пункт меню:" << endl;
	cout << "1 - Сохранить массив." << endl;
	cout << "2 - Продолжить без сохранения." << endl;
	cout << "Ваш выбор: ";
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
			cout << endl << "Данного пункта меню не существует." << endl << endl;
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
			cout << "Завершение работы" << endl;
			break;
		default:
			cout << endl << "Данного пункта меню не существует. Пожалуйста, выбирите один из предложанных вариантов." << endl;
			break;
		}
	} while (userChoice != QUIT);
}