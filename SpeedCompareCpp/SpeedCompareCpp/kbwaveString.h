#ifndef _KBWAVESTRING_H_
#define _KBWAVESTRING_H_

//#include <string.h>

class kbwaveString
{
private:
	char* string;
	int length = 0;

public:
	//Constructor
	kbwaveString();
	kbwaveString(char* string);
	//Destructor
	~kbwaveString();
	
	//Set String Value
	void SetString(char* string);
	//Get Number of Charachors
	int GetStringLength(void);
};
#endif //_KBWAVESTRING_H_