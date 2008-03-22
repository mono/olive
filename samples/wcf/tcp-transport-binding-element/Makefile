all: Client.exe Server.exe

Client.exe : Client.cs
	gmcs -debug -pkg:olive Client.cs

Server.exe : Server.cs
	gmcs -debug -pkg:olive Server.cs

clean:
	rm *.exe *.exe.mdb
