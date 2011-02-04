all: \
	samplesvc.exe samplecli.exe samplesvc2.exe samplecli2.exe \
	samplesvc3.exe samplecli3.exe samplesvc8.exe samplecli8.exe \
	samplesvc9.exe samplecli9.exe samplesvc10.exe samplecli10.exe

samplesvc10.exe : samplesvc10.cs
	gmcs -debug -pkg:wcf samplesvc10.cs

samplecli10.exe : samplecli10.cs
	gmcs -debug -pkg:wcf samplecli10.cs

samplesvc9.exe : samplesvc9.cs
	gmcs -debug -pkg:wcf samplesvc9.cs

samplecli9.exe : samplecli9.cs
	gmcs -debug -pkg:wcf samplecli9.cs

samplesvc8.exe : samplesvc8.cs
	gmcs -debug -pkg:wcf samplesvc8.cs

samplecli8.exe : samplecli8.cs
	gmcs -debug -pkg:wcf samplecli8.cs

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
	rm -f samplesvc.exe samplesvc.exe.mdb samplecli.exe samplecli.exe.mdb 
	rm -f samplesvc2.exe samplesvc2.exe.mdb samplecli2.exe samplecli2.exe.mdb 
	rm -f samplesvc3.exe samplesvc3.exe.mdb samplecli3.exe samplecli3.exe.mdb 
	rm -f samplesvc8.exe samplesvc8.exe.mdb samplecli8.exe samplecli8.exe.mdb 
	rm -f samplesvc9.exe samplesvc9.exe.mdb samplecli9.exe samplecli9.exe.mdb 
	rm -f samplesvc10.exe samplesvc10.exe.mdb samplecli10.exe samplecli10.exe.mdb 

