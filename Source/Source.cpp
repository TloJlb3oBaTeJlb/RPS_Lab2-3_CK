﻿#include <locale>
#include <iostream>
#include "MenuInterface.h"

int main() {

	system("chcp 1251>nul");

	ShowGreeting();

	ChooseMainMenuOption();

	system("PAUSE");
}