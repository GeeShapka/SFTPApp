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