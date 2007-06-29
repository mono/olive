thisdir = tools/xslt-debugger
SUBDIRS = 
include ../../build/rules.make

LOCAL_MCS_FLAGS = -r:System.Xml.dll -r:Mono.XsltDebugger.dll

PROGRAM = $(topdir)/class/lib/$(PROFILE)/xslt-debugger.exe

CLEAN_FILES = xslt-debugger.exe xslt-debugger.exe.mdb

include ../../build/executable.make

