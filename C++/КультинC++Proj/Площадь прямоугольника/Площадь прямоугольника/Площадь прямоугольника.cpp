// Площадь прямоугольника.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
using namespace std;


int _tmain(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL,"Russian");
	float a, b; //обьявление переменных
	cout << "Введите" << " переменную " << " a.";
	cin >> a;
	cout << "a = " << a << " см.";
	cout << "Введите" << " переменную " << " b.";
	cin >> b;
	cout << "b = " << a << " см.";
	float s = a*b;
	cout << "Производится умножение...";
	cout << "...";
	cout << "Площадь " << "прямоугольника " << "равна " << s <<" см.";
	system("pause");
	return 0;
}

