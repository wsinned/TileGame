#!/bin/bash
dotnet watch --project ./test/TileGameTests test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=./lcov.info