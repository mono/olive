thisdir = class/agclr
include ../../build/rules.make

LIBRARY = agclr.dll

LIB_MCS_FLAGS = -r:System -r:System.Xml -r:agmono -d:AGCLR -unsafe

include ../../build/library.make

check:
	cd scripts && make check