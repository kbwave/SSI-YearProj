#include "kbwaveStringBuilder.h"

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>

#define DEF_CAPACITY 16

//using namespace std;

void AllocateMemory(char** string, int capacity);
int GetNewCapacity(char* string);
int GetNextCapacity(int capacity);

//««*********************Private*********************««

//Update String's Memory Capacity
void kbwaveStringBuilder::UpdateStringMemory()
{
	char* newString = NULL;

	//newString = (char*)malloc(sizeof(char) * (_capacity));
	AllocateMemory(&newString, _capacity);

	printf("%s %s\n", newString, _string);

	strcpy_s(newString, _capacity, _string);

	//Update Address
	*_string = *newString;
	//Free Memory
	free(newString);
}

//Update String(Caution!Premise Allocate Memory)
void kbwaveStringBuilder::UpdateString(char* argString)
{
	strcpy_s(_string, _capacity, argString);
}

//ªª*********************Private*********************ªª

//««*********************Public*********************««
//Constructor Def Set String
//kbwaveStringBuilder::kbwaveStringBuilder(char* argString, int argCapacity)
//{
//	int Lenght = 0;
//	int needCapacity = DEF_CAPACITY;
//
//	_capacity = argCapacity;
//	Lenght = int(strlen(argString));
//
//	needCapacity = GetNewCapacity(argString);
//
//	//Set Need Capacity
//	if (_capacity < needCapacity){
//		//_capacity = needCapacity;
//		Capacity(argCapacity);
//	}
//
//	UpdateStringMemory();
//
//}

//Constructor Def Set String
kbwaveStringBuilder::kbwaveStringBuilder(char* argString)
{
	/*int Lenght = 0;
	Lenght = int(strlen(argString));*/

	//Check the buffer size
	//if (Lenght + 1 < _capacity){
	//	Capacity(Lenght);
	//}

	//Update string
	int needCapacity = DEF_CAPACITY;
	needCapacity = GetNewCapacity(argString);
}

//Constructor Simple
kbwaveStringBuilder::kbwaveStringBuilder()
{
	_capacity = DEF_CAPACITY;
	//_string = (char*)malloc(sizeof(char) * DEF_CAPACITY);
	AllocateMemory(&_string, DEF_CAPACITY);
}

//Destructor
kbwaveStringBuilder::~kbwaveStringBuilder()
{
	free(_string);
}

//Append String
void kbwaveStringBuilder::Append(char* argString)
{
	int length = 0;

	length = int(strlen(argString));

	UpdateStringMemory();



}

//Set Capacity
void kbwaveStringBuilder::Capacity(int argCapacity)
{
	if (_capacity < argCapacity){
		_capacity = argCapacity;
		UpdateStringMemory();
	}
}

//Get Capacity
int kbwaveStringBuilder::Capacity()
{
	return _capacity;
}

//ªª*********************Public*********************ªª

//««*********************Function*********************««

//Allocate Memory
void AllocateMemory(char** argString, int argCapacity)
{
	*argString = (char*)malloc(sizeof(char) * (argCapacity + 1));
}

//Get Need next Capacity
int GetNewCapacity(char* argString)
{
	/*
	int newCapacity = 0;
	double logNewCapacity = 0.0;

	logNewCapacity = log2(double(strlen(argString) + 1));
	newCapacity = int(logNewCapacity);

	//If logNewCapacity is Number then Power of 2
	if (logNewCapacity != double(newCapacity)){
		newCapacity++;
	}
	
	return (2<<(newCapacity));
	*/
	return GetNextCapacity(int(strlen(argString) + 1));	
}

//Get Next Capacity(Include Null Char)
int GetNextCapacity(int argCapacity)
{
	double logNextCapacity = 0.0;
	int nextCapacity = 0;

	logNextCapacity = log2(double(argCapacity));
	nextCapacity = int(logNextCapacity);

	if (logNextCapacity != double(nextCapacity)){
		nextCapacity++;
	}

	return (2 << (nextCapacity));
}


//ªª*********************Function*********************ªª
