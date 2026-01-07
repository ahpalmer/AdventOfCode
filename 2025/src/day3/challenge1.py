import utility.retrieve_data as data_util

def challenge1(day_file: str = "day3"):
    data: list[str] = data_util.retrieve_data_from_file_name(day_file)
    total_count = 0
    for line in data:
        line_clean = line.replace('\n', '')
        total_count += find_largest_total_number(line_clean)
    print(total_count)
    return None

def find_largest_total_number(line: str) -> int:
        largest_index: int = find_biggest_number_index(create_line_array_without_last_digit(line))
        line_array: list[int] = [int(char) for char in line]
        leftover_array = line_array[largest_index + 1:]
        second_largest_index: int = find_biggest_number_index(leftover_array)
        first_digit = str(line_array[largest_index])
        second_digit = str(leftover_array[second_largest_index])
        return int(first_digit + second_digit)

def find_biggest_number_index(line_array: list[int]) -> int:
    largest = max(line_array)
    return line_array.index(largest)

def create_line_array_without_last_digit(line: str) -> list[int]:
    line_array: list[int] = [int(char) for char in line]
    line_array.pop()
    return line_array

if __name__ == "__main__":
    challenge1()
