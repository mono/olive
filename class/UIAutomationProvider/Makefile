thisdir = class/UIAutomationProvider
include ../../build/rules.make

LIBRARY = UIAutomationProvider.dll

LIB_MCS_FLAGS = -r:System -r:UIAutomationTypes -r:WindowsBase
TEST_MCS_FLAGS = $(LIB_MCS_FLAGS) -r:UIAutomationProvider.dll

include ../../build/library.make
