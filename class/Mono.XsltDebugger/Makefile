thisdir = class/Mono.XsltDebugger
SUBDIRS = 
include ../../build/rules.make

RESOURCE_FILES = 

OTHER_RES = $(RESOURCE_FILES)

LIBRARY = Mono.XsltDebugger.dll
LIB_MCS_FLAGS = /r:$(corlib) /r:System.dll /r:System.Xml.dll \
	$(foreach r, $(OTHER_RES), /resource:$(r),$(notdir $(r)))
TEST_MCS_FLAGS = $(LIB_MCS_FLAGS) -nowarn:0618 -nowarn:219 -nowarn:169
EXTRA_DISTFILES = \
	$(RESOURCE_FILES)

include ../../build/library.make

$(the_lib): $(OTHER_RES)

dll-sources:
	ls ../../build/common/*.cs > $(LIBRARY).sources
	ls */*.cs >> $(LIBRARY).sources
