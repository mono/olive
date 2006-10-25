
RUNTIME = mono --debug
CSC = gmcs -d:NET_2_0 -debug+
API_INFO = MONO_PATH=../class/lib/net_2_0 $(RUNTIME) ./mono-api-info.exe
API_DIFF = MONO_PATH=../class/lib/net_2_0 $(RUNTIME) ./mono-api-diff.exe

OBJECTS = \
	deploy/System.Runtime.Serialization.html	\
	deploy/System.IdentityModel.html		\
	deploy/System.IdentityModel.Selectors.html	\
	deploy/System.ServiceModel.html

all: $(OBJECTS)

$(OBJECTS): $(patsubst deploy/%.html,src/%.src, $(OBJECTS))

.PRECIOUS: deploy/%.html
deploy/%.html: src/%.src transform.exe mono-api.xsl
	$(RUNTIME) transform.exe $< mono-api.xsl source-name=$(notdir $<) > $@

.PRECIOUS: src/%.src
src/%.src: infos/%.xml mono-api-diff.exe
	$(API_DIFF) masterinfos/$(notdir $<) $< > $@ || (rm -rf $@ && exit 1)

.PRECIOUS: infos/%.xml
infos/%.xml: ../class/lib/net_2_0/%.dll mono-api-info.exe
	$(API_INFO) $< > $@ || (rm -f $@ && exit 1)

mono-api-info.exe : mono-api-info.cs
	$(CSC) mono-api-info.cs

mono-api-diff.exe : mono-api-diff.cs
	$(CSC) mono-api-diff.cs

transform.exe : transform.cs
	$(CSC) transform.cs

clean:
	rm -f deploy/*.html src/*.src infos/*.xml transform.exe mono-api-info.exe mono-api-diff.exe

