all: samplesvc.exe samplecli.exe samplesvc2.exe samplecli2.exe \
	samplesvc3.exe samplecli3.exe samplesvc4.exe samplecli4.exe \
	ajax-jsdebug.exe

ajax-jsdebug.exe : ajax-jsdebug.cs
	gmcs -pkg:wcf ajax-jsdebug.cs

samplesvc4.exe : samplesvc4.cs
	gmcs -pkg:wcf -debug samplesvc4.cs

samplecli4.exe : samplecli4.cs
	gmcs -pkg:wcf -debug samplecli4.cs

samplesvc3.exe : samplesvc3.cs
	gmcs -pkg:wcf -debug samplesvc3.cs

samplecli3.exe : samplecli3.cs
	gmcs -pkg:wcf -debug samplecli3.cs

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
	samplesvc3.exe samplesvc3.exe.mdb samplecli3.exe samplecli3.exe.mdb \
	samplesvc4.exe samplesvc4.exe.mdb samplecli4.exe samplecli4.exe.mdb \
	ajax-jsdebug.exe
