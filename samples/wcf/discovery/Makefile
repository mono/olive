
DISCOVERY_SOURCES = sample-discovery.cs AnnouncementBoundDiscoveryService.cs InspectionBehaviors.cs
SERVICE_SOURCES = sample-service.cs ContractTypes.cs
CLIENT_SOURCES = sample-client.cs ContractTypes.cs InspectionBehaviors.cs

all: \
	udp-service.exe udp-client.exe \
	sample-discovery.exe sample-service.exe sample-client.exe

udp-service.exe : udp-service.cs
	dmcs -debug -pkg:wcf udp-service.cs -r:System.ServiceModel.Discovery.dll

udp-client.exe : udp-client.cs
	dmcs -debug -pkg:wcf udp-client.cs -r:System.ServiceModel.Discovery.dll

sample-discovery.exe : $(DISCOVERY_SOURCES)
	dmcs -pkg:wcf -r:System.ServiceModel.Discovery $(DISCOVERY_SOURCES)

sample-service.exe : $(SERVICE_SOURCES)
	dmcs -pkg:wcf -r:System.ServiceModel.Discovery $(SERVICE_SOURCES)

sample-client.exe : $(CLIENT_SOURCES)
	dmcs -pkg:wcf -r:System.ServiceModel.Discovery $(CLIENT_SOURCES)

clean:
	rm -f udp-service.exe udp-service.exe.mdb udp-client.exe udp-client.exe.mdb 

	rm -f sample-discovery.exe sample-service.exe sample-client.exe
