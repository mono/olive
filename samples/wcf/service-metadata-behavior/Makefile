all:
	mkdir -p bin
	gmcs -pkg:wcf -debug -t:library test.cs -out:bin/test.dll
	gmcs -pkg:wcf -debug -d:CONSOLE -out:bin/test.dll

clean:
	rm -f bin/test.dll bin/test.dll.mdb
