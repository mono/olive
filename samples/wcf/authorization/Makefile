all: samplesvc.exe samplecli.exe bin/samplesvc.dll

samplesvc.exe : samplesvc.cs
	gmcs -debug -pkg:wcf samplesvc.cs

samplecli.exe : samplecli.cs
	gmcs -debug -pkg:wcf samplecli.cs

bin/samplesvc.dll : bin samplesvc.cs
	gmcs -debug -pkg:wcf samplesvc.cs -out:bin/samplesvc.dll

bin:
	mkdir -p bin

clean:
	rm samplesvc.exe samplesvc.exe.mdb samplecli.exe samplecli.exe.mdb

