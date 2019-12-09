# Beer Bowling League


## Nexus access
User: admin
Password: 650df91a-32ec-4f95-a039-b4186a3cd43c, lavet om til Test1234!

Nuget API Key:

You can register this key for a given repository with the following command:
nuget setapikey 376435d4-d431-3df6-a7ce-3d717acac354 -source http://localhost:8081/repository/{repository name}/


# command structure
$ dotnet nuget push {nupkg-name} -k {nuget-api-key} -s {repository-source-uri}
# actual command I issued (see above for key)
$ dotnet nuget push LinqExtensions.1.0.0.nupkg -k a0fdd1a1-af65-3ac9-ab28-c0b1bfadc82a -s http://localhost:9876/repository/nuget-hosted/


dotnet nuget push 