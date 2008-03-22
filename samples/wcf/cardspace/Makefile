all: manage.exe import.exe gettoken.exe

manage.exe : manage.cs
	gmcs -pkg:olive manage.cs

import.exe : import.cs
	gmcs -pkg:olive import.cs

gettoken.exe : gettoken.cs
	gmcs -pkg:olive gettoken.cs

clean:
	rm -rf manage.exe import.exe gettoken.exe

