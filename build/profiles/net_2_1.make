# -*- makefile -*-

MCS = MONO_PATH="$(topdir)/class/lib/$(PROFILE)$(PLATFORM_PATH_SEPARATOR)$$MONO_PATH" mono --runtime=moonlight --security=temporary-smcs-hack $(topdir)/class/lib/$(PROFILE)/smcs.exe -langversion:linq
# nuttzing!

profile-check:
	cp $(mono_libdir)/mono/2.1/smcs.exe $(topdir)/class/lib/$(PROFILE)/smcs.exe
	@:

PROFILE_MCS_FLAGS = -d:NET_1_1 -d:NET_2_0 -d:NET_2_1
FRAMEWORK_VERSION = 2.1
