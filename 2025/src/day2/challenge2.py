import utility.retrieve_data as data_util
from day2 import challenge1 as c1

def challenge2(day_file = "day2"):
    data = data_util.retrieve_data_from_file_name(day_file)
    data_list = data[0].split(',')
    count = find_invalid_ids(data_list)
    print(count)
    return count