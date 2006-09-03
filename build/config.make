prefix=`pkg-config mono --variable prefix`
exec_prefix=${prefix}
mono_libdir=${exec_prefix}/lib
MCS_FLAGS = -debug+
RUNTIME = mono
MONO_VERSION = 1.1.9.0
