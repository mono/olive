all: samplesvc.exe samplecli.exe

samplesvc.exe : samplesvc.cs
	gmcs -pkg:olive -debug samplesvc.cs

samplecli.exe : samplecli.cs
	gmcs -pkg:olive -debug samplecli.cs

clean:
	rm -rf samplecli.exe samplecli.exe.mdb samplesvc.exe samplesvc.exe.mdb
