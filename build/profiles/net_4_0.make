# -*- makefile -*-

MCS = MONO_PATH="$(topdir)/class/lib/$(PROFILE)$(PLATFORM_PATH_SEPARATOR)$(topdir)/class/lib/net_3_5$(PLATFORM_PATH_SEPARATOR)$$MONO_PATH" dmcs
TEST_MONO_PATH="$(topdir)/class/lib/$(PROFILE)$(PLATFORM_PATH_SEPARATOR)$(topdir)/class/lib/net_3_5$(PLATFORM_PATH_SEPARATOR)$$MONO_PATH"
# nuttzing!

profile-check:
	mkdir -p $(topdir)/class/lib/$(PROFILE)
	@:

PROFILE_MCS_FLAGS = -d:NET_1_1 -d:NET_2_0 -d:NET_3_5 -d:NET_4_0 -lib:$(topdir)/class/lib/net_4_0
FRAMEWORK_VERSION = 4.0
