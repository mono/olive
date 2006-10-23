thisdir = tools
SUBDIRS = \
	xamlc			\
	client-proxy-gen	\
	sts			\
	svcutil

include ../build/rules.make

test-local run-test-local run-test-ondotnet-local all-local install-local uninstall-local:
	@:

dist-local: dist-default

clean-local:
	rm -f *.exe *.dll *.pdb cormissing.xml
