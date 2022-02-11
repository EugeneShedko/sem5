#include <iostream>
#include <string>
#include "Windows.h"

using namespace std;

string SetPipeError(string msgText, int code);
string GetPipeError(int code);

int main()
{
	HANDLE hPipe;
	try
	{
		if ((hPipe = CreateNamedPipe(L"\\\\.\\pipe\\Tube", PIPE_ACCESS_DUPLEX, PIPE_TYPE_MESSAGE | PIPE_WAIT, 1, NULL, NULL, INFINITE, NULL)) == INVALID_HANDLE_VALUE)
		{
			throw SetPipeError("createNamedPipe: ", GetLastError());
		}
		if (!ConnectNamedPipe(hPipe, NULL))
		{
			throw SetPipeError("connectNamedPipe: ", GetLastError());
		}
		char rbuff[50];
		DWORD numRead;
		string message;
		while (true)
		{
			if (!ReadFile(hPipe, rbuff, sizeof(rbuff), &numRead, NULL))
			{
				throw SetPipeError("readFile: ", GetLastError());
			}
			cout << "message: " << rbuff << endl;
			DWORD numWrite;
			message = rbuff;
			if (message == "")
			{
				break;
			}
			if (!WriteFile(hPipe, rbuff, sizeof(rbuff), &numWrite, NULL))
			{
				throw SetPipeError("writeFile: ", GetLastError());
			}
		}
		if (!DisconnectNamedPipe(hPipe))
		{
			throw SetPipeError("disconnectNamedPipe: ", GetLastError());
		}
		if (!CloseHandle(hPipe))
		{
			throw SetPipeError("closeHandle: ", GetLastError());
		}

	}
	catch (string errorMsgText)
	{
		cout << errorMsgText << endl;
	}
	getchar();
}

string SetPipeError(string msgText, int code)
{
	return msgText + GetPipeError(code);
}
string GetPipeError(int code)
{
	//string errorMessage = "error";
	//switch (code)
	//{
	//case ERROR_PIPE_NOT_CONNECTED: errorMessage = "ERROR_PIPE_NOT_CONNECTED"; break;
	//}
	//return errorMessage;
	cout << code << endl;
}
