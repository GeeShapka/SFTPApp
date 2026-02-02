#pragma once



/// <summary>
/// contains variables needed throughout the runtime of the program
/// </summary>
struct Program
{
	//0 = undefined, 1 = windows, 2 = linux
	int os = 0;
	char address[MAX_ADDRESS_STRING_SIZE];
	char username[MAX_USERNAME_STRING_SIZE];
	char password[MAX_PASSWORD_STRING_SIZE];
};

#define WINDOWS 1
#define LINUX 2