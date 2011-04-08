# -*- makefile -*-

BOOTSTRAP_MCS = $(INTERNAL_GMCS)
MCS = $(INTERNAL_GMCS)

# nuttzing!

profile-check:
	mkdir -p $(topdir)/class/lib/$(PROFILE)
	@:

PROFILE_MCS_FLAGS = -d:NET_1_1 -d:NET_2_0 -lib:$(topdir)/class/lib/net_3_0
FRAMEWORK_VERSION = 2.0
