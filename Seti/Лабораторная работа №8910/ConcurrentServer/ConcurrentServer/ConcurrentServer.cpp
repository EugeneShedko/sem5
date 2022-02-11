#define _WINSOCK_DEPRECATED_NO_WARNINGS
#include <iostream>
#include "Winsock2.h"
#include <string>
#include <ctime>
#include <list>
#pragma comment(lib, "WS2_32.lib")

using namespace std;

HANDLE hAcceptServer;
HANDLE hConsolePipe;
HANDLE hGarbageCleaner;
string port;
//Вынести структуры и перечисления в отдельный заголовочный файл
enum TalkersCommand
{
	EXIT,
	START,
	STOP,
	STATISTICS,
	WAIT,
	SHUTDOWN,
	GETCOMMAND
};
//Список подключений
struct Contact
{
	enum TE //Состояние сервера подключений
	{
		EMPTY,
		ACCEPT,
		CONTACT
	}type;

	enum ST
	{
		WORK,
		ABORT,
		TIMEOUT,
		FINISH
	}sthread;

	SOCKET s;
	SOCKADDR_IN prms;
	int lprms;
	HANDLE hthread;
	HANDLE htimer;

	char msg[50];
	char srvname[15];

	Contact(TE t = EMPTY, const char* namesrv = "")
	{
		memset(&prms, 0 , sizeof(prms));
		lprms = sizeof(SOCKADDR_IN);
		type = t;
		strcpy_s(srvname, namesrv);
		msg[0] = 0;
	}

	void SetST(ST sth, const char* m = "")
	{
		sthread = sth;
		strcpy_s(msg, m);
	}
};

string SetErrorMsgText(string msgText, int code);
string GetErrorMsgText(int code);
DWORD WINAPI AcceptServer(LPVOID param);
void CommandsCycle(TalkersCommand &cmd, SOCKET sS);
bool AcceptCycle(int squirt, SOCKET sS);
typedef list<Contact> ListContact;
ListContact contacts;
CRITICAL_SECTION section;

int main(int argc, char* argv[])
{
	InitializeCriticalSection(&section);
	volatile TalkersCommand cmd = START;
	hAcceptServer = CreateThread(NULL, NULL, AcceptServer , (LPVOID)&cmd, NULL, NULL);
	WaitForSingleObject(hAcceptServer, INFINITE);
	CloseHandle(hAcceptServer);
	getchar();
}



DWORD WINAPI AcceptServer(LPVOID param)
{
	WSADATA wsaData;
	SOCKET sS;
	try
	{
		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
		{
			throw SetErrorMsgText("Startup", WSAGetLastError());
		}
		if ((sS = socket(AF_INET, SOCK_STREAM, NULL)) == INVALID_SOCKET)
		{
			throw SetErrorMsgText("socket: ", WSAGetLastError());
		}
		SOCKADDR_IN serv;
		serv.sin_family = AF_INET;
		serv.sin_port = htons(2000);
		serv.sin_addr.S_un.S_addr = INADDR_ANY;
		if (bind(sS, (LPSOCKADDR)&serv, sizeof(serv)) == SOCKET_ERROR)
		{
			throw SetErrorMsgText("bind", WSAGetLastError());
		}
		if (listen(sS, SOMAXCONN) == SOCKET_ERROR)
		{
			throw SetErrorMsgText("listen", WSAGetLastError());
		}
		u_long nonblk;
		if (ioctlsocket(sS, FIONBIO, &(nonblk = 1)) == SOCKET_ERROR)
		{
			throw SetErrorMsgText("ioctlsocket: ", WSAGetLastError());
		}
		CommandsCycle(*((TalkersCommand*)param), sS);

		//-----------------------------------------------------------------//

		if (closesocket(sS) == SOCKET_ERROR)
		{
			throw SetErrorMsgText("closesocket: ", WSAGetLastError());
		}
		if (WSACleanup() == SOCKET_ERROR)
		{
			throw SetErrorMsgText("Cleanup", WSAGetLastError());
		}
	}
	catch (string errorMsgText) {
		cout << endl << errorMsgText;
	}
	ExitThread(*(DWORD*)param);
}

bool AcceptCycle(int squirt, SOCKET sS)
{
	bool rc = false;
	Contact c(Contact::ACCEPT, "EchoServer");
	while (squirt-- > 0 && rc == false)
	{
		if ((c.s = accept(sS, (sockaddr*)&c.prms, &c.lprms)) == INVALID_SOCKET)
		{
			if (WSAGetLastError() != WSAEWOULDBLOCK)
			{
				throw SetErrorMsgText("accept: ", WSAGetLastError());
			}
			cout << squirt << endl;
		}
		else
		{
			cout << "Номер порта: " << ntohs(c.prms.sin_port) << endl;
			cout << "IP-адрес:" << inet_ntoa(c.prms.sin_addr) << endl;
			rc = true;
			EnterCriticalSection(&section);
			contacts.push_front(c);
			LeaveCriticalSection(&section);
		}
	}
	return rc;
}

void CommandsCycle(TalkersCommand &cmd, SOCKET sS)
{
	int squirt = 0;
	//Не понимаю зачем здесь цикл, когда может стать exit?
	//Правильно ли я написал обработку команд, как обрабатывать GETCOMMAND?
	//Зачем вообще нужен GETCOMMAND?
	while (cmd != EXIT)
	{
		switch (cmd)
		{
		case START: cmd = GETCOMMAND;
			squirt = 10;
			break;
		case STOP: cmd = GETCOMMAND;
			squirt = 0;
			break;
		case STATISTICS: cmd = GETCOMMAND;
			squirt = 10;
			break;
		case WAIT: cmd = GETCOMMAND;
			squirt = 0;
			break;
		case SHUTDOWN: cmd = GETCOMMAND;
			squirt = 0;
			break;
		default:
				break;
		}
		if (AcceptCycle(squirt, sS))
		{
			cmd = GETCOMMAND;
		}
		else
		{
			SleepEx(0, TRUE);
		}
	}
}


string GetErrorMsgText(int code)
{
	string msgText;
	switch (code)
	{
	case WSAEINTR: msgText = "WSAEINTR"; break;
	case WSAEACCES: msgText = "WSAEACCES"; break;
	case WSAEFAULT: msgText = "WSAEFAULT"; break;
	case WSAEINVAL: msgText = "WSAEINVAL"; break;
	case WSAEMFILE: msgText = "WSAEMFILE"; break;
	case WSAEWOULDBLOCK: msgText = "WSAEWOULDBLOCK"; break;
	case WSAEINPROGRESS: msgText = "WSAEINPROGRESS"; break;
	case WSAEALREADY: msgText = "WSAEALREADY"; break;
	case WSAENOTSOCK: msgText = "WSAENOTSOCK"; break;
	case WSAEDESTADDRREQ: msgText = "WSAEDESTADDRREQ"; break;
	case WSAEMSGSIZE: msgText = "WSAEMSGSIZE"; break;
	case WSAEPROTOTYPE: msgText = "WSAEPROTOTYPE"; break;
	case WSAENOPROTOOPT: msgText = "WSAENOPROTOOPT"; break;
	case WSAEPROTONOSUPPORT: msgText = "WSAEPROTONOSUPPORT"; break;
	case WSAESOCKTNOSUPPORT: msgText = "WSAESOCKTNOSUPPORT"; break;
	case WSAEOPNOTSUPP: msgText = "WSAEOPNOTSUPP"; break;
	case WSAEPFNOSUPPORT: msgText = "WSAEPFNOSUPPORT"; break;
	case WSAEAFNOSUPPORT: msgText = "WSAEAFNOSUPPORT"; break;
	case WSAEADDRINUSE: msgText = "WSAEADDRINUSE"; break;
	case WSAEADDRNOTAVAIL: msgText = "WSAEADDRNOTAVAIL"; break;
	case WSAENETDOWN: msgText = "WSAENETDOWN"; break;
	case WSAENETUNREACH: msgText = "WSAENETUNREACH"; break;
	case WSAENETRESET: msgText = "WSAENETRESET"; break;
	case WSAECONNABORTED: msgText = "WSAECONNABORTED"; break;
	case WSAECONNRESET: msgText = "WSAECONNRESET"; break;
	case WSAENOBUFS: msgText = "WSAENOBUFS"; break;
	case WSAEISCONN: msgText = "WSAEISCONN"; break;
	case WSAENOTCONN: msgText = "WSAENOTCONN"; break;
	case WSAESHUTDOWN: msgText = "WSAESHUTDOWN"; break;
	case WSAETIMEDOUT: msgText = "WSAETIMEDOUT"; break;
	case WSAECONNREFUSED: msgText = "WSAECONNREFUSED"; break;
	case WSAEHOSTDOWN: msgText = "WSAEHOSTDOWN"; break;
	case WSAEHOSTUNREACH: msgText = "WSAEHOSTUNREACH"; break;
	case WSAEPROCLIM: msgText = "WSAEPROCLIM"; break;
	case WSASYSNOTREADY: msgText = "WSASYSNOTREADY"; break;
	case WSAVERNOTSUPPORTED: msgText = "WSAVERNOTSUPPORTED"; break;
	case WSANOTINITIALISED: msgText = "WSANOTINITIALISED"; break;
	case WSAEDISCON: msgText = "WSAEDISCON"; break;
	case WSATYPE_NOT_FOUND: msgText = "WSATYPE_NOT_FOUND"; break;
	case WSAHOST_NOT_FOUND: msgText = "WSAHOST_NOT_FOUND"; break;
	case WSATRY_AGAIN: msgText = "WSATRY_AGAIN"; break;
	case WSANO_RECOVERY: msgText = "WSANO_RECOVERY"; break;
	case WSANO_DATA: msgText = "WSANO_DATA"; break;
	case WSA_INVALID_HANDLE: msgText = "WSA_INVALID_HANDLE"; break;
	case WSA_INVALID_PARAMETER: msgText = "WSA_INVALID_PARAMETER"; break;
	case WSA_IO_INCOMPLETE: msgText = "WSA_IO_INCOMPLETE"; break;
	case WSA_IO_PENDING: msgText = "WSA_IO_PENDING"; break;
	case WSA_NOT_ENOUGH_MEMORY: msgText = "WSA_NOT_ENOUGH_MEMORY"; break;
	case WSA_OPERATION_ABORTED: msgText = "WSA_OPERATION_ABORTED"; break;
	case WSASYSCALLFAILURE: msgText = "WSASYSCALLFAILURE"; break;
	default: msgText = "***ERROR***"; break;
	}
	return msgText;
}
string SetErrorMsgText(string msgText, int code)
{
	return msgText + GetErrorMsgText(code);
}
