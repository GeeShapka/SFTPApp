/*FILE: main.cpp
* PROGRAMMER: George Shapka
* FIRST VERSION: 28/01/2026
* CONTENTS: this file contains the main program loop
*/
//lets me not need _s funstions

#include "headers.h"
#include "uiOperations.h"
#include "menus.h"
#include "sftp.h"

int main(void)
{
	int mainMenuOption = 0;
	bool doLoop = true;
	while (doLoop)
	{
		switch (mainMenu())
		{
		case 6://exit
			doLoop = false;
			break;
		default:
			break;
		}
	}

	consoleWriteConst(ANSI_HOME_POSITION);
	consoleWriteConst(ANSI_CLEAR_SCREEN);
	return EXIT_SUCCESS;
}