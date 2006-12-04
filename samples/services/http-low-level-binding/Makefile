all: reply.exe request.exe self-request-reply.exe

reply.exe : reply.cs
	gmcs -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll reply.cs

request.exe : request.cs
	gmcs -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll request.cs

self-request-reply.exe : self-request-reply.cs
	gmcs -r:System.ServiceModel.dll -r:System.Runtime.Serialization.dll self-request-reply.cs

clean:
	rm -rf request.exe reply.exe self-request-reply.exe 
