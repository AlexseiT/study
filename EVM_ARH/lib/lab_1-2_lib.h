#pragma once

#include <stdio.h>
#include <stdlib.h>

#define SIZE_MEMORY 100
#define REGISTER_OVERFLOW 1                // Ï
#define REGISTER_DIVISION_BY_ZERO 2        // 0
#define REGISTER_MEMORY_ERROR_BORDERS 4    // Ì
#define REGISTER_TICK_IGNORET 8            // Ò
#define REGISTER_WRONG_COMMAND 16          // Å

int memory[SIZE_MEMORY];
int flag = 0;
int sc_memoryInit() {
for (int i = 0; i < SIZE_MEMORY; i++) memory[i] = 0;
return 0;
};

int sc_memorySet(int address, int value) {
	if (address < SIZE_MEMORY && address >= 0) {
		memory[address] = value;
		return 0;
	}
	else 
	{
		sc_regSet(REGISTER_MEMORY_ERROR_BORDERS, true);
		return -1;
	}
	return 0;
};

int sc_memoryGet(int address, int* value) {
	if (address < SIZE_MEMORY && address >= 0) {
		*value = memory[address];
		return 0;
	}
	else
	{
		sc_regSet(REGISTER_MEMORY_ERROR_BORDERS, true);
		return -1;
	}
	return 0;
};

int sc_memorySave(char* filename) {
	FILE* file;
	if ((file = fopen(filename, "wb")) != NULL) {
		fwrite(memory, sizeof(int), SIZE_MEMORY, file);
		fclose(file);
		return 0;
	}
	return -1;
};
int sc_memoryLoad(char* filename) {
	FILE* file;
	if ((file = fopen(filename, "rb")) != NULL) {
		fread(memory, sizeof(int), SIZE_MEMORY, file);
		fclose(file);
		return 0;
	}
	return -1;
};
int sc_regInit() {
	flag = 0;
	return 0;
};
int sc_regSet(int registr, int value) {
	if ((value != 0) && (value != 1)) {
		return -1;
	}
	if ((registr != REGISTER_OVERFLOW) 
	 && (registr != REGISTER_DIVISION_BY_ZERO) 
	 && (registr != REGISTER_MEMORY_ERROR_BORDERS) 
	 && (registr != REGISTER_TICK_IGNORET)
	 && (registr != REGISTER_WRONG_COMMAND)) return -1;

	if (value) flag |= registr;

	else flag &= ~registr;

	return 0;
};
	int sc_regGet(int registr, int* value) {
		if ((registr != REGISTER_OVERFLOW)
			&& (registr != REGISTER_DIVISION_BY_ZERO)
			&& (registr != REGISTER_MEMORY_ERROR_BORDERS)
			&& (registr != REGISTER_TICK_IGNORET)
			&& (registr != REGISTER_WRONG_COMMAND)) return -1;
		if ((flag & registr) == registr)
			*value = 1;
		else
			*value = 0;
		return 0;
	}
	int sc_commandEncode(int command, int operand, int* value) {
		char error = false;
		if ((command < 0) || (command > 0x7F)) {
			sc_regSet(REGISTER_WRONG_COMMAND, true);
			error = true;
		}
		if ((operand < 0) || (operand > 0x7F)) {
			sc_regSet(REGISTER_WRONG_COMMAND, true);
			error = true;
		}
		if (error == true) {
			return -1;
		}

		*value = command;

		*value = (*value << 7) + operand;

		return 0;
	};
	int sc_commandDecode(int value, int* command, int* operand)
	{
		int temp1 = value & 0x7F;
		int temp2 = (value >> 7) & 0x7F;

		if (((temp2 >= 0x10) && (temp2 <= 0x11)) || ((temp2 >= 0x20) && (temp2 <= 0x21)) ||
			((temp2 >= 0x30) && (temp2 <= 0x33)) || ((temp2 >= 0x40) && (temp2 <= 0x43)) ||
			((temp2 >= 0x51) && (temp2 <= 0x76))) {
			*command = temp2;  
			*operand = temp1;
			return 0;
		}
		else {
			sc_regSet(REGISTER_WRONG_COMMAND, true);
			return -1;
		}
	};

