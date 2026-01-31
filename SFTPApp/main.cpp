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

void cleanUp(struct Program*);

int main(void)
{
	//alocate memory needed during runtime
	struct Program* p = (struct Program*)calloc(1, sizeof(struct Program));
	if (p == NULL)
	{
		consoleWriteError(ERROR_COULD_NOT_ALLOCATE);
		return EXIT_FAILURE;
	}

	//set the os being used
	#ifdef _WIN32
	p->os = 1;
	#elif __linux__
	p->os = 2;
	#endif

	//if os is unsupported
	if (p->os == 0)
	{
		consoleWriteLineConst("Cannot detect OS, or OS is not supported");
		cleanUp(p);
		return EXIT_FAILURE;
	}

	int mainMenuOption = 0;
	bool doLoop = true;

	//program loop
	while (doLoop)
	{
		switch (mainMenu(p))
		{
		case OPTION_CONFIG:
			switch (configMenu(p))
			{
			default:
				break;
			}
			break;
		case OPTION_LOCAL_PATH:
			switch (localPathMenu(p))
			{
			default:
				break;
			}
			break;
		case OPTION_REMOTE_PATH:
			switch (remotePathMenu(p))
			{
			default:
				break;
			}
			break;
		case OPTION_OPERATION:
			switch (operationMenu(p))
			{
			default:
				break;
			}
			break;
		case OPTION_TRANSFER:
			switch (transferMenu(p))
			{
			default:
				break;
			}
			break;
		case OPTION_EXIT:
			doLoop = false;
			break;
		default:
			break;
		}
	}

	consoleWriteConst(ANSI_HOME_POSITION);
	consoleWriteConst(ANSI_CLEAR_SCREEN);

	cleanUp(p);
	return EXIT_SUCCESS;
}



/// <summary>
/// frees allocated memory
/// </summary>
/// <param name="p"></param>
void cleanUp(struct Program* p)
{
	if (p != NULL)
	{
		free(p);
		p = NULL;
	}
	return;
}