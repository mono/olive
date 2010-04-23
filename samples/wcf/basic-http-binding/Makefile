all: samplesvc.exe samplecli.exe \
	samplesvc2.exe samplecli2.exe \
	samplesvc3.exe samplecli3.exe \
	samplesvc4.exe samplecli4.exe \
	samplesvc5.exe samplecli5.exe

samplesvc5.exe : samplesvc5.cs
	gmcs -debug -pkg:wcf samplesvc5.cs

samplecli5.exe : samplecli5.cs
	gmcs -debug -pkg:wcf samplecli5.cs

samplesvc4.exe : samplesvc4.cs
	gmcs -debug -pkg:wcf samplesvc4.cs

samplecli4.exe : samplecli4.cs
	gmcs -debug -pkg:wcf samplecli4.cs

samplesvc3.exe : samplesvc3.cs
	gmcs -debug -pkg:wcf samplesvc3.cs

samplecli3.exe : samplecli3.cs
	gmcs -debug -pkg:wcf samplecli3.cs

samplesvc2.exe : samplesvc2.cs
	gmcs -debug -pkg:wcf samplesvc2.cs

samplecli2.exe : samplecli2.cs
	gmcs -debug -pkg:wcf samplecli2.cs

samplesvc.exe : samplesvc.cs
	gmcs -debug -pkg:wcf samplesvc.cs

samplecli.exe : samplecli.cs
	gmcs -debug -pkg:wcf samplecli.cs

clean:
	rm samplesvc.exe samplesvc.exe.mdb samplecli.exe samplecli.exe.mdb
	rm samplesvc2.exe samplesvc2.exe.mdb samplecli2.exe samplecli2.exe.mdb
	rm samplesvc3.exe samplesvc3.exe.mdb samplecli3.exe samplecli3.exe.mdb
	rm samplesvc4.exe samplesvc4.exe.mdb samplecli4.exe samplecli4.exe.mdb
	rm samplesvc5.exe samplesvc5.exe.mdb samplecli5.exe samplecli5.exe.mdb

