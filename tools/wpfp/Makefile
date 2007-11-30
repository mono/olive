thisdir = tools/wpfp
SUBDIRS = 
include ../../build/rules.make

LOCAL_MCS_FLAGS = \
	-r:$(topdir)/class/lib/net_3_0/WindowsBase.dll \
	-r:$(topdir)/class/lib/net_3_0/PresentationCore.dll \

PROGRAM = wpfp.exe

include ../../build/executable.make
