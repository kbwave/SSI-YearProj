#ifndef _KBWAVESTRINGBUILDER_H_
#define _KBWAVESTRINGBUILDER_H_

//#include <string.h>

class kbwaveStringBuilder
{
private:
	char* _string;
	int _length = 0;
	int _capacity = 0;
	int _capacityBit = 0;

	void Initialize(void);
	void UpdateStringMemory(void);
	void UpdateString(char *);
	void AppendString(char *);

public:
	//Constructor
	kbwaveStringBuilder();
	kbwaveStringBuilder(char* string);
	//kbwaveStringBuilder(char* string, int capacity);
	
	//Destructor
	~kbwaveStringBuilder();

	//Append String Value
	void Append(char* string);
	//Clear String
	void Clear(void);
	//Set Memory
	void Capacity(int bytes);
	int Capacity(void);

	char* ToString();
};
#endif //_KBWAVESTRINGBUILDER_H_