#!/bin/bash
dotnet watch --project ./TileGameTests test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=./lcov.info