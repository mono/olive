thisdir = nunit24
SUBDIRS = NUnitFramework/framework NUnitCore/interfaces NUnitCore/core \
	ClientUtilities/util NUnitMocks/mocks \
	NUnitExtensions/framework NUnitExtensions/core \
	ConsoleRunner/nunit-console ConsoleRunner/nunit-console-exe
include ../build/rules.make

DISTFILES = license.rtf nunit.sln nunit_VS2005.sln nunit.snk \
	CommonAssemblyInfo.cs

all-local install-local test-local run-test-local run-test-ondotnet-local clean-local uninstall-local:

dist-local: dist-default
#distclean-local: distclean-default

dist-recursive: dist-local
	@case '$(distdir)' in [\\/$$]* | ?:[\\/]* ) reldir='$(distdir)' ;; *) reldir='../../$(distdir)' ;; esac ; \
	list='$(DIST_SUBDIRS)'; for d in $$list ; do \
	    (cd $$d && $(MAKE) distdir=$$reldir/$$d $@) || exit 1 ; \
	done
