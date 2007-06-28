thisdir = class/agmono
include ../../build/rules.make

LIBRARY = agmono.dll

LIB_MCS_FLAGS = -r:System -r:System.Xml -d:AGCLR -unsafe

include ../../build/library.make

check:
	cd scripts && make check