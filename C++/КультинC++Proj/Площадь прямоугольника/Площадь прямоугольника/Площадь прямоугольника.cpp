// ������� ��������������.cpp: ���������� ����� ����� ��� ����������� ����������.
//

#include "stdafx.h"
#include <iostream>
using namespace std;


int _tmain(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL,"Russian");
	float a, b; //���������� ����������
	cout << "�������" << " ���������� " << " a.";
	cin >> a;
	cout << "a = " << a << " ��.";
	cout << "�������" << " ���������� " << " b.";
	cin >> b;
	cout << "b = " << a << " ��.";
	float s = a*b;
	cout << "������������ ���������...";
	cout << "...";
	cout << "������� " << "�������������� " << "����� " << s <<" ��.";
	system("pause");
	return 0;
}

