thisdir = data
SUBDIRS = 
include ../build/rules.make
olivedir = $(prefix)/lib/3.0

all-local: olive.pc

REWRITE=
olive.pc: olive.pc.in
	sed -e "s,@olivedir@,$(olivedir),g" < olive.pc.in > $@.tmp
	mv $@.tmp $@
