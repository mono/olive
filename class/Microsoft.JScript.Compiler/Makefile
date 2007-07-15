thisdir = class/Microsoft.JScript.Compiler
SUBDIRS = 
include ../../build/rules.make

LIBRARY = Microsoft.JScript.Compiler.dll

LIB_MCS_FLAGS = -r:Microsoft.Scripting.dll -r:System.dll -r:Microsoft.JScript.Runtime.dll

TEST_MCS_FLAGS = $(LIB_MCS_FLAGS)

EXTRA_DISTFILES = $(RESOURCE_FILES)

# This is a Silverlight assembly
VALID_PROFILE := $(filter net_3_0, $(PROFILE))
ifndef VALID_PROFILE
LIBRARY_NAME = dummy-Microsoft.Scripting.Silverlight.dll
NO_INSTALL = yes
NO_SIGN_ASSEMBLY = yes
NO_TEST = yes
endif

include ../../build/library.make
