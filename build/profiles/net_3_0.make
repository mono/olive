# -*- makefile -*-

BOOTSTRAP_MCS = MONO_PATH="$(topdir)/class/lib/$(BOOTSTRAP_PROFILE)$(PLATFORM_PATH_SEPARATOR)$$MONO_PATH" $(INTERNAL_GMCS)
MCS = MONO_PATH="$(topdir)/class/lib/$(PROFILE)$(PLATFORM_PATH_SEPARATOR)$$MONO_PATH" $(INTERNAL_GMCS)

# nuttzing!

profile-check:
	mkdir -p $(topdir)/class/lib/$(PROFILE)
	@:

PROFILE_MCS_FLAGS = -d:NET_1_1 -d:NET_2_0
FRAMEWORK_VERSION = 2.0
