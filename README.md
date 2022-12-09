# git-teams-remove
* Remember .Net [core](https://learn.microsoft.com/en-us/dotnet/core/install/how-to-detect-installed-versions?pivots=os-windows) and Frameworks are completely diffeent 
* This is [Core](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.403-windows-x64-installer) and not needed , this process also follows [core](https://learn.microsoft.com/en-us/graph/tutorials/dotnet?tabs=aad&tutorial-step=8) and not needed 
* install framework [4.7.2](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472)
* Validate Framework [installed](https://learn.microsoft.com/en-us/dotnet/framework/migration-guide/how-to-determine-which-versions-are-installed)
* dotnet restore 
* [Package reference format](https://stackoverflow.com/questions/60089760/cant-restore-nuget-packages-in-framework-4-7-2) follow one format else restore will not work
* [Link to test teams](https://teams.microsoft.com/_?tenantId=170f95e3-de76-4073-8222-7574715537b5)
* Delete and recreate the secret every time
* Common Error :
```
{"error":{"code":"Forbidden","message":"Missing role permissions on the request. API requires one of 'ChatMember.ReadWrite.All, Chat.ReadWrite.All, Chat.Manage.Chat'. Roles on the request 'TeamMember.ReadWriteNonOwnerRole.All, ChatMessage.Read.All, Files.ReadWrite.All, TeamMember.ReadWrite.All, Chat.Read.All, ChatMember.Read.All, Chat.Create'. Resource specific consent grants on the request ''.","innerError":{"date":"2022-12-09T20:51:32","request-id":"041f6052-8cf1-4ae4-8c2c-51035300b481","client-request-id":"041f6052-8cf1-4ae4-8c2c-51035300b481"}}}
```