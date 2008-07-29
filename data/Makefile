thisdir = data
SUBDIRS = 
include ../build/rules.make

ifeq ($(PLATFORM), win32)
	olivedir := $(shell cygpath -m '$(prefix)/lib/mono/3.0')
	olive35dir := $(shell cygpath -m '$(prefix)/lib/mono/3.5')
else
	olivedir   = $(prefix)/lib/mono/3.0
	olive35dir = $(prefix)/lib/mono/3.5
	silverdir  = $(prefix)/lib/mono/2.1
	a11ydir    = $(prefix)/lib/mono/accessibility
endif

all-local: olive.pc mono-uia.pc

DISTFILES = olive.pc.in \
	mono-uia.pc.in

REWRITE=
olive.pc: olive.pc.in Makefile
	sed -e "s,@olivedir@,$(olivedir),g" -e "s,@VERSION@,$(MONO_VERSION),g" < olive.pc.in > $@.tmp
	sed -e "s,@olive35dir@,$(olive35dir),g" -e "s,@VERSION@,$(MONO_VERSION),g" < $@.tmp > $@.tmp2
	mv $@.tmp2 $@
	rm $@.tmp

mono-uia.pc: mono-uia.pc.in Makefile
	sed -e "s,@olivedir@,$(olivedir),g" -e "s,@VERSION@,$(MONO_VERSION),g" < mono-uia.pc.in > $@.tmp
	sed -e "s,@a11ydir@,$(a11ydir),g" -e "s,@VERSION@,$(MONO_VERSION),g" < $@.tmp > $@.tmp2
	mv $@.tmp2 $@
	rm $@.tmp

install-local: olive.pc mono-uia.pc
	$(MKINSTALLDIRS) $(DESTDIR)$(prefix)/lib/pkgconfig
	$(INSTALL_DATA) olive.pc $(DESTDIR)$(prefix)/lib/pkgconfig
	$(INSTALL_DATA) mono-uia.pc $(DESTDIR)$(prefix)/lib/pkgconfig

clean-local:
	rm -rf olive.pc mono-uia.pc

test-local:

dist-local: dist-default
