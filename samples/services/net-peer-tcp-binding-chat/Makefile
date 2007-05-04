all: ChatServer.exe

ChatServer.exe : ChatServer.cs
	gmcs -debug -pkg:olive ChatServer.cs

clean:
	rm ChatServer.exe ChatServer.exe.mdb