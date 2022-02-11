#include <iostream>
#include <string>
#include "Windows.h"

using namespace std;

string SetPipeError(string msgText, int code);
string GetPipeError(int code);
string Counter(string buf);

int main()
{
	HANDLE cH;
	try
	{
		setlocale(LC_CTYPE, "Russian");
		if ((cH = CreateFile(L"\\\\Eugenee\\pipe\\Tube", GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, NULL, OPEN_EXISTING, NULL, NULL)) == INVALID_HANDLE_VALUE)
		{
			throw SetPipeError("createFile: ", GetLastError());
		}
		DWORD numWrite;
		string wbuff;
		string readMessage = "";
		int messageNumber;
		cout << "Введите количество передаваемых сообщений: ";
		cin >> messageNumber;
		for (int i = 0; i < messageNumber; i++)
		{
			wbuff = "Hello from Client " + Counter(readMessage);
			if (!WriteFile(cH, wbuff.c_str(), sizeof(wbuff), &numWrite, NULL))
			{
				throw SetPipeError("writeFile: ", GetLastError());
			}
			char rbuff[50];
			DWORD numRead;
			if (!ReadFile(cH, rbuff, sizeof(rbuff), &numRead, NULL))
			{
				throw SetPipeError("readFile: ", GetLastError());
			}
			readMessage = rbuff + '\0';
			cout << "message: " << readMessage << endl;
		}
		string endMessage = "";
		if (!WriteFile(cH, endMessage.c_str(), sizeof(wbuff), &numWrite, NULL))
		{
			throw SetPipeError("writeFile: ", GetLastError());
		}
		if (!CloseHandle(cH))
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

string Counter(string buf)
{
	string number;
	int intnumber;
	for (int i = 0; i < buf.length(); i++)
	{
		if (buf[i] >= '0' && buf[i] <= '9')
		{
			number = number + buf[i];
		}
	}
	if (strlen(number.c_str()) == 0)
	{
		return "1";
	}
	intnumber = atoi(number.c_str());
	intnumber = intnumber + 1;
	return number = to_string(intnumber);
}

string SetPipeError(string msgText, int code)
{
	return msgText + GetPipeError(code);
}
string GetPipeError(int code)
{
	/*string errorMessage = "error";
	switch (code)
	{
	case ERROR_PIPE_NOT_CONNECTED: errorMessage = "ERROR_PIPE_NOT_CONNECTED"; break;
	}
	return errorMessage;*/
	cout << code << endl;
	return " ";
}