
COMMON = ITestApplication.cs ResultInfo.cs MessageType.cs ServiceResult.cs InspectionBehaviors.cs

all: client.exe server.exe

client.exe : client.cs $(COMMON)
	gmcs client.cs $(COMMON) -pkg:wcf

server.exe : server.cs $(COMMON) TestApplication.cs
	gmcs server.cs $(COMMON) TestApplication.cs -pkg:wcf

clean:
	rm -rf client.exe server.exe
