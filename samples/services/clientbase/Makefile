all: samplesvc.exe samplecli.exe samplesvc2.exe samplecli2.exe samplesvc3.exe samplecli3.exe samplesvc4.exe

samplesvc4.exe : samplesvc4.cs
	gmcs -debug -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll samplesvc4.cs

samplesvc3.exe : samplesvc3.cs
	gmcs -debug -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll samplesvc3.cs

samplecli3.exe : samplecli3.cs
	gmcs -debug -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll samplecli3.cs

samplesvc2.exe : samplesvc2.cs
	gmcs -debug -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll samplesvc2.cs

samplecli2.exe : samplecli2.cs
	gmcs -debug -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll samplecli2.cs

samplesvc.exe : samplesvc.cs
	gmcs -debug -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll samplesvc.cs

samplecli.exe : samplecli.cs
	gmcs -debug -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll samplecli.cs

clean:
	rm -f samplesvc.exe samplesvc.exe.mdb samplecli.exe samplecli.exe.mdb 
	rm -f samplesvc2.exe samplesvc2.exe.mdb samplecli2.exe samplecli2.exe.mdb 
	rm -f samplesvc3.exe samplesvc3.exe.mdb samplecli3.exe samplecli3.exe.mdb 

