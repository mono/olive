thisdir = class

include ../build/rules.make

# For now, Mono.Security.Win32 is built on Linux too.
# However, it isn't tested on Linux, since it depends on a Win32 dll.
SUBDIRS = \
	System.Core			\
	System.Xml.XLinq		\
	System.Workflow.ComponentModel	\
	System.Workflow.Activities	\
	System.Workflow.Runtime		\
	System.Workflow.ComponentModel	\
	System.Workflow.Activities	\
	WindowsBase			\
	PresentationFramework		\
	System.Runtime.Serialization	\
	System.IdentityModel		\
	System.IdentityModel.Selectors	\
	System.ServiceModel

DISTFILES = \
	LICENSE 		\
	README			\

.PHONY: all-local $(STD_TARGETS:=-local)
all-local $(STD_TARGETS:=-local):
	@:

