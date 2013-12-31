thisdir = class/PresentationFramework
include ../../build/rules.make

LIBRARY = PresentationFramework.dll

ifeq ($(PROFILE),net_4_0)
NET_4_0_LIB_MCS_FLAGS = -r:System.Xaml.dll
else
ifeq ($(PROFILE),net_4_5)
NET_4_0_LIB_MCS_FLAGS = -r:System.Xaml.dll
endif
endif

LIB_MCS_FLAGS = -lib:../lib/net_3_0 -r:System.Xml.dll -r:PresentationCore.dll -r:WindowsBase.dll -r:System.dll $(NET_4_0_LIB_MCS_FLAGS)
TEST_MCS_FLAGS = -r:PresentationFramework.dll $(LIB_MCS_FLAGS)
TEST_MONO_PATH = .

include ../../build/library.make
