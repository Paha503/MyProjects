// ����� ����������.cpp: ���������� ����� ����� ��� ����������� ����������.
//

#include "stdafx.h"
#include <iostream>
using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL,"Russian");
	float funt, kg; //���������� ����������
	cout <<"������ ��������� ��������� ����� � ����������."<<"\n";
	cout <<"������� ���������� ������ ��� ���������������."<<"\n";
	cin >> funt;
	kg = funt/2.2046;
	cout <<funt<<" ������ ��� "<<kg<<" �����������.\n"; 
	system("pause");
	return 0;
}

