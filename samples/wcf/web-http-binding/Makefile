all: samplesvc.exe samplecli.exe samplesvc2.exe samplecli2.exe \
	ajax-jsdebug.exe

ajax-jsdebug.exe : ajax-jsdebug.cs
	gmcs -pkg:wcf ajax-jsdebug.cs

samplesvc2.exe : samplesvc2.cs
	gmcs -pkg:wcf -debug samplesvc2.cs

samplecli2.exe : samplecli2.cs
	gmcs -pkg:wcf -debug samplecli2.cs

samplesvc.exe : samplesvc.cs
	gmcs -pkg:wcf -debug samplesvc.cs

samplecli.exe : samplecli.cs
	gmcs -pkg:wcf -debug samplecli.cs

clean:
	rm -rf samplecli.exe samplecli.exe.mdb samplesvc.exe samplesvc.exe.mdb \
	samplesvc2.exe samplesvc2.exe.mdb samplecli2.exe samplecli2.exe.mdb \
	ajax-jsdebug.exe
