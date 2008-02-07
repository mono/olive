all: samplesvc.exe samplecli.exe

samplesvc.exe : samplesvc.cs
	gmcs -pkg:olive samplesvc.cs

samplecli.exe : samplecli.cs
	gmcs -pkg:olive samplecli.cs

clean:
	rm -rf samplecli.exe samplesvc.exe
