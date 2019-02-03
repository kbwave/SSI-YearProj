#include <stdio.h>
#include <string.h>
#include "kbwaveStringBuilder.h"

void BehaveString(void);
void BehaveStringBuilder(void);

int main(int argc, char *argv[])
{
	/*
	char* test = "test";
	char test2[8] = {'t', 'e', 's', 't', '!', '\0'};
	char test2[6] = { 't', 'e', 's', 't', '!'};
	printf("%sF%d\n", test, int(strlen(test)));
	printf("%sF%d\n", test2, int(strlen(test2)));
	*/
	/*
	char test1[8] = {'t', 'e', 's', 't', '\0', '!', '\0'};
	printf("%s\n", test1);
	for (int i  = 0; i  < sizeof(test1) - 1; i ++){
		printf("%c", test1[i]);
	}
	printf("\n");
	*/
	/*
	char test3[1];
	printf("FirstState:%d\n", test3[0]);
	strcpy_s(test3, 1, "\0");
	printf("SetCharactor:%d\n", test3[0]);
	*/

	kbwaveStringBuilder kSB;
	char numString[4];
	//&kSB = new kbwaveStringBuilder;

	for (int i = 0; i < 100; i++){
		sprintf_s(numString, "%03d", i);
		kSB.Append(numString);
	}

	return 0;
}

//String‚Ì‚æ‚¤‚ÈU‚é•‘‚¢‚ğ‚³‚¹‚é
void BehaveString(void)
{

}

//StringBuilder‚Ì‚æ‚¤‚ÈU‚é•‘‚¢‚ğ‚³‚¹‚é
void BehaveStringBuilder(void)
{

}