#!/bin/bash

run:
	dotnet watch run

migrations-add:
	dotnet-ef migrations add CreateTableTodo

migrations-update:
	dotnet-ef database update