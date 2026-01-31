/*FILE: menus.cpp
* PROGRAMMER: George Shapka
* FIRST VERSION: 28/01/2026
* CONTENTS: this file contains functions for displaying and getting input for menus
*/

#include "menus.h"
#include "uiOperations.h"


int mainMenu(struct Program* p)
{
	char inputChar = 0;
	int inputNumber = 0;
	while (1)
	{
		//clearStdin();

		//clear screen and reprint menu
		consoleWriteConst(ANSI_HOME_POSITION);
		consoleWriteConst(ANSI_CLEAR_SCREEN);
		consoleWriteLineConst(MAIN_MENU);

		//get user input and convert to int
		if(!consoleGetKey(&inputChar, p)) 
		{ 
			pressAnyKeyToContinue(p);
			continue; 
		}
		inputNumber = atoi(&inputChar);

		//validate number
		if (0 >= inputNumber || inputNumber > MAIN_MENU_OPTION_COUNT)
		{ 
			consoleWriteError(ERROR_INVALID_MENU_OPTION);
			pressAnyKeyToContinue(p);
			continue; 
		}
		else
		{
			return inputNumber;
		}
	}
}