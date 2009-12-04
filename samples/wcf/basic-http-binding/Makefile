all: samplesvc.exe samplecli.exe \
	samplesvc2.exe samplecli2.exe

samplesvc2.exe : samplesvc2.cs
	gmcs -debug -pkg:wcf samplesvc2.cs

samplecli2.exe : samplecli2.cs
	gmcs -debug -pkg:wcf samplecli2.cs

samplesvc.exe : samplesvc.cs
	gmcs -debug -pkg:wcf samplesvc.cs

samplecli.exe : samplecli.cs
	gmcs -debug -pkg:wcf samplecli.cs

clean:
	rm samplesvc.exe samplesvc.exe.mdb samplecli.exe samplecli.exe.mdb
	rm samplesvc2.exe samplesvc2.exe.mdb samplecli2.exe samplecli2.exe.mdb

