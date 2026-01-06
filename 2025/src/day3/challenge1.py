import utility.retrieve_data as data_util

def challenge1(day_file: str = "day3"):
    data: list[str] = data_util.retrieve_data_from_file_name(day_file)
    # TODO: Implement solution
    print(data)
    return None

if __name__ == "__main__":
    challenge1()
