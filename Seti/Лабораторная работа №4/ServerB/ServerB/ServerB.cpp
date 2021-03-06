#define _WINSOCK_DEPRECATED_NO_WARNINGS
#include <iostream>
#include "Winsock2.h"
#pragma comment(lib, "WS2_32.lib")

using namespace std;

string SetErrorMsgText(string msgText, int code);
string GetErrorMsgText(int code);
bool GetRequestFromClient(const char* name, short port, struct sockaddr* from, int* flen, SOCKET sS);
bool PutAnswerToClient(string name, struct sockaddr* to, int* lto, SOCKET sS);

int main()
{
	setlocale(LC_CTYPE, "Russian");
	WSADATA wsaData;
	SOCKET sS;
	try
	{
		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
		{
			throw SetErrorMsgText("Startup", WSAGetLastError());
		}
		if ((sS = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
		{
			throw SetErrorMsgText("socket: ", WSAGetLastError());
		}
		SOCKADDR_IN serv;
		serv.sin_family = AF_INET;
		serv.sin_port = htons(2000);
		serv.sin_addr.S_un.S_addr = INADDR_ANY;
		//сокет
		//указатель на структуру SOCKADDR_IN
		//длина SOCKADDR_IN в байтах
		if (bind(sS, (LPSOCKADDR)&serv, sizeof(serv)) == SOCKET_ERROR)
		{
			throw SetErrorMsgText("bind", WSAGetLastError());
		}
		//---------------------------------------------------------
		//Зачем передаем порт???
		//-----------------------------------------------------------
		int lb = 0;
		string name = "Hello";
		SOCKADDR_IN clnt;
		memset(&clnt, 0, sizeof(clnt));
		int lc = sizeof(clnt);
		char ibuf[50];
		while (true)
		{
			if (GetRequestFromClient("Hello", 2000, (sockaddr*)&clnt, &lc, sS))
			{
				cout << "Порт клиента: " << ntohs(clnt.sin_port) << endl;
				cout << "IP-клиента: " << inet_ntoa(clnt.sin_addr) << endl;
			}
			PutAnswerToClient("Hello", (sockaddr*)&clnt, &lc, sS);
		}
		//-----------------------------------------------------------------//
		if (closesocket(sS) == SOCKET_ERROR)
		{
			throw SetErrorMsgText("closesocket: ", WSAGetLastError());
		}
		if (WSACleanup() == SOCKET_ERROR)
		{
			throw SetErrorMsgText("Cleanup", WSAGetLastError());
		}
		getchar();
	}
	catch (string errorMsgText) {
		cout << endl << errorMsgText;
	}
	return 0;
}

bool GetRequestFromClient(const char* name, short port, struct sockaddr* from, int* flen, SOCKET sS)
{
	int lb = 0;
	char buff[50];
	string str;
	while (true)
	{
		if ((lb == recvfrom(sS, buff, sizeof(buff), NULL, from, flen)) == SOCKET_ERROR)
		{
			if (WSAGetLastError() == WSAETIMEDOUT)
			{
				return false;
			}
			else
			{
				throw SetErrorMsgText("recvfrom: ", WSAGetLastError());
			}
		}
		str = buff;
		if (str == "Hello")
		{
			return true;
		}
	}
}

bool PutAnswerToClient(string name, struct sockaddr* to, int *lto, SOCKET sS)
{
	int lb = 0;
	if ((lb = sendto(sS, name.c_str(), sizeof(name), NULL, to, *lto)) == SOCKET_ERROR)
	{
		throw SetErrorMsgText("sendto: ", WSAGetLastError());
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
