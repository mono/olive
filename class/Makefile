thisdir = class

# For now, Mono.Security.Win32 is built on Linux too.
# However, it isn't tested on Linux, since it depends on a Win32 dll.
net_3_0_dirs = \
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
	agmono				\
	System.Silverlight		\
	agclr

net_2_1_dirs = \
	agmono		\
	System.Silverlight	\
#	agclr		\

net_3_0_SUBDIRS := $(net_3_0_dirs)
net_2_1_SUBDIRS := $(net_2_1_dirs)

SUBDIRS = $(net_3_0_dirs) $(net_2_1_dirs)

include ../build/rules.make

DIST_PROFILE_DIRS = net_3_0

dist-local: dist-default
	-$(MKINSTALLDIRS) $(DIST_PROFILE_DIRS:%=$(distdir)/lib/%)


DISTFILES = msfinal.pub msfinal3.pub winfx.pub mono.snk mono.pub

.PHONY: all-local $(STD_TARGETS:=-local)
all-local $(STD_TARGETS:=-local):
	@:

