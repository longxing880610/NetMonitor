// ���� ifdef ���Ǵ���ʹ�� DLL �������򵥵�
// ��ı�׼�������� DLL �е������ļ��������������϶���� NETCORE_EXPORTS
// ���ű���ġ���ʹ�ô� DLL ��
// �κ�������Ŀ�ϲ�Ӧ����˷��š�������Դ�ļ��а������ļ����κ�������Ŀ���Ὣ
// NETCORE_API ������Ϊ�Ǵ� DLL ����ģ����� DLL ���ô˺궨���
// ������Ϊ�Ǳ������ġ�
#ifdef NETCORE_EXPORTS
#define NETCORE_API __declspec(dllexport)
#else
#define NETCORE_API __declspec(dllimport)
#endif

// �����Ǵ� NetCore.dll ������
class NETCORE_API CNetCore {
public:
	CNetCore(void);
	// TODO:  �ڴ�������ķ�����
};

extern NETCORE_API int nNetCore;

NETCORE_API int fnNetCore(void);
