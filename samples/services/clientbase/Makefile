all: samplesvc.exe samplecli.exe samplesvc2.exe samplecli2.exe samplesvc3.exe samplecli3.exe

samplesvc3.exe : samplesvc3.cs
	gmcs -debug -pkg:olive samplesvc3.cs

samplecli3.exe : samplecli3.cs
	gmcs -debug -pkg:olive samplecli3.cs

samplesvc2.exe : samplesvc2.cs
	gmcs -debug -pkg:olive samplesvc2.cs

samplecli2.exe : samplecli2.cs
	gmcs -debug -pkg:olive samplecli2.cs

samplesvc.exe : samplesvc.cs
	gmcs -debug -pkg:olive samplesvc.cs

samplecli.exe : samplecli.cs
	gmcs -debug -pkg:olive samplecli.cs

clean:
	rm -f samplesvc.exe samplesvc.exe.mdb samplecli.exe samplecli.exe.mdb 
	rm -f samplesvc2.exe samplesvc2.exe.mdb samplecli2.exe samplecli2.exe.mdb 
	rm -f samplesvc3.exe samplesvc3.exe.mdb samplecli3.exe samplecli3.exe.mdb 

