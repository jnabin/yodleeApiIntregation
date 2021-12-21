dotnet sonarscanner begin /k:"YodleeWrapper_YodleeWrapper" /d:sonar.host.url="http://147.182.231.175:9000"  /d:sonar.login="3dda30ce44ff1c55d34aaefec08512f42d8371da" /d:sonar.cs.opencover.reportsPaths="**/coverage.opencover.xml" /d:sonar.coverage.exclusions="**Tests*.cs"

dotnet build

OpenCover.Console.exe -target:"c:\Program Files\dotnet\dotnet.exe" -targetargs:"test" -output:coverage.opencover.xml -oldStyle -filter:"+[YodleeIntegration.*]* -[YodleeIntegration.*.Test*]*" -register:user

dotnet sonarscanner end /d:sonar.login="3dda30ce44ff1c55d34aaefec08512f42d8371da"