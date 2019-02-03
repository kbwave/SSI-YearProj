#ifndef _KBWAVESTRINGBUILDER_H_
#define _KBWAVESTRINGBUILDER_H_

//#include <string.h>

class kbwaveStringBuilder
{
private:
	char* _string;
	int _length = 0;
	int _capacity = 0;

	void UpdateStringMemory(void);

public:
	//Constructor
	kbwaveStringBuilder();
	kbwaveStringBuilder(char* string);
	kbwaveStringBuilder(char* string, int capacity);
	//Destructor
	~kbwaveStringBuilder();

	//Append String Value
	void Append(char* string);
	//Set Memory
	void Capacity(int bytes);
};
#endif //_KBWAVESTRINGBUILDER_H_