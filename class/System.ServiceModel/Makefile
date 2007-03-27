thisdir = class/System.ServiceModel
SUBDIRS = 
include ../../build/rules.make

RESOURCE_FILES = \
	resources/WS-Addressing.schema

LIBRARY = System.ServiceModel.dll
LIB_MCS_FLAGS = \
		/nowarn:414,169,67,3005,436 \
		/unsafe \
	        /r:System.dll \
	        /r:System.Xml.dll \
	        /r:System.Configuration.dll \
	        /r:../lib/net_3_0/System.Runtime.Serialization.dll \
	        /r:System.Security.dll \
	        /r:../lib/net_3_0/System.IdentityModel.dll \
		/r:../lib/net_3_0/System.IdentityModel.Selectors.dll \
	        /r:System.Transactions.dll \
	        /r:System.Web.dll \
		/r:System.Web.Services.dll \
		/r:Mono.Security.dll \
		$(RESOURCE_FILES:%=/resource:%)

TEST_MCS_FLAGS = $(LIB_MCS_FLAGS)

EXTRA_DISTFILES = $(RESOURCE_FILES)

# This is a WinFX only assembly
VALID_PROFILE := $(filter net_3_0, $(PROFILE))
ifndef VALID_PROFILE
LIBRARY_NAME = dummy-System.ServiceModel.dll
NO_INSTALL = yes
NO_SIGN_ASSEMBLY = yes
NO_TEST = yes
endif


include ../../build/library.make
