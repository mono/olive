thisdir = class

# For now, Mono.Security.Win32 is built on Linux too.
# However, it isn't tested on Linux, since it depends on a Win32 dll.
net_3_0_dirs = \
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
	agmono				\
	System.Silverlight		\
	agclr

net_2_1_dirs = \
	agmono		\
	System.Silverlight	\
	agclr		\
	
net_3_5_dirs = \
	System.Data.Linq	\
	System.Xml.Linq		\
	System.ServiceModel.Web		\
	System.Web.Extensions	
	

net_3_0_SUBDIRS := $(net_3_0_dirs)
net_2_1_SUBDIRS := $(net_2_1_dirs)
net_3_5_SUBDIRS := $(net_3_5_dirs)

SUBDIRS = $(net_3_0_dirs) $(net_2_1_dirs) $(net_3_5_dirs)

include ../build/rules.make

DIST_PROFILE_DIRS = net_3_0

dist-local: dist-default
	-$(MKINSTALLDIRS) $(DIST_PROFILE_DIRS:%=$(distdir)/lib/%)


DISTFILES = msfinal.pub msfinal3.pub winfx.pub mono.snk mono.pub ecma.pub

.PHONY: all-local $(STD_TARGETS:=-local)
all-local $(STD_TARGETS:=-local):
	@:

