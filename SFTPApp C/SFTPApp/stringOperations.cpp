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

bool stringToUnsignedInt(char* string, int maxLength, int* result)
{
	//string is more characters than possible int length
	if ((maxLength - 1) > 10)
	{
		return false;
	}
	int digits[10] = { 0 };
	(*result) = 0;
	int length = strnlen(string, maxLength);

	for (int i = 0; i < (maxLength - 1); i++)
	{
		switch (string[i])
		{
		case '0':
			digits[i] = 0;
			break;
		case '1':
			digits[i] = 1;
			break;
		case '2':
			digits[i] = 2;
			break;
		case '3':
			digits[i] = 3;
			break;
		case '4':
			digits[i] = 4;
			break;
		case '5':
			digits[i] = 5;
			break;
		case '6':
			digits[i] = 6;
			break;
		case '7':
			digits[i] = 7;
			break;
		case '8':
			digits[i] = 8;
			break;
		case '9':
			digits[i] = 9;
			break;
		default:
			return false;
		}
	}

	int y = 0;
	for (int i = (length - 1); i >= 0; i--)
	{
		digits[i] = digits[i] * (int)pow((double)10, (double)y);
		(*result) += digits[i];
		y++;
	}
	return true;
}