from utility.retrieve_data import retrieve_data_from_file_name

def challenge1():
    data = retrieve_data_from_file_name("day1")
    count = 0
    safe_number = 50
    for input_line in data:
        line = input_line.strip()
        if (line[0] == "R"):
            safe_number += int(line[1:]) % 100
        else:
            safe_number -= int(line[1:]) % 100
        if (safe_number > 99):
            safe_number -= 100
        elif (safe_number < 0):
            safe_number += 100
        if (safe_number == 0):
            count += 1
    print(count)


challenge1()