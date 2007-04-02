thisdir = class/System.Data.Linq.Design
SUBDIRS = 
include ../../build/rules.make

LIBRARY = System.Data.Linq.Design.dll
LIB_MCS_FLAGS = \
                /r:System.dll \
                /r:System.Core.dll \
                /r:System.Data.dll \
                /r:System.Data.Linq.dll \
                /r:System.Runtime.Serialization.dll \
                /r:System.Xml.dll \
                /langversion:linq
NO_TEST = yes

# This is a .NET 3.0 only assembly
VALID_PROFILE := $(filter net_3_0, $(PROFILE))
ifndef VALID_PROFILE
LIBRARY_NAME = dummy-System.Data.Linq.Design.dll
NO_INSTALL = yes
NO_SIGN_ASSEMBLY = yes
NO_TEST = yes
endif

include ../../build/library.make
