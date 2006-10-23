thisdir = tools/sts
SUBDIRS = 
include ../../build/rules.make

LOCAL_MCS_FLAGS = \
	-r:$(topdir)/class/lib/net_3_0/System.Runtime.Serialization.dll \
	-r:$(topdir)/class/lib/net_3_0/System.IdentityModel.dll \
	-r:$(topdir)/class/lib/net_3_0/System.ServiceModel.dll
PROGRAM = sts.exe

run-server:
	mono --debug sts.exe --certfile:test.pfx --certpass:mono --no-nego --no-sc

run-client:
	mono --debug testclient.exe --no-nego --no-sc

include ../../build/executable.make
