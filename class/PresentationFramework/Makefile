thisdir = class/PresentationFramework
include ../../build/rules.make

LIBRARY = PresentationFramework.dll

LIB_MCS_FLAGS = -r:System.Xml.dll -r:PresentationCore.dll -r:WindowsBase.dll -r:System.dll
TEST_MCS_FLAGS = -r:PresentationFramework.dll $(LIB_MCS_FLAGS)
TEST_MONO_PATH = .

include ../../build/library.make
