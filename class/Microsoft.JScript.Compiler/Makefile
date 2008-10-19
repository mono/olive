thisdir = class/Microsoft.JScript.Compiler
SUBDIRS = 
include ../../build/rules.make

LIBRARY = Microsoft.JScript.Compiler.dll

LIB_MCS_FLAGS =\
	-r:/home/dufoli/MS\ SILVERLIGHT/Microsoft.Scripting.dll\
	-r:/home/dufoli/MS\ SILVERLIGHT/Microsoft.Scripting.Core.dll\
       	-r:../lib/net_2_1/System.dll

TEST_MCS_FLAGS = $(LIB_MCS_FLAGS)

EXTRA_DISTFILES = $(RESOURCE_FILES)

# This is a Silverlight assembly
VALID_PROFILE := $(filter net_2_1, $(PROFILE))
ifndef VALID_PROFILE
LIBRARY_NAME = dummy-Microsoft.JScript.Compiler.dll
NO_INSTALL = yes
NO_SIGN_ASSEMBLY = yes
NO_TEST = yes
endif

include ../../build/library.make
