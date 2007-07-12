
PROGRAMS = \
	setup-sample.exe cleanup-sample.exe  \
	samplesvc1.exe samplecli1.exe

all: $(PROGRAMS)

setup-sample.exe : setup-sample.cs
	gmcs setup-sample.cs -pkg:dotnet
cleanup-sample.exe : cleanup-sample.cs
	gmcs cleanup-sample.cs -pkg:dotnet

samplesvc1.exe : samplesvc1.cs
	gmcs samplesvc1.cs -pkg:olive
samplecli1.exe : samplecli1.cs
	gmcs samplecli1.cs -pkg:olive

clean:
	rm -rf $(PROGRAMS)
