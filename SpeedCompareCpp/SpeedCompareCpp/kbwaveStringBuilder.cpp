#include "kbwaveStringBuilder.h"

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>

#define DEF_CAPACITY 16

//using namespace std;

int GetNewCapacity(char* string);

//««*********************Private*********************««
//Update String's Memory Capacity
void kbwaveStringBuilder::UpdateStringMemory()
{
	char* newString;

	newString = (char*)malloc(sizeof(char) * (_capacity + 1));
	strcpy(newString, _string);

	//Update Address
	*_string = *newString;
	//Free Memory
	free(newString);
}

//Constructor Def Set String
kbwaveStringBuilder::kbwaveStringBuilder(char* string, int capacity)
{
	int Lenght = 0;
	int needCapacity = DEF_CAPACITY;

	_capacity = capacity;
	Lenght = strlen(string);

	needCapacity = GetNewCapacity(string);

	//Set Need Capacity
	if (_capacity < needCapacity){
		//_capacity = needCapacity;
		
	}


}
//ªª*********************Private*********************ªª

//««*********************Public*********************««
//Constructor Simple
kbwaveStringBuilder::kbwaveStringBuilder()
{
	_string = (char*)malloc(sizeof(char) * DEF_CAPACITY);
}

//Constructor Def Set String
kbwaveStringBuilder::kbwaveStringBuilder(char* string)
{
	int Lenght = 0;

	Lenght = strlen(string);

}

//Set Capacity
void kbwaveStringBuilder::Capacity(int capacity)
{
	if (_capacity < capacity){
		_capacity = capacity;
		UpdateStringMemory();
	}
}
//ªª*********************Public*********************ªª

//««*********************Function*********************««
//Get Need next Capacity
int GetNewCapacity(char* string)
{
	int newCapacity = 0;
	double logNewCapacity = 0.0;

	logNewCapacity = log2(double(strlen(string) + 1));
	newCapacity = int(logNewCapacity);

	//If logNewCapacity is Number then Power of 2
	if (logNewCapacity != double(newCapacity)){
		newCapacity++;
	}

	return (2<<(newCapacity));
}
//ªª*********************Function*********************ªª
