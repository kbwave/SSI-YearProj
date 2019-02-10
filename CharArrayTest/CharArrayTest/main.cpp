#include <stdio.h>
#include <stdlib.h>
#include <string.h>

//#define DEBUG

void CheckMallocState(char** check);

int main(int argc, char* argv[])
{
	char *dest, *org, *insert;

	dest = (char*)malloc(sizeof(char) * 256);
	CheckMallocState(&dest);


	org = (char*)malloc(sizeof(char) * 128);
	CheckMallocState(&org);

	insert = (char*)malloc(sizeof(char) * 128);
	CheckMallocState(&insert);

	strcpy_s(org, 128, "This String is Original.");	
#if _DEBUG
	for (int i = strlen(org) + 1; i < 128; i++){
		org[i] = '\0';
	}
	for (int i = 0; i < 128; i++){
		printf("%d ", org[i]);
}
#endif

	
	printf("\n");
	printf("%s\n", org);

	strcpy_s(insert, 128, "Insert String.");


	
	printf("%s\n", dest);

	//Free Process
	free(dest);
	free(org);
	free(insert);

	return 0;
}

/*
メモリの動的確保に成功している確認
*/
void CheckMallocState(char** check)
{
	if (*check == NULL){
		printf("char配列のメモリ確保に失敗しました。\n");
	}
}




