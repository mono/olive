thisdir = class

include ../build/rules.make

# For now, Mono.Security.Win32 is built on Linux too.
# However, it isn't tested on Linux, since it depends on a Win32 dll.
SUBDIRS = \
	System.Xml.Linq			\
	System.Workflow.ComponentModel	\
	System.Workflow.Activities	\
	System.Workflow.Runtime		\
	System.Workflow.ComponentModel	\
	System.Workflow.Activities	\
	WindowsBase			\
	PresentationCore		\
	PresentationFramework		\
	System.Runtime.Serialization	\
	System.IdentityModel		\
	System.IdentityModel.Selectors	\
	System.ServiceModel 		\
	System.ServiceModel.Web		\
	System.Silverlight		\
	agmono				\
	agclr

DIST_PROFILE_DIRS = net_3_0

dist-local: dist-default
	-$(MKINSTALLDIRS) $(DIST_PROFILE_DIRS:%=$(distdir)/lib/%)


DISTFILES = msfinal.pub msfinal3.pub winfx.pub mono.snk mono.pub

.PHONY: all-local $(STD_TARGETS:=-local)
all-local $(STD_TARGETS:=-local):
	@:

