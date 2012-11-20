thisdir = class/PresentationCore
include ../../build/rules.make

LIBRARY = PresentationCore.dll

ifeq ($(PROFILE),net_4_0)
NET_4_0_LIB_MCS_FLAGS = -r:System.Xaml.dll
endif

LIB_MCS_FLAGS = -r:WindowsBase.dll -r:System.dll $(NET_4_0_LIB_MCS_FLAGS) -nowarn:0067,0414

TEST_MCS_FLAGS = -r:WindowsBase.dll

include ../../build/library.make
