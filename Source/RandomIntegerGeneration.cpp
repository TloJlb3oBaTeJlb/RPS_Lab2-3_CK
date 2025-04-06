#include <iostream>
#include <cstdlib>
#include <ctime>
using namespace std;

int RandomIntGenerator(int randomArraySize) {

    int randomInt = rand();

    for (int i = 1; i < randomArraySize + 1; i++) {

        srand(time(NULL) + 2);

        int minusDeterminator = rand();

        randomInt = randomInt / i;

        if (minusDeterminator % 2 == 0) {
            randomInt = -randomInt;
        }

        cout << randomInt << endl;

    }
    return randomInt;
}


