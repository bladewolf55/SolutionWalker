if (test-path package) {remove-item package -recurse}
dotnet publish SolutionWalkerCli --output package