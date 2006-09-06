thisdir = data
SUBDIRS = 
include ../build/rules.make
olivedir = $(prefix)/lib/mono/3.0

all-local: olive.pc

REWRITE=
olive.pc: olive.pc.in Makefile
	sed -e "s,@olivedir@,$(olivedir),g" -e "s,@VERSION@,$(MONO_VERSION),g" < olive.pc.in > $@.tmp
	mv $@.tmp $@

install-local: olive.pc
	install olive.pc $(prefix)/lib/pkgconfig
