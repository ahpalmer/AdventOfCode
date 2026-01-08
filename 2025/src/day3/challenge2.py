import utility.retrieve_data as data_util

def challenge2(day_file: str = "day3"):
    data: list[str] = data_util.retrieve_data_from_file_name(day_file)
    total_count = 0
    for line in data:
        total_count = solution_loop(line)
    print(data)
    return None

def solution_loop(line: str) -> int:
    digits_deleted = 0
    loop_counter = 0
    line_length_original = len(line)
    while (digits_deleted < 3 and loop_counter < len(line) - 1):
        line, loop_counter, temp_digits_deleted = compare_numbers(line, loop_counter)
        digits_deleted += temp_digits_deleted
    return int(line[:line_length_original - 3])

def compare_numbers(line: str, loop_counter: int) -> tuple[str, int, int]:
    if (line[loop_counter] < line[loop_counter + 1]):
        new_line = line[:loop_counter] + line[loop_counter + 1:]
        return new_line, loop_counter, 1
    else:
        loop_counter += 1
        return line, loop_counter, 0

if __name__ == "__main__":
    challenge2()
