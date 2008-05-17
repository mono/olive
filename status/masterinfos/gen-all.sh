#!/bin/sh
cp "`cygpath -u c:/Program\ Files/Reference\ Assemblies/Microsoft/Framework/v3.0`"/*.dll .
../mono-api-info Microsoft.ServiceModel.Channels.Mail.dll > Microsoft.ServiceModel.Channels.Mail.xml
../mono-api-info Microsoft.ServiceModel.Channels.Mail.ExchangeWebService.dll > Microsoft.ServiceModel.Channels.Mail.ExchangeWebService.xml
../mono-api-info PresentationBuildTasks.dll > PresentationBuildTasks.xml
../mono-api-info PresentationCore.dll > PresentationCore.xml
../mono-api-info PresentationFramework.Aero.dll > PresentationFramework.Aero.xml
../mono-api-info PresentationFramework.Classic.dll > PresentationFramework.Classic.xml
../mono-api-info PresentationFramework.dll > PresentationFramework.xml
../mono-api-info PresentationFramework.Luna.dll > PresentationFramework.Luna.xml
../mono-api-info PresentationFramework.Royale.dll > PresentationFramework.Royale.xml
../mono-api-info ReachFramework.dll > ReachFramework.xml
../mono-api-info System.IdentityModel.dll > System.IdentityModel.xml
../mono-api-info System.IdentityModel.Selectors.dll > System.IdentityModel.Selectors.xml
../mono-api-info System.IO.Log.dll > System.IO.Log.xml
../mono-api-info System.Printing.dll > System.Printing.xml
../mono-api-info System.Runtime.Serialization.dll > System.Runtime.Serialization.xml
../mono-api-info System.ServiceModel.dll > System.ServiceModel.xml
../mono-api-info System.Speech.dll > System.Speech.xml
../mono-api-info System.Workflow.Activities.dll > System.Workflow.Activities.xml
../mono-api-info System.Workflow.ComponentModel.dll > System.Workflow.ComponentModel.xml
../mono-api-info System.Workflow.Runtime.dll > System.Workflow.Runtime.xml
../mono-api-info UIAutomationClient.dll > UIAutomationClient.xml
../mono-api-info UIAutomationClientsideProviders.dll > UIAutomationClientsideProviders.xml
../mono-api-info UIAutomationProvider.dll > UIAutomationProvider.xml
../mono-api-info UIAutomationTypes.dll > UIAutomationTypes.xml
../mono-api-info WindowsBase.dll > WindowsBase.xml
../mono-api-info WindowsFormsIntegration.dll > WindowsFormsIntegration.xml
rm *.dll