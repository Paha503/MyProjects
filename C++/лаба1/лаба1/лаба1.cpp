#include "stdafx.h"
#include <iostream>
#include <Windows.h>
#include <conio.h>
#include <cmath>
using namespace std;
struct BinTree {
    int value; //�������� ��������
    BinTree* left;//����� ������ ���������
    BinTree* right;//����� ������� ���������
};
//������� ��� �������� ������
//����: �������� �������� ����,���� ��������� ������
//�����: ������������ �������� �������,��������� ����������
void newBinTree(int val, BinTree** Tree) {
    if ((*Tree) == NULL) 
    {
        (*Tree) = new BinTree; //�������� ������
        (*Tree)->value = val;  //��������� � ���������� ����� ��������
        (*Tree)->left = (*Tree)->right = NULL;
        return;
    }
    if (val > (*Tree)->value) newBinTree(val, &(*Tree)->right);//���� �������� ������ ��� ������� �������, ��������� ��� ������
    else newBinTree(val, &(*Tree)->left);//����� ��������� ��� �����
}
//��� ������ ������
void Print(BinTree**Tree, int l)
{
    int i;
 
    if (*Tree != NULL)
    {
        Print(&((**Tree).right), l + 1);
        for (i = 1; i <= l; i++) cout << "   ";
        cout << (**Tree).value << endl;
        Print(&((**Tree).left), l + 1);
    }
}
 
void TreeTraversalAndPrint(BinTree* Root) {
    if (Root != NULL) {
        cout << Root->value << endl;
        TreeTraversalAndPrint(Root->left);
        TreeTraversalAndPrint(Root->right);
 
    }
}
 
void TreeTraversalAndPrint2(BinTree* Root) {
    if (Root != NULL) {
        TreeTraversalAndPrint2(Root->left);
        TreeTraversalAndPrint2(Root->right);
        cout << Root->value << endl;
    }
}
void TreeTraversalAndPrint3(BinTree* Root) {
    if (Root != NULL) {
        TreeTraversalAndPrint2(Root->left);
        cout << Root->value << endl;
        TreeTraversalAndPrint2(Root->right);
    }
}
//��� ��� � �������� ������ ������ ��� ������� ���� �����������, ��� left < right, 
//�� �������������� ��� ���������� ������������ �������� 
//���� ������ �� ����� �� ����� ������ �� ����� - ��� � ����� ����������.
BinTree* MinValue(BinTree* Tree)
{
    if (Tree->left != NULL) {
        return MinValue(Tree->left);
    }
    else {
        return Tree;
    }
}
//��� ��� � �������� ������ ������ ��� ������� ���� �����������, ��� left < right, 
//�� �������������� ��� ���������� ����������� �������� 
//���� ������ �� ����� �� ������ ������ �� ����� - ��� � ����� ����������.
BinTree* MaxValue(BinTree* Tree)
{
    if (Tree->right != NULL) {
        return  MaxValue(Tree->right);
    }
    else {
        return Tree;
    }
}
int NumberOfNodes(BinTree* Tree) {
    if (Tree == NULL) return 0;
    return NumberOfNodes(Tree->left) + 1+ NumberOfNodes(Tree->right);
}
 
int ListCount(BinTree* node)
{
    if (!node)
        return 0;
    if (!node->left && !node->right)
        return 1;
    return  ListCount(node->left) + ListCount(node->right);
}
 
//������(������������ �������) ������ ������������ ����������� �������, 
//�� ������� ������������� ��� �������.
//������ ������� ������ ����� ����, ������ ������ �� ������ ����� � �������.
//�� ������ ������ ������ ����� ���� ������ ���� ������� � ������ ������, 
//�� ������ � ������� ����� ������, �� ������� � ������� �������� ����� ������ � �.�.
int HeightBTree(BinTree* Tree) {
    int x = 0, y = 0;
    if (Tree == NULL) return 0;     //������ ������ ��� ����� �� �����
    if(Tree->left) x = HeightBTree(Tree->left); //������ ������ ���������
    if (Tree->right) y = HeightBTree(Tree->right);  //������ ������� ���������
    if (x > y) return x + 1;    //+1 �� ����� � ������ ���������
    else return y + 1;   //+1 �� ����� � ������� ���������
}
//����� �������� � �������� ������ ������
BinTree* Search(BinTree* Tree, int key) {
    if (Tree == NULL) return NULL;
    if  (Tree->value == key) return Tree;
    if (key < Tree->value) return Search(Tree->left, key);
    else
        return Search(Tree->right, key);
}
 
 
void DestroyBTree(BinTree* Tree) {
    if (Tree != NULL) {
        DestroyBTree(Tree->left);
        DestroyBTree(Tree->right);
        delete(Tree);
    }
}
void MenuProc() {
    BinTree* Tree = NULL;
    char variant;
    int val;
    cout << "��� �������� ������ ��� ���������� �������" << endl;
    while (_getch() != 27) {
        cout << "������ �������� (��� ���������� ����� ������� ESC) ";
        cin >> val;
        newBinTree(val, &Tree);
    }
    Print(&Tree, 0);
    cout << "������ ����� ������" << endl;
    TreeTraversalAndPrint(Tree);
    cout << "�������� ����� ������" << endl;
    TreeTraversalAndPrint2(Tree);
    cout << "C����������� ����� ������" << endl;
    TreeTraversalAndPrint3(Tree);
    cout << "����������� ������� ������-> ";
    BinTree* min = MinValue(Tree);
    cout << min->value;
    cout << endl << "������������ ������� ������-> ";
    BinTree* max = MaxValue(Tree);
    cout << max->value;
    cout << endl;
    cout << "������ ������-> ";
    int Heigh = HeightBTree(Tree);
    cout << Heigh;
    cout << endl;
    cout<<"���������� ��������� � ������-> ";
    int a = NumberOfNodes(Tree);
    cout << a << endl;
    cout << "���������� ������ � ������-> ";
    int b = ListCount(Tree);
    cout << b<< endl;
    cout << "����� ��������" << endl;
    int key;
    cout << "������� �������� �������� ��� ������-> ";
    cin >> key;
    BinTree* Tree1 = Search(Tree,key);
    if (Tree1 == NULL)
        cout << "������� �� ������";
    else
        cout << "��� �������->" << Tree1->value<< " ������!";
    cout << endl;
    DestroyBTree(Tree);
}
 
int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    MenuProc();
    system("pause");
    return 0;
}