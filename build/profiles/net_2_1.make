# -*- makefile -*-

MCS = MONO_PATH="$(topdir)/class/lib/$(PROFILE)$(PLATFORM_PATH_SEPARATOR)$$MONO_PATH" mono --runtime=moonlight --security=temporary-smcs-hack $(topdir)/class/lib/$(PROFILE)/smcs.exe -langversion:linq
# nuttzing!

profile-check:
	@if test '!' -f $(mono_libdir)/mono/2.1/smcs.exe; then \
		echo ; \
		echo "$(mono_libdir)/mono/2.1/smcs.exe does not exist." ; \
		echo ; \
		echo "This means that you need to install mono configured with moonlight" ; \
		echo "in the same prefix you're building olive." ; \
		exit 1; \
	fi
	cp $(mono_libdir)/mono/2.1/smcs.exe $(topdir)/class/lib/$(PROFILE)/smcs.exe

PROFILE_MCS_FLAGS = -d:NET_1_1 -d:NET_2_0 -d:NET_2_1
FRAMEWORK_VERSION = 2.1
