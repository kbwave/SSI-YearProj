#include <stdio.h>
#include <string.h>
//#include <time.h>
#include <Windows.h>
#include "kbwaveStringBuilder.h"

#define LOOP_CNT 65500
#define CAPA_SIZ 65536
#define TEST_CNT 10

#pragma comment(lib, "winmm.lib")


int main(int argc, char *argv[])
{	
	kbwaveStringBuilder normalSB, capadSB;
	DWORD s_time, e_time;
	//clock_t s_time, e_time;

	for (int test = 0; test < TEST_CNT; test++){		
		s_time = timeGetTime();
		//s_time = clock();
		//printf("Normal Capacity is %d\n", normalSB.Capacity());
		for (int i = 0; i < LOOP_CNT; i++){
			normalSB.Append("a");
		}
		e_time = timeGetTime();
		//e_time = clock();
		//printf("%s\n", normalSB.ToString());		
		//printf("Normal Capacity is %d\n", normalSB.Capacity());
		printf("Normal StringBuilder time is ->%d\n", e_time - s_time);
		//printf("Normal StringBuilder time is ->%d\n\n", e_time - s_time);
		normalSB.Clear();
		//normalSB.~kbwaveStringBuilder();

		/*capadSB.Capacity(CAPA_SIZ);
		s_time = timeGetTime();
		s_time = clock();
		printf("Set Capacity StringBuilder Capacity is %d\n", capadSB.Capacity());
		for (int i = 0; i < LOOP_CNT; i++){
			capadSB.Append("a");
		}
		e_time = timeGetTime();
		e_time = clock();
		printf("%s\n", capadSB.ToString());		
		printf("Set Capacity StringBuilder Capacity is %d\n", capadSB.Capacity());
		printf("Set Capacity StringBuilder time is ->%d\n\n", e_time - s_time);
		printf("Set Capacity StringBuilder time is ->%d\n\n", e_time - s_time);		
		capadSB.Clear();
		capadSB.~kbwaveStringBuilder();*/
	}

	for (int test = 0; test < TEST_CNT; test++){
		capadSB.Capacity(CAPA_SIZ);
		s_time = timeGetTime();
		for (int i = 0; i < LOOP_CNT; i++){
			capadSB.Append("a");
		}
		e_time = timeGetTime();
		printf("Set Capacity StringBuilder time is ->%d\n", e_time - s_time);
		capadSB.Clear();
	}

	printf("ë™íËèIóπÅB\n");
	//getchar();
	return 0;
}
