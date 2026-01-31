/*FILE: uiOpperations.cpp
* PROGRAMMER: George Shapka
* FIRST VERSION: 28/01/2026
* CONTENTS: this file contains UI related operations
*/

#include "uiOperations.h"

bool consoleWrite(char* message)
{
	printf("%s", message);
	return true;
}

bool consoleWriteConst(const char* message)
{
	printf("%s", message);
	return true;
}

bool consoleWriteLine(char* message)
{
	size_t length = 0;
	length = strnlen(message, MAX_STRING_SIZE);
	if(message[length - 1] != '\n')
	{
		printf("%s\n", message);
	}
	else
	{
		printf("%s", message);
	}
	return true;
}

bool consoleWriteLineConst(const char* message)
{
	size_t length = 0;
	length = strnlen(message, MAX_STRING_SIZE);
	if(message[length - 1] != '\n')
	{
		printf("%s\n", message);
	}
	else
	{
		printf("%s", message);
	}
	return true;
}

bool consoleWriteError(const char* error)
{
	char err[MAX_ERROR_STRING_SIZE] = { 0 };
	strncpy(err, error, MAX_ERROR_STRING_SIZE);
	if (!consoleWriteLine(err)) { return false; }
	return true;
}

bool consoleReadLine(int maxLength, char* buffer)
{
	if (buffer == NULL)
	{
		consoleWriteError(ERROR_NULL_POINTER_DEREFERENCE);
		return false;
	}
	if (fgets(buffer, maxLength, stdin) == NULL)
	{
		consoleWriteError(ERROR_NULL_USER_INPUT);
		return false;
	}
	return true;
}

bool consoleGetKey(char* key, struct Program* p)
{
	bool result = false;
	switch (p->os)
	{
	case WINDOWS:
		result = consoleGetKey_Win(key);
		break;
	case LINUX:
		result = consoleGetKey_Linux(key);
		break;
	default:
		break;
	}
	return result;
}

bool consoleGetKey_Win(char* key)
{
	*key = _getch();
	if (key == NULL) { return false; }
	return true;
}

bool consoleGetKey_Linux(char* key)
{
	char buffer[MAX_STRING_SIZE] = { 0 };
	if (fgets(buffer, MAX_STRING_SIZE, stdin) == NULL)
	{
		consoleWriteError(ERROR_NULL_USER_INPUT);
		return false;
	}
	*key = buffer[0];
	return true;
}

void pressAnyKeyToContinue(struct Program* p)
{
	switch (p->os)
	{
	case WINDOWS:
		pressAnyKeyToContinue_Win();
		break;
	case LINUX:
		pressAnyKeyToContinue_Linux();
		break;
	default:
		break;
	}
}

void pressAnyKeyToContinue_Win(void)
{
	consoleWriteLineConst(PRESS_ENTER_STRING);
	char c = 0;
	consoleGetKey_Win(&c);
}

void pressAnyKeyToContinue_Linux(void)
{
	consoleWriteLineConst(PRESS_ENTER_STRING);
	char buffer[MAX_INPUT_BUFFER_STRING_SIZE] = { 0 };
	consoleReadLine(MAX_INPUT_BUFFER_STRING_SIZE, buffer);
}