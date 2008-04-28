
Test\SwitchMode\bin\Debug\SwitchMode.exe System.ServiceModel_test_net_3_0.dll.config client
start WCFServers.exe
nunit-console.exe System.ServiceModel_test_net_3_0.dll  /out:TestResults.txt
WCFServers.exe shutdown