thisdir = class/System.ServiceModel.Web
SUBDIRS = 
include ../../build/rules.make

LIBRARY = System.ServiceModel.Web.dll
LIB_MCS_FLAGS = -r:System.dll -r:System.Xml.dll

TEST_MCS_FLAGS = $(LIB_MCS_FLAGS)

EXTRA_DISTFILES = $(RESOURCE_FILES)

# This is a WinFX only assembly
VALID_PROFILE := $(filter net_3_0, $(PROFILE))
ifndef VALID_PROFILE
LIBRARY_NAME = dummy-System.ServiceModel.Web.dll
NO_INSTALL = yes
NO_SIGN_ASSEMBLY = yes
NO_TEST = yes
endif

test-data-ondotnet:
	csc -out:SyndicationSerializerUtil.exe -r:System.ServiceModel.Web.dll $(LIB_MCS_FLAGS) Test\\SyndicationSerializerUtil.cs Test\\SyndicationSerializerLib.cs
	./SyndicationSerializerUtil.exe

test-data:
	$(LIBRARY_COMPILE) Test/SyndicationSerializerUtil.cs Test/SyndicationSerializerLib.cs -out:SyndicationSerializerUtil.exe -r:System.ServiceModel.Web.dll $(LIB_MCS_FLAGS)
	./SyndicationSerializerUtil.exe

include ../../build/library.make
