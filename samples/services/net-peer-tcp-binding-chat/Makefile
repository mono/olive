all: ChatClient.exe ChatServer.exe

ChatClient.exe : ChatClient.cs
	gmcs -debug -pkg:olive ChatClient.cs

ChatServer.exe : ChatServer.cs
	gmcs -debug -pkg:olive ChatServer.cs

clean:
	rm *.exe *.exe.mdb
