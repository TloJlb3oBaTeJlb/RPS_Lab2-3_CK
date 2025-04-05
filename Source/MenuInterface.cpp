#include <iostream>
#include "InputCheck.h"

#include "RandomIntegerGeneration.h"//

using namespace std;

void ShowGreeting() {
	cout << "Чудов Константин Александрович / Корзинин Михаил Андреевич" << endl;
	cout << "Группа 434" << endl;
	cout << "Лабораторная работа N2" << endl;
	cout << "Вариант 11" << endl;
	cout << "Цель работы:" << endl;
	cout << "Разработка программы сортировки при помощи способа быстрой сортировки (QuickSort)." << endl;
	cout << "==========================================================================" << endl << endl;
}

void ShowMainMenuOptions() {
	cout << "~ Главное меню ~" << endl;
	cout << "Пожалуйста, выбирите пункт меню:" << endl;
	cout << "1 - Заполнить массив вручную." << endl;
	cout << "2 - Сгенерировать случайный массив." << endl;
	cout << "3 - Выйти" << endl;
	cout << "Ваш выбор: ";
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
			cout << "Завершение работы" << endl;
			break;
		default:
			cout << "Данного пункта меню не существует." << endl << endl;
			break;
		}
	} while (userChoice != QUIT);
}