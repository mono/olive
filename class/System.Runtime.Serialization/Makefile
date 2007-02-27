thisdir = class/System.Runtime.Serialization
SUBDIRS = 
include ../../build/rules.make

RESOURCE_FILES = \
	resources/mstypes.schema

LIBRARY = System.Runtime.Serialization.dll
LIB_MCS_FLAGS = \
	        /r:System.dll \
	        /r:System.Xml.dll \
		/r:System.Configuration.dll \
		$(RESOURCE_FILES:%=/resource:%)

TEST_MCS_FLAGS = $(LIB_MCS_FLAGS) /r:System.ServiceModel.dll

EXTRA_DISTFILES = $(RESOURCE_FILES)

# This is a WinFX only assembly
VALID_PROFILE := $(filter net_3_0, $(PROFILE))
ifndef VALID_PROFILE
LIBRARY_NAME = dummy-System.Runtime.Serialization.dll
NO_INSTALL = yes
NO_SIGN_ASSEMBLY = yes
NO_TEST = yes
endif

include ../../build/library.make
