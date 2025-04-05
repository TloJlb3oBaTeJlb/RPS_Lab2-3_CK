#include <locale>
#include <iostream>

int main() {

	setlocale(0, "");

	std::cout << "Привет мир!" << std::endl;

	system("PAUSE");
}