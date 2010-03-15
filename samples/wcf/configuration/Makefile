all: samplesvc.exe samplecli.exe \
	samplesvc2.exe samplecli2.exe

samplesvc2.exe : samplesvc2.cs
	gmcs -debug -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll samplesvc2.cs

samplecli2.exe : samplecli2.cs
	gmcs -debug -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll -r:System.Configuration.dll samplecli2.cs

samplesvc.exe : samplesvc.cs
	gmcs -debug -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll samplesvc.cs

samplecli.exe : samplecli.cs
	gmcs -debug -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll -r:System.Configuration.dll samplecli.cs

clean:
	rm samplesvc.exe samplesvc.exe.mdb samplecli.exe samplecli.exe.mdb \
	   samplesvc2.exe samplesvc2.exe.mdb samplecli2.exe samplecli2.exe.mdb

