from pathlib import Path
import sys

def get_project_root() -> Path:
    return Path(__file__).resolve().parent.parent.parent

def create_new_day(day_number: int):
    project_root = get_project_root()

    data_file = project_root / "data" / f"day{day_number}.txt"
    data_file.touch(exist_ok=True)
    print(f"Created: {data_file}")

    instruction_file = project_root / "instructions" / f"day{day_number}.txt"
    instruction_file.touch(exist_ok=True)
    print(f"Created: {instruction_file}")

    day_folder = project_root / "src" / f"day{day_number}"
    day_folder.mkdir(exist_ok=True)
    print(f"Created: {day_folder}")

    init_file = day_folder / "__init__.py"
    init_file.touch(exist_ok=True)
    print(f"Created: {init_file}")

    for i in [1, 2]:
        challenge = day_folder / f"challenge{i}.py"
        challenge.write_text(f'''import utility.retrieve_data as data_util

def challenge{i}(day_file: str = "day{day_number}"):
    data: list[str] = data_util.retrieve_data_from_file_name(day_file)
    # TODO: Implement solution
    print(data)
    return None

if __name__ == "__main__":
    challenge{i}()
''')
        print(f"Created: {challenge}")
    
    test_file = project_root / "tests" / f"test_day{day_number}.py"
    test_file.write_text(f'''import day{day_number}.challenge1 as d{day_number}c1
import day{day_number}.challenge2 as d{day_number}c2

def test_day{day_number}_challenge1():
    # TODO: Add tests
    pass

def test_day{day_number}_challenge2():
    # TODO: Add tests
    pass
''')
    print(f"Created: {test_file}")
    
    print(f"\n✅ Day {day_number} setup complete!")

def clean_pycache():
    """Delete all __pycache__ folders."""
    project_root = Path(__file__).parent.parent.parent
    count = 0
    for pycache in project_root.rglob("__pycache__"):
        import shutil
        shutil.rmtree(pycache)
        print(f"Deleted: {pycache}")
        count += 1
    print(f"\n✅ Deleted {count} __pycache__ folders")

def run_day(day_number: int, challenge: int = 1):
    """Run a specific day's challenge."""
    import importlib
    module = importlib.import_module(f"day{day_number}.challenge{challenge}")
    func = getattr(module, f"challenge{challenge}")
    func()

# ============ Command Registry ============
COMMANDS = {
    "new_day": {
        "func": create_new_day,
        "args": ["day_number:int"],
        "help": "Create files for a new day"
    },
    "clean": {
        "func": clean_pycache,
        "args": [],
        "help": "Delete all __pycache__ folders"
    },
        "run": {
        "func": run_day,
        "args": ["day_number:int", "challenge:int=1"],
        "help": "Run a day's challenge"
    },
}

def print_help():
    print("Usage: python -m src.utility.scripts <command> [args]\n")
    print("Commands:")
    for name, info in COMMANDS.items():
        args_str = " ".join(f"<{a}>" for a in info["args"])
        print(f"  {name} {args_str}")
        print(f"      {info['help']}\n")

def main():
    if len(sys.argv) < 2 or sys.argv[1] in ["-h", "--help", "help"]:
        print_help()
        sys.exit(0)
    
    command = sys.argv[1]

    if command not in COMMANDS:
        print(f"Unknown command: {command}")
        print_help()
        sys.exit(1)
    
    #Parse args
    args = []
    for i, arg in enumerate(sys.argv[2:]):
        try:
            args.append(int(arg))
        except ValueError:
            args.append(arg)
    
    COMMANDS[command]["func"](*args)

if __name__ == "__main__":
    main()