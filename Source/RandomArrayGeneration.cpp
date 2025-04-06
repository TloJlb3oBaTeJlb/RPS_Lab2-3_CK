#include <iostream>
#include <cstdlib>
#include <random>
using namespace std;

vector<int> RandomVectorGenerator() {

	vector<int> randomVector;
    random_device random;
    mt19937 generate(random());
	uniform_int_distribution<> vectorSizeBoundaries(1, 200);
    uniform_int_distribution<> vectorVariablesBoundaries(-1000, 1000);

    for (int i = 0; i < vectorSizeBoundaries(generate); i++) {

		int element = vectorVariablesBoundaries(generate);
		randomVector.push_back(element);

    }

	cout << "—генерированный массив:" << endl;

	for (int element : randomVector) {
		cout << element << " ";
	}

	cout << endl;
	return randomVector;


}