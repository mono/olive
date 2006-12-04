all: \
	samplesvc.exe samplecli.exe \
	samplesvc2.exe samplecli2.exe \
	samplesvc3.exe samplecli3.exe \
	samplesvc4.exe samplecli4.exe \
	samplesvc5.exe samplecli5.exe

samplesvc5.exe : samplesvc5.cs
	gmcs -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll -r:System.IdentityModel.dll samplesvc5.cs Inspector.cs

samplecli5.exe : samplecli5.cs
	gmcs -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll -r:System.IdentityModel.dll samplecli5.cs Inspector.cs

samplesvc4.exe : samplesvc4.cs
	gmcs -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll -r:System.IdentityModel.dll samplesvc4.cs Inspector.cs

samplecli4.exe : samplecli4.cs
	gmcs -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll -r:System.IdentityModel.dll samplecli4.cs Inspector.cs

samplesvc3.exe : samplesvc3.cs
	gmcs -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll -r:System.IdentityModel.dll samplesvc3.cs Inspector.cs

samplecli3.exe : samplecli3.cs
	gmcs -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll -r:System.IdentityModel.dll samplecli3.cs Inspector.cs

samplesvc2.exe : samplesvc2.cs
	gmcs -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll -r:System.IdentityModel.dll samplesvc2.cs Inspector.cs

samplecli2.exe : samplecli2.cs
	gmcs -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll samplecli2.cs Inspector.cs

samplesvc.exe : samplesvc.cs Inspector.cs
	gmcs -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll -r:System.IdentityModel.dll samplesvc.cs Inspector.cs

samplecli.exe : samplecli.cs Inspector.cs
	gmcs -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll samplecli.cs Inspector.cs

clean:
	rm -f samplesvc.exe samplesvc.exe.mdb samplecli.exe samplecli.exe.mdb 
	rm -f samplesvc2.exe samplesvc2.exe.mdb samplecli2.exe samplecli2.exe.mdb 
	rm -f samplesvc3.exe samplesvc3.exe.mdb samplecli3.exe samplecli3.exe.mdb 
	rm -f samplesvc4.exe samplesvc4.exe.mdb samplecli4.exe samplecli4.exe.mdb 
	rm -f samplesvc5.exe samplesvc5.exe.mdb samplecli5.exe samplecli5.exe.mdb 

