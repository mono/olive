thisdir = tools/sts
SUBDIRS = 
include ../../build/rules.make

LOCAL_MCS_FLAGS = \
	-r:System.Runtime.Serialization.dll \
	-r:System.IdentityModel.dll \
	-r:System.ServiceModel.dll
PROGRAM = sts.exe

run-server:
	mono --debug sts.exe --certfile:test.pfx --certpass:mono --no-nego --no-sc

run-client:
	mono --debug testclient.exe --no-nego --no-sc

include ../../build/executable.make
