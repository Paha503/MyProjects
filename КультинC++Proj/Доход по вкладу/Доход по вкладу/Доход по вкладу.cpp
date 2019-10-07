// Доход по вкладу.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
using namespace std;
int _tmain(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL,"Russian");
	float summa;
	int srok = month/12;
	int month;
	int stavka = proc/100;
	int proc;
	float dohod;
	cout<<"Эта программа вычисляет доход по вкладу.\n";
	cout<<"Введите сумму вклада.\n";
	cin>>summa;
	cout<<"Введите процентную ставку.\n";
	cin>>proc;
	cout<<"Введите срок начисления.\n";
	cin>>month;
	dohod = summa*stavka*srok;
	cout<<"Ваш доход "<<dohod<<" тенге.\n";
	system("pause");
	return 0;
}

