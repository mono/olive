thisdir = tools/client-proxy-gen
SUBDIRS = 
include ../../build/rules.make

LOCAL_MCS_FLAGS = \
	-r:Mono.GetOptions.dll \
	-r:System.Runtime.Serialization.dll \
	-r:System.ServiceModel.dll
PROGRAM = client-proxy-gen.exe

include ../../build/executable.make
