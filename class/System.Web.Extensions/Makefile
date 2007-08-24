thisdir = class/System.Web.Extensions
SUBDIRS = 
include ../../build/rules.make

LIBRARY = System.Web.Extensions.dll
LIB_MCS_FLAGS = \
	        /r:System.dll \
	        /r:System.Xml.dll \
		/r:System.Web.dll \

TEST_MCS_FLAGS = $(LIB_MCS_FLAGS)

EXTRA_DISTFILES =

VALID_PROFILE := $(filter net_3_5, $(PROFILE))
ifndef VALID_PROFILE
LIBRARY_NAME = dummy-System.Web.Extensions.dll
NO_INSTALL = yes
NO_SIGN_ASSEMBLY = yes
NO_TEST = yes
endif
NO_SIGN_ASSEMBLY = yes

include ../../build/library.make
