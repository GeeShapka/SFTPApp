/*FILE: menus.h
* PROGRAMMER: George Shapka
* FIRST VERSION: 28/01/2026
* CONTENTS: this file contains menu related strings and function declarations
* for functions in menu.cpp
*/

#pragma once

#include "headers.h"


#define OPTION_UNIVERSAL_BACK 99
#define HAS_UNIVERSAL_BACK true
#define DOES_NOT_HAVE_UNIVERSAL_BACK false

#define MAIN_MENU "1. Config\n2. Local Path\n3. Remote Path\n4. Operation\n5. Transfer\n6. Exit\n"
#define MAIN_MENU_OPTION_COUNT 6
#define OPTION_CONFIG 1
#define OPTION_LOCAL_PATH 2
#define OPTION_REMOTE_PATH 3
#define OPTION_OPERATION 4
#define OPTION_TRANSFER 5
#define OPTION_EXIT 6

//1
#define CONFIG_MENU "1. Set Remote IP\n2. Set Remote User\n3. Set Remote Password\n4. Back\n"
#define CONFIG_MENU_OPTION_COUNT 4
#define OPTION_SET_REMOTE_IP 1
#define OPTION_SET_REMOTE_USER 2
#define OPTION_SET_REMOTE_PASSWORD 3
//2
#define LOCAL_PATH_MENU "1. Saved Paths\n2. Browse Local Files\n3. Enter Path Manualy\n4. Back\n"
#define LOCAL_PATH_MENU_OPTION_COUNT 4
#define OPTION_LOCAL_SAVED_PATHS 1
#define OPTION_BROWSE_LOCAL_FILES 2
#define OPTION_ENTER_LOCAL_PATH 3
//3
#define REMOTE_PATH_MENU "1. Saved Paths\n2. Browse Remote Files\n3. Enter Path Manualy\n4. Back\n"
#define REMOTE_PATH_MENU_OPTION_COUNT 4
#define OPTION_REMOTE_SAVED_PATHS 1
#define OPTION_BROWSE_REMOTE_FILES 2
#define OPTION_ENTER_REMOTE_PATH 3
//4
#define OPERATION_MENU "1. PUT\n2. Back\n"
#define OPERATION_MENU_OPTION_COUNT 2
#define OPTION_PUT 1
//5
#define TRANSFER_MENU "Confirmation\n1. Proceed\n2. Cancel\n"
#define TRANSFER_MENU_OPTION_COUNT 2
#define OPTION_PROCEED 1
#define OPTION_CANCEL 2


/// <summary>
/// displays a menu and gets input for the menu from the user
/// </summary>
/// <param name="p"></param>
/// <param name="menu"></param>
/// <param name="options"></param>
/// <returns>the chosen option</returns>
int menu(struct Program*, const char*, int, bool);

/// <summary>
/// gets the main menu option from the user
/// </summary>
/// <param name="p"></param>
/// <returns>the chosen option</returns>
int mainMenu(struct Program*);

/// <summary>
/// gets the config menu option from the user
/// </summary>
/// <param name="p"></param>
/// <returns>the chosen option</returns>
int configMenu(struct Program*);

/// <summary>
/// gets the local path menu option from the user
/// </summary>
/// <param name="p"></param>
/// <returns>the chosen option</returns>
int localPathMenu(struct Program*);

/// <summary>
/// gets the remote path menu option from the user
/// </summary>
/// <param name="p"></param>
/// <returns>the chosen option</returns>
int remotePathMenu(struct Program*);

/// <summary>
/// gets the operation menu option from the user
/// </summary>
/// <param name="p"></param>
/// <returns>the chosen option</returns>
int operationMenu(struct Program*);

/// <summary>
/// gets the transfer menu option from the user
/// </summary>
/// <param name="p"></param>
/// <returns>the chosen option</returns>
int transferMenu(struct Program*);