.PHONY: format
format:
	dotnet format deepmongus.csproj

.PHONY: makecs
makecs:
	dotnet restore
	dotnet build