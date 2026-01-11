import utility.retrieve_data as data_util

def challenge2(day_file: str = "day3"):
    data: list[str] = data_util.retrieve_data_from_file_name(day_file)
    for i in range(len(data)):
        data[i] = data[i].strip()
    total_count = 0
    for line in data:
        total_count += solution_loop(line)
    print(total_count)
    return None

def solution_loop(line: str) -> int:
    digits_remaining = len(line)
    loop_counter = 0
    while (digits_remaining > 12 and loop_counter < len(line) - 1):
        line, loop_counter, digits_deleted = compare_numbers(line, loop_counter)
        digits_remaining = digits_remaining - digits_deleted
    print(f"Final line: {line}")
    if digits_remaining > 12:
        print(f"MORE THAN 12 DIGITS: {line[0:12]}")
    return int(line[0:12])

def compare_numbers(line: str, loop_counter: int) -> tuple[str, int, int]:
    if (line[loop_counter] < line[loop_counter + 1]):
        new_line = line[:loop_counter] + line[loop_counter + 1:]
        loop_counter -= 1
        return new_line, loop_counter if loop_counter >= 0 else 0, 1
    else:
        loop_counter += 1
        return line, loop_counter, 0

if __name__ == "__main__":
    challenge2()
