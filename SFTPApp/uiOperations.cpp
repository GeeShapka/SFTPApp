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

bool getUserInput(int maxLength, char* buffer)
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

/// <summary>
/// prompt the user to press a key to continue
/// </summary>
/// <param name=""></param>
void pressAnyKeyToContinue(void)
{
	consoleWriteLineConst(PRESS_ENTER_STRING);
	char buffer[MAX_INPUT_BUFFER_STRING_SIZE] = { 0 };
	fgets(buffer, MAX_INPUT_BUFFER_STRING_SIZE, stdin);
}