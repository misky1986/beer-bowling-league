pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                dotnet build
            }
        }
		stage('Run Unit Test') {
            steps {
                dotnet test
            }
        }
    }
}