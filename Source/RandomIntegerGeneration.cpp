#include <iostream>
#include <cstdlib>
#include <ctime>
using namespace std;

int RandomIntGenerator() {
    srand(time(NULL));

    int minusDeterminator = rand();
    int randomInt = rand();

    if (minusDeterminator % 2 == 0) {
        randomInt = -randomInt;
    }

    cout << randomInt << endl;

    return randomInt;

}