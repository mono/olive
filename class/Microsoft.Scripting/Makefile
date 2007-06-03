thisdir = class/Microsoft.Scripting
include ../../build/rules.make

LIBRARY = Microsoft.Scripting.dll

LIB_MCS_FLAGS = -r:System.dll

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
