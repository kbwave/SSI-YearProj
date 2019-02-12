#include "kbwaveStringBuilder.h"

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>

#define DEF_CAPACITY 16

//using namespace std;

void AllocateMemory(char** string, int capacity);
int GetNewCapacity(int maxBit, char* string);
int GetNextCapacity(int maxBit, int capacity);

//««*********************Private*********************««

//Update String's Memory Capacity
void kbwaveStringBuilder::UpdateStringMemory()
{
	char* newString = NULL;

//#if _DEBUG
//	printf("UpdateStringMemory to %d\n", _capacity);
//#endif

	AllocateMemory(&newString, _capacity);

//#if _DEBUG
//	printf("_string is [%s]\n", _string);
//	printf("newString is [%s]\n", newString);	
//#endif

	strcpy_s(newString, _capacity, _string);

//#if _DEBUG
//	printf("original pointer is ->%p\n", _string);
//	printf("new string pointer is ->%p\n", newString);
//#endif

	//Free Original Pointer
	free(_string);

	//Update Address Pointer
	_string = newString;
	//_length = int(sizeof(_string));
//#if _DEBUG
//	printf("now _string pointer is ->%p\n", _string);
//#endif
}

//Update String(Caution!Premise Allocate Memory)
void kbwaveStringBuilder::UpdateString(char* argString)
{
	strcpy_s(_string, _capacity, argString);
	_length = int(strlen(_string));
}

//Initialize This Class After set capacity
void kbwaveStringBuilder::Initialize(void)
{
	//Byte = 8 bits
	_capacityBit = sizeof(_capacity) << 3;

	//preset
	_string = (char*)calloc(_capacity, sizeof(char));

	_length = int(strlen(_string));
}

//Append String To _string
void kbwaveStringBuilder::AppendString(char* addString)
{
	strcat_s(_string, _capacity, addString);
	//_length = int(strlen(_string));
}

//ªª*********************Private*********************ªª


//««*********************Public*********************««

//Constructor Def Set String
kbwaveStringBuilder::kbwaveStringBuilder(char* argString)
{
	//SetUp
	_capacity = GetNewCapacity(_capacityBit, argString);
	Initialize();	

	//Update string
	UpdateStringMemory();
	UpdateString(argString);
}

//Constructor Simple
kbwaveStringBuilder::kbwaveStringBuilder()
{
	_capacity = DEF_CAPACITY;
	Initialize();
	
	UpdateStringMemory();
}

//Destructor
kbwaveStringBuilder::~kbwaveStringBuilder()
{
	if (_string != NULL){
		free(_string);
	}	
}

//Clear
void kbwaveStringBuilder::Clear(void)
{
	char* newString = NULL;
	AllocateMemory(&newString, DEF_CAPACITY);
	_capacity = DEF_CAPACITY;
	_length = 0;
	free(_string);
	_string = newString;
}

//Append String
void kbwaveStringBuilder::Append(char* argString)
{
	int length = 0;
	length = int(strlen(argString));	

	int needCapacity = 0;
	needCapacity = GetNextCapacity(_capacityBit, _length + length);
	if (_capacity < needCapacity){
		_capacity = needCapacity;
		UpdateStringMemory();
	}
	
	AppendString(argString);
	_length += length;
}

//Set Capacity
void kbwaveStringBuilder::Capacity(int argCapacity)
{
	if (_capacity < argCapacity){
		_capacity = argCapacity;
		UpdateStringMemory();
	}
}

//Get Capacity Size
int kbwaveStringBuilder::Capacity(void)
{
	return _capacity;
}

//ToString
char* kbwaveStringBuilder::ToString(void)
{
	return _string;
}

//ªª*********************Public*********************ªª

//««*********************Function*********************««

//Allocate Memory
void AllocateMemory(char** argString, int argCapacity)
{
	*argString = (char*)calloc(argCapacity + 1, sizeof(char));
}

//Get Need next Capacity
int GetNewCapacity(int maxBit, char* argString)
{
	return GetNextCapacity(maxBit, int(strlen(argString) + 1));
}

//Get Next Capacity(Include Null Char)
int GetNextCapacity(int maxBit, int argCapacity)
{
	int shift = 0;

	for (int bitPosion = maxBit; bitPosion >= 0; bitPosion--){
		if ((argCapacity >> bitPosion) == 1){
			shift = bitPosion;
			break;
		}
	}

	return (1 << (shift + 1));
}


//ªª*********************Function*********************ªª
