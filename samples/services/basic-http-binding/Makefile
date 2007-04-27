all: samplesvc.exe samplecli.exe

samplesvc.exe : samplesvc.cs
	gmcs -debug -pkg:olive samplesvc.cs

samplecli.exe : samplecli.cs
	gmcs -debug -pkg:olive samplecli.cs

clean:
	rm samplesvc.exe samplesvc.exe.mdb samplecli.exe samplecli.exe.mdb

