// Фунты килограммы.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL,"Russian");
	float funt, kg; //обьявление переменных
	cout <<"Данная программа переводит фунты в килограммы."<<"\n";
	cout <<"Введите количество фунтов для конвертирования."<<"\n";
	cin >> funt;
	kg = funt/2.2046;
	cout <<funt<<" фунтов это "<<kg<<" килограммов.\n"; 
	system("pause");
	return 0;
}

