thisdir = tools/sqlmetal
SUBDIRS = 
include ../../build/rules.make

LOCAL_MCS_FLAGS = \
                  /r:System.dll
                  /r:System.Xml.dll
                  /r:System.Data.Linq.dll
                  /r:System.Data.Linq.Design.dll
                  /r:Mono.GetOptions.dll

PROGRAM = sqlmetal.exe

include ../../build/executable.make