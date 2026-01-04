import utility.retrieve_data as data_util

def challenge1(day_file = "day2"):
    data = data_util.retrieve_data_from_file_name(day_file)
    data_list = data[0].split(',')
    count = find_invalid_ids(data_list)
    print(count)
    return count

# How to make this equation as greedy as possible?
# For large numbers (len > 8), the [0] value should be equal to the [len / 2] value before running calculations
# Problem: what if the [0] value is 7 digits and the [1] value is 9?  Can't cleanly say len / 2 at the start
def find_invalid_ids(data_list):
    count = 0
    for range in data_list:
        range_list = range.split('-')
        count = count + find_invalid_ids_range(range_list)
    return count

def find_invalid_ids_range(range_list):
    count = 0
    for i in range (int(range_list[0]), int(range_list[1]) + 1):
        if (len(str(i)) % 2 != 0):
            continue
        current_value_length = len(str(i))
        if (str(i)[0] != str(i)[current_value_length // 2]):
            continue
        else:
            count = count + find_invalid_ids_individual(str(i))
    return count

def find_invalid_ids_individual(check_number):
    length = len(check_number)
    if (length % 2 != 0 or length < 2 or int(check_number) < 0):
        return 0
    if (length == 2 and check_number[0] == check_number[1]):
        return int(check_number)
    elif (length == 2):
        return 0
    first_half_length = (length // 2)
    first_half = check_number[0 : first_half_length]
    second_half = check_number[(length // 2):]
    if (int(first_half) == int(second_half)):
        return int(check_number)
    return 0

challenge1()