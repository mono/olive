thisdir = class/Microsoft.JScript.Runtime
include ../../build/rules.make

LIBRARY = Microsoft.JScript.Runtime.dll

LIB_MCS_FLAGS = \
	-r:/home/dufoli/MS\ SILVERLIGHT/Microsoft.Scripting.dll \
	-r:../lib/net_2_1/Microsoft.JScript.Compiler.dll \
	-r:System.dll

TEST_MCS_FLAGS = $(LIB_MCS_FLAGS)

# This is a Silverlight assembly
VALID_PROFILE := $(filter net_2_1, $(PROFILE))
ifndef VALID_PROFILE
LIBRARY_NAME = dummy-Microsoft.JScript.Runtime.dll
NO_INSTALL = yes
NO_SIGN_ASSEMBLY = yes
NO_TEST = yes
endif

include ../../build/library.make
