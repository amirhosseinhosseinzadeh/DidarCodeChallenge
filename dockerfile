FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY /src/DidarCodeChallenge.Api/DidarCodeChallenge.Api.csproj ./
RUN dotnet restore .

COPY src/DidarCodeChallenge.Api/. ./
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine As runtime

RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

RUN apk add libgdiplus --no-cache --repository http://dl-3.alpinelinux.org/alpine/edge/testing/ --allow-untrusted
RUN apk add libc-dev --no-cache

WORKDIR /app
EXPOSE 90
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "DidarCodeChallenge.Api.dll"]