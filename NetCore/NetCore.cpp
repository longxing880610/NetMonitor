// NetCore.cpp : ���� DLL Ӧ�ó���ĵ���������
//

#include "stdafx.h"
#include "NetCore.h"


// ���ǵ���������һ��ʾ��
NETCORE_API int nNetCore=0;

// ���ǵ���������һ��ʾ����
NETCORE_API int fnNetCore(void)
{
    return 42;
}

// �����ѵ�����Ĺ��캯����
// �й��ඨ�����Ϣ������� NetCore.h
CNetCore::CNetCore()
{
    return;
}
