/*FILE: uiOperations.h
* PROGRAMMER: George Shapka
* FIRST VERSION: 28/01/2026
* CONTENTS: this file contains function declarations for uiOperations.cpp
*/

#pragma once
#include "headers.h"



/**
* writes a string to the console and adds a newLine character to the end.
* if string already has a trailing newLine, dont add
*/
bool consoleWrite(char*);

/**
* writes a string to the console and adds a newLine character to the end.
* if string already has a trailing newLine, dont add
*/
bool consoleWriteLine(char*);