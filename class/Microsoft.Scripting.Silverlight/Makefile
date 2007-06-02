thisdir = class/Microsoft.Scripting.Silverlight
SUBDIRS = 
include ../../build/rules.make

RESOURCE_FILES =

LIBRARY = Microsoft.Scripting.Silverlight.dll
LIB_MCS_FLAGS = \
		/r:agclr.dll \
	        /r:System.dll \
		/r:System.Silverlight.dll \
		/r:Microsoft.Scripting.dll \
		$(RESOURCE_FILES:%=/resource:%)

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
