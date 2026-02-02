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
#include "stringOperations.h"

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
	char str[11] = "4294967295";
	int ans = 0;

	int mainMenuOption = 0;
	bool doMainLoop = true;
	bool doConfigLoop = true;
	bool doLocalPathLoop = true;
	bool doRemotePathLoop = true;
	bool doOperationLoop = true;

	//program loop
	while (doMainLoop)
	{
		switch (mainMenu(p))
		{
		case OPTION_CONFIG:
			doConfigLoop = true;
			while (doConfigLoop)
			{
				switch (configMenu(p))
				{
				case OPTION_UNIVERSAL_BACK:
					doConfigLoop = false;
					break;
				default:
					break;
				}
			}
			break;
		case OPTION_LOCAL_PATH:
			doLocalPathLoop = true;
			while (doLocalPathLoop)
			{
				switch (localPathMenu(p))
				{
				case OPTION_UNIVERSAL_BACK:
					doLocalPathLoop = false;
					break;
				default:
					break;
				}
			}
			break;
		case OPTION_REMOTE_PATH:
			doRemotePathLoop = true;
			while (doRemotePathLoop)
			{
				switch (remotePathMenu(p))
				{
				case OPTION_UNIVERSAL_BACK:
					doRemotePathLoop = false;
					break;
				default:
					break;
				}
			}
			break;
		case OPTION_OPERATION:
			doOperationLoop = true;
			while (doOperationLoop)
			{
				switch (operationMenu(p))
				{
				case OPTION_UNIVERSAL_BACK:
					doOperationLoop = false;
					break;
				default:
					break;
				}
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
			doMainLoop = false;
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