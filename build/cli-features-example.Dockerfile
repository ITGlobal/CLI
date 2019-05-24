FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS builder
WORKDIR /app
COPY . /app
RUN dotnet publish -c Release -o /out /app/samples/cli-features-example/cli-features-example.csproj


FROM mcr.microsoft.com/dotnet/core/runtime:2.2
WORKDIR /app
COPY --from=builder /out /app
ENTRYPOINT ["dotnet", "/app/cli-features-example.dll"]