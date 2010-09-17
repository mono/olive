all:
	mkdir -p bin
	dmcs -pkg:wcf -debug -t:library test.cs -out:bin/test.dll
	dmcs -pkg:wcf -debug -d:CONSOLE test.cs -r:System.Configuration.dll

clean:
	rm -f bin/test.dll bin/test.dll.mdb
	rm -f test.exe test.exe.mdb
