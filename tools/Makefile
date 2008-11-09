thisdir = tools
SUBDIRS = \
	client-proxy-gen	\
	sts			\
	svcutil

DISTFILES=removecomments.sh

include ../build/rules.make

test-local run-test-local run-test-ondotnet-local all-local install-local uninstall-local:
	@:

dist-local: dist-default
distclean-local: distclean-default

clean-local:
	rm -f *.exe *.dll *.pdb cormissing.xml
