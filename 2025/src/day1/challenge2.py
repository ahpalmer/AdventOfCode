import utility.retrieve_data as data_util

def challenge2(day_file = "day1"):
    data = data_util.retrieve_data_from_file_name(day_file)
    count = 0
    safe_number = 50
    for input_line in data:
        line = input_line.strip()
        line_number = int(line[1:])
        was_on_zero = False
        if (safe_number == 0):
            was_on_zero = True
        if (line_number > 99):
            hundreds = line_number // 100
            count += hundreds
            line_number -= hundreds * 100
        if (line[0] == "R"):
            safe_number += line_number
        else:
            safe_number -= line_number
        if (safe_number > 99):
            safe_number -= 100
            if (was_on_zero == False):
                count += 1
        elif (safe_number < 0):
            safe_number += 100
            if (was_on_zero == False):
                count += 1
        elif (safe_number == 0):
            count += 1
    print(count)
    return count


if __name__ == "__main__":
    challenge2()