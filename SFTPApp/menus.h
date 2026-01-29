/*FILE: menus.h
* PROGRAMMER: George Shapka
* FIRST VERSION: 28/01/2026
* CONTENTS: this file contains menu related strings and function declarations
* for functions in menu.cpp
*/

#pragma once

#include "headers.h"

#define MAIN_MENU "1. Config\n2. Local Path\n3. Remote Path\n4. Operation\n5. Transfer\n6. Exit\n"
#define MAIN_MENU_OPTION_COUNT 6

//1
#define CONFIG_MENU "1. Set Remote IP\n2. Set Remote User\n3. Set Remote Password\n"
//2
#define LOCAL_PATH_MENU "1. Saved Paths\n2. Browse Local Files\n3. Enter Path Manualy\n"
//3
#define REMOTE_PATH_MENU "1. Saved Paths\n2. Browse Remote Files\n3. Enter Path Manualy\n"
//4
#define OPERATION_MENU "1. PUT\n"
//5
#define TRANSFER_MENU "Confirmation\n1. Proceed\n2. Cancel\n"



/**
* displays the main menu and gets the chosen option from the user 
*/
int mainMenu(void);