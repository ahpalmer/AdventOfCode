from pathlib import Path

def retrieve_data_from_file_name(file_name):
    data_path = retrieve_data_path()
    full_path = data_path / (file_name + ".txt")
    return retrieve_data_from_absolute_path(full_path)

def retrieve_data_path():
    project_root = Path(__file__).parent.parent.parent
    data_path = project_root / 'data'
    return data_path

def retrieve_data_from_absolute_path(file_path):
    try:
        with open(file_path, 'r') as file:
            content = file.readlines()
        return content
    except FileNotFoundError:
        print(f"File Not found: {file_path}")
        return []