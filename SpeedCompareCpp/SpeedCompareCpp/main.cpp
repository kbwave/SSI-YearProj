#include <stdio.h>
#include <string.h>
//#include <time.h>
#include <Windows.h>
#include "kbwaveStringBuilder.h"

#define LOOP_CNT 8100
#define CAPA_SIZ 8500
#define TEST_CNT 10

#pragma comment(lib, "winmm.lib")


int main(int argc, char *argv[])
{
	kbwaveStringBuilder normalSB;
	DWORD s_time, e_time;
	//clock_t s_time, e_time;

	for (int test = 0; test < TEST_CNT; test++){
		s_time = timeGetTime();
		//s_time = clock();
		for (int i = 0; i < LOOP_CNT; i++){
			normalSB.Append("a");
		}
		e_time = timeGetTime();
		//e_time = clock();
		//printf("%s\n", normalSB.ToString());
		//normalSB.~kbwaveStringBuilder();
		printf("Normal StringBuilder time is ->%d\n\n", e_time - s_time);
		//printf("Normal StringBuilder time is ->%d\n\n", e_time - s_time);


		kbwaveStringBuilder capadSB;
		capadSB.Capacity(9000);
		s_time = timeGetTime();
		//s_time = clock();
		for (int i = 0; i < LOOP_CNT; i++){
			capadSB.Append("a");
		}
		e_time = timeGetTime();
		//e_time = clock();
		//printf("%s\n", capadSB.ToString());
		//capadSB.~kbwaveStringBuilder();
		printf("Set Capacity StringBuilder time is ->%d\n\n", e_time - s_time);
		//printf("Set Capacity StringBuilder time is ->%d\n\n", e_time - s_time);
	}	

	printf("ë™íËèIóπÅB\n");
	getchar();
	return 0;
}
