#include <iostream>
#include <fstream>
#include <string>
#include <iomanip>
#include <time.h>
#include <cstdio>
using namespace std;

void Print_Mass(double** mass, int N) {
	cout << setprecision(3) << endl;
	cout << endl;
	for (int i = 0; i < N; i++) { 
		cout << endl;
		for (int j = 0; j < N + 1; j++) cout << mass[i][j] << "     ";
	}
}

void Print_X(double* X, int N) {
	cout << endl;
	cout << endl;
	for (int i = 0; i < N; i++) cout << "x" << i+1 << " = " << X[i] << "     ";
}

void Swap(double** mass, int N, double* X) {
	int ind = 0;
	for (int i = 1; i < N; i++) {
		if (abs(mass[ind][0]) < abs(mass[i][0])) ind = i;
	}

	for (int j = 0; j < N + 1; j++) {
		swap(mass[ind][j], mass[0][j]);
		}
}
void Zero_Swap(double** mass, int N, int index) {
		int ind;
		for (int i = index+1; i < N; i++) {
			if (mass[i][index] != 0) ind = i;;
		}

		for (int j = 0; j < N + 1; j++) {
			swap(mass[ind][j], mass[index][j]);
		}
}

void Gausse(double** mass, int N, double* X) {
	Print_Mass(mass, N);
	double element;
	for (int i = 0; i < N; i++) {

		for (int j = i + 1; j < N; j++) {
			if (mass[i][i] == 0) { 
			Zero_Swap(mass, N, i); 		
			Print_Mass(mass, N);
			}
			element = mass[j][i] / mass[i][i];

			for (int m = i; m <= N; m++) mass[j][m] = mass[j][m] - element * mass[i][m];
		}
		Print_Mass(mass, N);
	}

	for (int i = 0; i < N; i++) {
		element = mass[i][i];
		for (int j = 0; j < N + 1; j++) {
			mass[i][j] /= element;
		}
	}
	Print_Mass(mass, N);
	X[N - 1] = mass[N - 1][N];
	for (int i = N - 2; i >= 0; i--)
	{
		X[i] = mass[i][N];
		for (int j = i + 1; j < N; j++) X[i] -= mass[i][j] * X[j];
	}
}

int main()
{
	srand(time(NULL));

	double** mass;
	double* X;
	int counter;

	ifstream file("1.txt");

	if (file.is_open())
	{
		counter = 0;
		int temp;

		while (!file.eof())
		{
			file >> temp;
			counter++;
		}
		file.seekg(0, ios::beg);
		file.clear();
		int count_space = 0;
		char symbol;
		while (!file.eof())
		{

			file.get(symbol);
			if (symbol == ' ') count_space++;
			if (symbol == '\n') break;
		}
		file.seekg(0, ios::beg);
		file.clear();
		int n = counter / (count_space + 1);
		int m = count_space + 1;

		mass = new double* [n];
		X = new double[n];

		for (int i = 0; i < m; ++i) {
			mass[i] = new double[m];
		}
		for (int i = 0; i < n; i++)
			for (int j = 0; j < m; j++)
				file >> mass[i][j];

		Print_Mass(mass, n);
		int var;
		cout << endl;
		cout << "1 - Gauss method" << endl;
		cout << "2 - modified Gauss method" << endl;
		cin >> var;
		switch (var)
		{
		case 1:
			Gausse(mass, n, X);
			break;
		case 2:
			Swap(mass, n, X);
			Print_Mass(mass, n);
			cout << endl;
			Gausse(mass, n, X);
			break;
		default:
			break;
		}
		Print_X(X, n);
		file.close();
	}

}