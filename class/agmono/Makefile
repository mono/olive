thisdir = class/agmono
include ../../build/rules.make

LIBRARY = agmono.dll

LIB_MCS_FLAGS = -r:System -d:AGCLR -unsafe

include ../../build/library.make

check:
	cd scripts && make check