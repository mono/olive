thisdir = data
SUBDIRS = 
include ../build/rules.make

ifeq ($(PLATFORM), win32)
	olivedir := $(shell cygpath -m '$(prefix)/lib/mono/3.0')
else
	olivedir = $(prefix)/lib/mono/3.0
endif

all-local: olive.pc

DISTFILES = olive.pc.in

REWRITE=
olive.pc: olive.pc.in Makefile
	sed -e "s,@olivedir@,$(olivedir),g" -e "s,@VERSION@,$(MONO_VERSION),g" < olive.pc.in > $@.tmp
	mv $@.tmp $@

install-local: olive.pc
	$(MKINSTALLDIRS) $(DESTDIR)$(prefix)/lib/pkgconfig
	$(INSTALL_DATA) olive.pc $(DESTDIR)$(prefix)/lib/pkgconfig

clean-local:
	rm -rf olive.pc

test-local:

dist-local: dist-default
