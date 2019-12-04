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
    }
}