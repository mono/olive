all: \
	samplesvc4.exe samplecli4.exe \
	samplesvc5.exe samplecli5.exe samplesvc6.exe samplecli6.exe \
	samplesvc7.exe samplecli7.exe samplesvc8.exe samplecli8.exe

samplesvc8.exe : samplesvc8.cs
	gmcs -debug -pkg:wcf samplesvc8.cs

samplecli8.exe : samplecli8.cs
	gmcs -debug -pkg:wcf samplecli8.cs

samplesvc7.exe : samplesvc7.cs
	gmcs -debug -pkg:wcf samplesvc7.cs

samplecli7.exe : samplecli7.cs
	gmcs -debug -pkg:wcf samplecli7.cs

samplesvc6.exe : samplesvc6.cs
	gmcs -debug -pkg:wcf samplesvc6.cs

samplecli6.exe : samplecli6.cs
	gmcs -debug -pkg:wcf samplecli6.cs

samplesvc5.exe : samplesvc5.cs
	gmcs -debug -pkg:wcf samplesvc5.cs

samplecli5.exe : samplecli5.cs
	gmcs -debug -pkg:wcf samplecli5.cs

samplesvc4.exe : samplesvc4.cs
	gmcs -debug -pkg:wcf samplesvc4.cs

samplecli4.exe : samplecli4.cs
	gmcs -debug -pkg:wcf samplecli4.cs


clean:
	rm -f samplesvc4.exe samplesvc4.exe.mdb samplecli4.exe samplecli4.exe.mdb 
	rm -f samplesvc5.exe samplesvc5.exe.mdb samplecli5.exe samplecli5.exe.mdb 
	rm -f samplesvc6.exe samplesvc6.exe.mdb samplecli6.exe samplecli6.exe.mdb 
	rm -f samplesvc7.exe samplesvc7.exe.mdb samplecli7.exe samplecli7.exe.mdb 
	rm -f samplesvc8.exe samplesvc8.exe.mdb samplecli8.exe samplecli8.exe.mdb 

