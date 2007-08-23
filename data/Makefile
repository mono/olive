thisdir = data
SUBDIRS = 
include ../build/rules.make

ifeq ($(PLATFORM), win32)
	olivedir := $(shell cygpath -m '$(prefix)/lib/mono/3.0')
else
	olivedir  = $(prefix)/lib/mono/3.0
	agmonodir = $(prefix)/lib/mono/gac/agmono/2.1.0.0__31bf3856ad364e35/
	agclrdir  = $(prefix)/lib/mono/gac/agclr/0.0.0.0__b03f5f7f11d50a3a/
	syssldir  = $(prefix)/lib/mono/gac/System.SilverLight/1.0.0.0__b03f5f7f11d50a3a/
endif

all-local: olive.pc silver.pc silverdesktop.pc agmono.pc agmonosilver.pc

DISTFILES = olive.pc.in silver.pc.in silverdesktop.pc.in agmono.pc.in agmonosilver.pc.in

REWRITE=
olive.pc: olive.pc.in Makefile
	sed -e "s,@olivedir@,$(olivedir),g" -e "s,@VERSION@,$(MONO_VERSION),g" < olive.pc.in > $@.tmp
	mv $@.tmp $@

silver.pc: silver.pc.in Makefile
	sed -e "s,@agclrdir@,$(agclrdir),g" -e "s,@syssldir@,$(syssldir),g" -e "s,@VERSION@,$(MONO_VERSION),g" < silver.pc.in > $@.tmp
	mv $@.tmp $@

agmonosilver.pc: agmonosilver.pc.in Makefile
	sed -e "s,@agmonodir@,$(agmonodir),g" -e "s,@VERSION@,$(MONO_VERSION),g" < agmonosilver.pc.in > $@.tmp
	mv $@.tmp $@

silverdesktop.pc: silverdesktop.pc.in Makefile
	sed -e "s,@olivedir@,$(olivedir),g" -e "s,@VERSION@,$(MONO_VERSION),g" < silverdesktop.pc.in > $@.tmp
	mv $@.tmp $@

agmono.pc: agmono.pc.in Makefile
	sed -e "s,@olivedir@,$(olivedir),g" -e "s,@VERSION@,$(MONO_VERSION),g" < agmono.pc.in > $@.tmp
	mv $@.tmp $@

install-local: olive.pc silver.pc silverdesktop.pc agmono.pc agmonosilver.pc
	$(MKINSTALLDIRS) $(DESTDIR)$(prefix)/lib/pkgconfig
	$(INSTALL_DATA) olive.pc silver.pc silverdesktop.pc agmono.pc agmonosilver.pc $(DESTDIR)$(prefix)/lib/pkgconfig

clean-local:
	rm -rf olive.pc silver.pc silverdesktop.pc agmono.pc agmonosilver.pc

test-local:

dist-local: dist-default
