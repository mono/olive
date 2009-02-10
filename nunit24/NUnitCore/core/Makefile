thisdir = nunit24/NUnitCore/core
SUBDIRS = 
include ../../../build/rules.make

LIBRARY = nunit.core.dll
LIBRARY_SNK = $(topdir)/nunit24/nunit.snk

LOCAL_MCS_FLAGS= -debug -r:nunit.framework.dll -r:nunit.core.interfaces.dll -r:System.dll /d:StronglyNamedAssembly
NO_TEST = yo

NO_INSTALL = yes

EXTRA_DISTFILES = nunit.core.dll.csproj nunit.core.dll_VS2005.csproj

include ../../../build/library.make

