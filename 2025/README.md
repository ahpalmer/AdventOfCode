Advent of Code 2025.  I'm writing this in python.  I'm using AI to help me build the project structure, but not solve the puzzles

Notes on the structure of the project:
I'm using poetry to run the venv and structure.
To activate the venv: 
'poetry env activate' will give you the command to run, then you run that command

If you want to do all of this with one line: Invoke-Expression (poetry env activate)

In order to set-up the project:
Made the src / utility / test files manually.
Add an __init__.py file to all packages
Run poetry install (?)

poetry should create a poetry.lock file (auto-generated)
Also creates a pyproject.toml file.  Think of this as your .sln file

To get packages to be able to reference each other:
Add this to pyproject.toml file:
[tool.poetry]
packages = [{include = "utility", from = "src"}, {include = "day1", from = "src"}]

To get your files to be able to run in debug mode when you press f5 in vscode:
Add .vscode folder, add launch.json to the folder

Two different ways to import packages: look at day1/challenge1 and day1/challenge2 for two examples