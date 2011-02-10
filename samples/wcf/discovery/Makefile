
DISCOVERY_SOURCES = AnnouncementBoundDiscoveryService.cs InspectionBehaviors.cs
SERVICE_SOURCES = ContractTypes.cs InspectionBehaviors.cs
CLIENT_SOURCES = ContractTypes.cs InspectionBehaviors.cs

all: \
	udp-service.exe udp-client.exe \
	sample-discovery.exe sample-service.exe sample-client.exe \
	sample-discovery2.exe sample-service2.exe sample-client2.exe \
	sample-discovery3.exe sample-service3.exe sample-client3.exe \
	sample-discovery4.exe sample-service4.exe sample-client4.exe \
	sample-discovery5.exe sample-service5.exe sample-client5.exe

udp-service.exe : udp-service.cs
	dmcs -debug -pkg:wcf udp-service.cs -r:System.ServiceModel.Discovery.dll

udp-client.exe : udp-client.cs
	dmcs -debug -pkg:wcf udp-client.cs -r:System.ServiceModel.Discovery.dll

sample-discovery.exe : sample-discovery.cs $(DISCOVERY_SOURCES)
	dmcs -pkg:wcf -r:System.ServiceModel.Discovery sample-discovery.cs $(DISCOVERY_SOURCES)

sample-service.exe : sample-service.cs $(SERVICE_SOURCES)
	dmcs -pkg:wcf -r:System.ServiceModel.Discovery sample-service.cs $(SERVICE_SOURCES)

sample-client.exe : sample-client.cs $(CLIENT_SOURCES)
	dmcs -pkg:wcf -r:System.ServiceModel.Discovery sample-client.cs $(CLIENT_SOURCES)

sample-discovery2.exe : sample-discovery2.cs $(DISCOVERY_SOURCES)
	dmcs -pkg:wcf -r:System.ServiceModel.Discovery sample-discovery2.cs $(DISCOVERY_SOURCES)

sample-service2.exe : sample-service2.cs $(SERVICE_SOURCES)
	dmcs -pkg:wcf -r:System.ServiceModel.Discovery sample-service2.cs $(SERVICE_SOURCES)

sample-client2.exe : sample-client2.cs $(CLIENT_SOURCES)
	dmcs -pkg:wcf -r:System.ServiceModel.Discovery sample-client2.cs $(CLIENT_SOURCES)

sample-discovery3.exe : sample-discovery3.cs $(DISCOVERY_SOURCES)
	dmcs -pkg:wcf -r:System.ServiceModel.Discovery sample-discovery3.cs $(DISCOVERY_SOURCES)

sample-service3.exe : sample-service3.cs $(SERVICE_SOURCES)
	dmcs -pkg:wcf -r:System.ServiceModel.Discovery sample-service3.cs $(SERVICE_SOURCES)

sample-client3.exe : sample-client3.cs $(CLIENT_SOURCES)
	dmcs -pkg:wcf -r:System.ServiceModel.Discovery sample-client3.cs $(CLIENT_SOURCES)

sample-discovery4.exe : sample-discovery4.cs $(DISCOVERY_SOURCES)
	dmcs -pkg:wcf -r:System.ServiceModel.Discovery sample-discovery4.cs $(DISCOVERY_SOURCES)

sample-service4.exe : sample-service4.cs $(SERVICE_SOURCES)
	dmcs -pkg:wcf -r:System.ServiceModel.Discovery sample-service4.cs $(SERVICE_SOURCES)

sample-client4.exe : sample-client4.cs $(CLIENT_SOURCES)
	dmcs -pkg:wcf -r:System.ServiceModel.Discovery sample-client4.cs $(CLIENT_SOURCES)

sample-discovery5.exe : sample-discovery5.cs $(DISCOVERY_SOURCES)
	dmcs -pkg:wcf -r:System.ServiceModel.Discovery sample-discovery5.cs $(DISCOVERY_SOURCES)

sample-service5.exe : sample-service5.cs $(SERVICE_SOURCES)
	dmcs -pkg:wcf -r:System.ServiceModel.Discovery sample-service5.cs $(SERVICE_SOURCES)

sample-client5.exe : sample-client5.cs $(CLIENT_SOURCES)
	dmcs -pkg:wcf -r:System.ServiceModel.Discovery sample-client5.cs $(CLIENT_SOURCES)

clean:
	rm -f udp-service.exe udp-service.exe.mdb udp-client.exe udp-client.exe.mdb 

	rm -f sample-discovery.exe sample-service.exe sample-client.exe
	rm -f sample-discovery2.exe sample-service2.exe sample-client2.exe
	rm -f sample-discovery3.exe sample-service3.exe sample-client3.exe
	rm -f sample-discovery4.exe sample-service4.exe sample-client4.exe
	rm -f sample-discovery5.exe sample-service5.exe sample-client5.exe
