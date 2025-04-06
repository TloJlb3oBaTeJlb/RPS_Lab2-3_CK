#include <iostream>
#include <string>
#include <fstream>
#include <filesystem>
#include "InputCheck.h"

using namespace std;
using namespace filesystem;

void OutputData(vector<int> sortedVector) {
	string filePath = "";
	bool isDataSaved = false;
	do {
		cout << "Сохранить в:" << endl;
		getline(cin, filePath);

		if (ifstream(filePath)) {
			cout << "Такой файл уже существует." << endl;
			cout << "[0] - Перезаписать существующий файл." << endl;
			cout << "[1] - Повторить ввод." << endl;
			int tryAnotherFile = GetInt();
			if (tryAnotherFile) {
				continue;
			}
		}

		ofstream myFile(filePath, ofstream::app);// app = append

		error_code ec{};
		if (!is_regular_file(filePath, ec)) {
			cout << "Адрес содержит некорректные значения. Побробуйте ещё раз." << endl;
			continue;
		}

		if (!myFile) {
			cout << "Доступ запрещён. Попробуйте ещё раз." << endl;
			myFile.close();
			continue;
		}

		myFile.close();
		myFile.open(filePath, ofstream::trunc);//trunc is default mode for ofstream::open

		size_t sizeOfList = sortedVector.size();
		myFile << sizeOfList << endl;
		for (int value : sortedVector) {
			myFile << value << " ";
		}

		myFile.close();
		cout << "Запись завершена." << endl;
		isDataSaved = true;
	} while (!isDataSaved);
}