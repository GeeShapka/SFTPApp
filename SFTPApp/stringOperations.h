/*FILE: stringOperations.h
* PROGRAMMER: George Shapka
* FIRST VERSION: 28/01/2026
* CONTENTS: this file contains function declarations for stringOperations.cpp
*/

#pragma once
#include "headers.h"

/// <summary>
/// removes the trailing newLine character from a string
/// </summary>
/// <param name="string">-the string you want the newLine removed from</param>
/// <param name="maxLength">-the max length the string was initialized with or the length of the string</param>
/// <returns>
/// true: it removed the newLine.
/// false: no newLine to remove
/// </returns>
bool removeTrailingNewLine(char*, size_t);


bool stringToUnsignedInt(char* string, int maxLength, int* result);

