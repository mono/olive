all: samplesvc.exe samplecli.exe

samplesvc.exe : samplesvc.cs
	gmcs -debug -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll samplesvc.cs

samplecli.exe : samplecli.cs
	gmcs -debug -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll samplecli.cs

clean:
	rm -f samplesvc.exe samplesvc.exe.mdb samplecli.exe samplecli.exe.mdb 

