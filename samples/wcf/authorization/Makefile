all: samplesvc.exe samplecli.exe

samplesvc.exe : samplesvc.cs
	gmcs -debug -pkg:wcf samplesvc.cs

samplecli.exe : samplecli.cs
	gmcs -debug -pkg:wcf samplecli.cs

clean:
	rm samplesvc.exe samplesvc.exe.mdb samplecli.exe samplecli.exe.mdb

