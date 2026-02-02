/*FILE: uiOperations.h
* PROGRAMMER: George Shapka
* FIRST VERSION: 28/01/2026
* CONTENTS: this file contains function declarations for uiOperations.cpp
*/

#pragma once
#include "headers.h"

#define PRESS_ENTER_STRING "Press Enter To Continue"



/// <summary>
/// writes a string to the console and adds a newLine character to the end.
/// </summary>
/// <param name="message"></param>
/// <returns></returns>
bool consoleWrite(char*);

/// <summary>
/// writes a constant string to the console and adds a newLine character to the end.
/// </summary>
/// <param name="message"></param>
/// <returns></returns>
bool consoleWriteConst(const char*);

/// <summary>
/// writes a string to the console and adds a newLine character to the end.
/// if the string already has a trailing newLine, dont add
/// </summary>
/// <param name="message"></param>
/// <returns></returns>
bool consoleWriteLine(char*);

/// <summary>
/// writes a constant string to the console and adds a newLine character to the end.
/// if the string already has a trailing newLine, dont add
/// </summary>
/// <param name="message"></param>
/// <returns></returns>
bool consoleWriteLineConst(const char*);

/// <summary>
/// writes an error to the console
/// </summary>
/// <param name="error"></param>
/// <returns></returns>
bool consoleWriteError(const char* error);

/// <summary>
/// gets user input as a string.
/// ***does not remove the trailing new line***
/// </summary>
/// <param name="maxLength"></param>
/// <param name="buffer"></param>
/// <returns>
/// true: user input has been obtained.
/// false: no input or bad input was obtained
/// </returns>
bool consoleReadLine(int, char*);

/// <summary>
/// gets the next key the user presses
/// </summary>
/// <param name="key">a char* to hold the input</param>
/// <returns>
/// False if the ptr is NULL. True: otherwise</returns>
bool consoleGetKey(char*, struct Program*);

/// <summary>
/// gets the next key the user presses without enter being pressed
/// </summary>
/// <param name="key">a char* to hold the input</param>
/// <returns>
/// False if the ptr is NULL. True: otherwise</returns>
bool consoleGetKey_Win(char*);

/// <summary>
/// gets the next key the user presses by geting a string of characters and only keeping the first one
/// </summary>
/// <param name="key">a char* to hold the input</param>
/// <returns>
/// False if the ptr is NULL. True: otherwise</returns>
bool consoleGetKey_Linux(char*);

/// <summary>
/// prompt the user to press a key to continue, changes based on os
/// </summary>
/// <param name=""></param>
void pressAnyKeyToContinue(struct Program*);

/// <summary>
/// prompt the user to press a key to continue
/// </summary>
/// <param name=""></param>
void pressAnyKeyToContinue_Win(void);

/// <summary>
/// prompt the user to press a key to continue
/// </summary>
/// <param name=""></param>
void pressAnyKeyToContinue_Linux(void);
