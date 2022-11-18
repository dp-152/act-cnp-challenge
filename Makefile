.PHONY: clean

mkfile_path := $(abspath $(lastword $(MAKEFILE_LIST)))
mkfile_dir := $(dir $(mkfile_path))

ifeq ($(OS),Windows_NT)
DOTNET  = dotnet.exe
CD      = cd.exe
COMPOSE = docker-compose.exe
else
DOTNET  = dotnet
CD      = cd
COMPOSE = docker-compose
endif

SLN     = $(mkfile_dir)CnpChallenge.sln
DEFPROJ = $(mkfile_dir)CnpChallenge.API
OUTDIR  = $(mkfile_dir)out

build:
	$(DOTNET) build $(SLN)

publish:
	$(DOTNET) publish $(SLN) -c Release -o $(OUTDIR)

restore:
	$(DOTNET) restore $(SLN)

compose:
	$(COMPOSE) up --build -d

compose-cleanbuild:
	$(COMPOSE) build --no-cache && $(COMPOSE) up -d

clean:
	$(DOTNET) clean $(SLN)
