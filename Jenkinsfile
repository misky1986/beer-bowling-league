pipeline {
    agent any
    stages {
        stage('Build') {
			steps {
				dotnet build BeerBowlingLeague.sln
			}
		}
		stage('Run Unit Test and Integration test') {
			steps {
				dotnet test
			}
		}
		stage('Run SonarQube') {
			steps {
				dotnet sonarscanner begin /k:"beer-bowling-league"
				dotnet build BeerBowlingLeague.sln
				dotnet sonarscanner end
			}
		}
		stage('Publish') {
			steps {
				dotnet publish -c Release -o published
			}
		}
		stage('Pack nuget Publish') {
			steps {
				dotnet pack -c Release -o nugetoutput
			}
		}
		stage('Publish to Nexus') {
			steps {
				dotnet nuget push nugetoutput\BeerBowlingLeague.1.0.0.nupkg -k 376435d4-d431-3df6-a7ce-3d717acac354 -s http://localhost:8081/repository/nuget-hosted/
			}
		}
	}
}