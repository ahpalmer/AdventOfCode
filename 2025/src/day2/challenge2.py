import utility.retrieve_data as data_util

def challenge2(day_file = "day2"):
    data: list[str] = data_util.retrieve_data_from_file_name(day_file)
    data_list: list[str] = data[0].split(',')
    count: int = find_invalid_ids(data_list)
    print(count)
    return count

def find_invalid_ids(data_list: list[str]):
    count = 0
    for range in data_list:
        range_list: list[str] = range.split('-')
        count = count + find_invalid_ids_range(range_list)
    return count

def find_invalid_ids_range(range_list: list[str]):
    count = 0
    for i in range (int(range_list[0]), int(range_list[1]) + 1):
        count = count + find_invalid_ids_individual(str(i))
    return count

def find_invalid_ids_individual(check_number: str) -> int:
    if len(check_number) < 2:
        return 0
    if len(set(check_number)) == 1:
        return int(check_number)
    length: int = len(check_number)
    divisors: list[int] = find_divisors(length)
    for divisor in divisors:
        number_segments: list[str] = segment_number(check_number, divisor)
        if len(set(number_segments)) == 1:
            return int(check_number)
    return 0

def find_divisors(n: int):
    if n <= 1:
        return []
    divisors = []
    for i in range (1, n + 1):
        if n % i == 0:
            divisors.append(i)
    divisors.remove(1)
    divisors.remove(n)
    return divisors

def segment_number(check_number: str, divisor: int) -> list[str]:
    number_segments = []
    segment_size = len(check_number) // divisor
    counter = 0
    for i in range(divisor):
        segment = check_number[counter : counter + segment_size]
        counter += segment_size
        number_segments.append(segment)
    return number_segments

if __name__ == "__main__":
    challenge2()