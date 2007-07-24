all: ChatClient.exe ChatClient1.exe ChatServer.exe

ChatClient.exe : ChatClient.cs
	gmcs -debug -pkg:olive ChatClient.cs

ChatClient1.exe : ChatClient1.cs
	gmcs -debug -pkg:olive ChatClient1.cs

ChatServer.exe : ChatServer.cs
	gmcs -debug -pkg:olive ChatServer.cs

clean:
	rm *.exe *.exe.mdb
