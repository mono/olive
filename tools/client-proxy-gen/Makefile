thisdir = tools/client-proxy-gen
SUBDIRS = 
include ../../build/rules.make

LOCAL_MCS_FLAGS = \
	-r:Mono.GetOptions.dll \
	-r:$(topdir)/class/lib/net_3_0/System.Runtime.Serialization.dll \
	-r:$(topdir)/class/lib/net_3_0/System.ServiceModel.dll
PROGRAM = client-proxy-gen.exe

include ../../build/executable.make
