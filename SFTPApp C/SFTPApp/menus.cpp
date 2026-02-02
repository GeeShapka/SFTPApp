/*FILE: menus.cpp
* PROGRAMMER: George Shapka
* FIRST VERSION: 28/01/2026
* CONTENTS: this file contains functions for displaying and getting input for menus
*/

#include "menus.h"
#include "uiOperations.h"
#include "stringOperations.h"



int menu(struct Program* p, const char* menu, int options, bool universalBack)
{
	char inputChar = 0;
	int inputNumber = 0;
	while (1)
	{
		//clearStdin();

		//clear screen and reprint menu
		consoleWriteConst(ANSI_HOME_POSITION);
		consoleWriteConst(ANSI_CLEAR_SCREEN);
		consoleWriteLineConst(menu);

		//get user input and convert to int
		if (!consoleGetKey(&inputChar, p))
		{
			pressAnyKeyToContinue(p);
			continue;
		}
		inputNumber = atoi(&inputChar);

		//validate number
		if (0 >= inputNumber || inputNumber > options)
		{
			consoleWriteError(ERROR_INVALID_MENU_OPTION);
			pressAnyKeyToContinue(p);
			continue;
		}
		else
		{
			//set the option to the universal back option
			if (inputNumber == options && universalBack)
			{
				inputNumber = OPTION_UNIVERSAL_BACK;
			}
			return inputNumber;
		}
	}
}

int mainMenu(struct Program* p)
{
	return menu(p, MAIN_MENU, MAIN_MENU_OPTION_COUNT, DOES_NOT_HAVE_UNIVERSAL_BACK);
}

int configMenu(struct Program* p)
{
	return menu(p, CONFIG_MENU, CONFIG_MENU_OPTION_COUNT, HAS_UNIVERSAL_BACK);
}

int localPathMenu(struct Program* p)
{
	return menu(p, LOCAL_PATH_MENU, LOCAL_PATH_MENU_OPTION_COUNT, HAS_UNIVERSAL_BACK);
}

int remotePathMenu(struct Program* p)
{
	return menu(p, REMOTE_PATH_MENU, REMOTE_PATH_MENU_OPTION_COUNT, HAS_UNIVERSAL_BACK);
}

int operationMenu(struct Program* p)
{
	return menu(p, OPERATION_MENU, OPERATION_MENU_OPTION_COUNT, HAS_UNIVERSAL_BACK);
}

int transferMenu(struct Program* p)
{
	return menu(p, TRANSFER_MENU, TRANSFER_MENU_OPTION_COUNT, DOES_NOT_HAVE_UNIVERSAL_BACK);
}

bool getAddress(struct Program* p)
{
	bool numOne;
	bool numTwo;
	bool numThree;
	bool numFour;
	char numberBuffer;

	char inputBuffer[MAX_ADDRESS_STRING_SIZE] = { 0 };
	if (!consoleReadLine(MAX_ADDRESS_STRING_SIZE, inputBuffer))
	{
		return false;
	}
	//stringToUnsignedInt(inputBuffer, MAX_ADDRESS_STRING_SIZE)
	return true;
}