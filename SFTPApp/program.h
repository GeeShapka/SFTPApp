#pragma once



/// <summary>
/// contains variables needed throughout the runtime of the program
/// </summary>
struct Program
{
	//0 = undefined, 1 = windows, 2 = linux
	int os = 0;
};

#define WINDOWS 1
#define LINUX 2