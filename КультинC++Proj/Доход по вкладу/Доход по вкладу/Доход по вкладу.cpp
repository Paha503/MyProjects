// ����� �� ������.cpp: ���������� ����� ����� ��� ����������� ����������.
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
	cout<<"��� ��������� ��������� ����� �� ������.\n";
	cout<<"������� ����� ������.\n";
	cin>>summa;
	cout<<"������� ���������� ������.\n";
	cin>>proc;
	cout<<"������� ���� ����������.\n";
	cin>>month;
	dohod = summa*stavka*srok;
	cout<<"��� ����� "<<dohod<<" �����.\n";
	system("pause");
	return 0;
}

