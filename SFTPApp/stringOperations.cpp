/*FILE: stringOperations.cpp
* PROGRAMMER: George Shapka
* FIRST VERSION: 28/01/2026
* CONTENTS: this file contains functions for manipulating strings
*/

#include "stringOperations.h"

bool removeTrailingNewLine(char* string, size_t maxLength)
{
	size_t length = strnlen(string, maxLength);
	if (string[length - 1] == '\n')
	{
		string[length - 1] = '\0';
		return true;
	}
	return false;
}