all: samplesvc.exe samplecli.exe

samplesvc.exe : samplesvc.cs
	gmcs -debug -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll samplesvc.cs

samplecli.exe : samplecli.cs
	gmcs -debug -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll -r:System.Configuration.dll samplecli.cs

clean:
	rm samplesvc.exe samplesvc.exe.mdb samplecli.exe samplecli.exe.mdb

