import utility.retrieve_data as data_util

def challenge1(day_file = "day2"):
    data = data_util.retrieve_data_from_file_name(day_file)
    data_list = data.split(',')

# How to make this equation as greedy as possible?
# For large numbers (len > 8), the [0] value should be equal to the [len / 2] value before running calculations
# Problem: what if the [0] value is 7 digits and the [1] value is 9?  Can't cleanly say len / 2 at the start
def find_invalid_ids(range):
    range_list = range.split('-')
    if (len(range_list[1]) > 8):
        return find_invalid_ids_large(range_list)
    for i in range(int(range_list[0]), int(range_list[1])):
        if (i % 2 != 0 or len(str(i)) < 2 or i < 0):
            continue

def find_invalid_ids_large(range_list):
    count = 0
    for i in range (int(range_list[0]), int(range_list[1])):
        if (len(str(i)) % 2 != 0):
            continue
        current_value_length = len(str(i))
        if (str(i)[0] != str(i)[current_value_length // 2]):
            continue
        else:
            count = count + 1 if find_invalid_ids_individual(str(i)) else count
    return count

def find_invalid_ids_individual(check_number):
    length = len(check_number)
    if (length % 2 != 0 or length < 2 or int(check_number) < 0):
        return False
    if (length == 2 and check_number[0] == check_number[1]):
        return True
    elif (length == 2):
        return False
    first_half_length = (length // 2)
    first_half = check_number[0 : first_half_length]
    second_half = check_number[(length // 2):]
    if (int(first_half) == int(second_half)):
        return True
