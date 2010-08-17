all: \
	udp-service.exe udp-client.exe

udp-service.exe : udp-service.cs
	dmcs -debug -pkg:wcf udp-service.cs -r:System.ServiceModel.Discovery.dll

udp-client.exe : udp-client.cs
	dmcs -debug -pkg:wcf udp-client.cs -r:System.ServiceModel.Discovery.dll


clean:
	rm -f udp-service.exe udp-service.exe.mdb udp-client.exe udp-client.exe.mdb 

