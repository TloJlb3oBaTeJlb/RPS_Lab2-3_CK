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
		cout << "��������� �:" << endl;
		getline(cin, filePath);

		if (ifstream(filePath)) {
			cout << "����� ���� ��� ����������." << endl;
			cout << "[0] - ������������ ������������ ����." << endl;
			cout << "[1] - ��������� ����." << endl;
			int tryAnotherFile = GetInt();
			if (tryAnotherFile) {
				continue;
			}
		}

		ofstream myFile(filePath, ofstream::app);// app = append

		error_code ec{};
		if (!is_regular_file(filePath, ec)) {
			cout << "����� �������� ������������ ��������. ���������� ��� ���." << endl;
			continue;
		}

		if (!myFile) {
			cout << "������ ��������. ���������� ��� ���." << endl;
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
		cout << "������ ���������." << endl;
		isDataSaved = true;
	} while (!isDataSaved);
}