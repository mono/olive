thisdir = tools
SUBDIRS = \
	xamlc

include ../build/rules.make

test-local run-test-local run-test-ondotnet-local all-local install-local uninstall-local:
	@:

dist-local: dist-default

clean-local:
	rm -f *.exe *.dll *.pdb cormissing.xml
