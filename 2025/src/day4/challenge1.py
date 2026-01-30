import utility.retrieve_data as data_util
from day4.printing_floor import PrintingFloor

def challenge1(day_file: str = "day4"):
    data: list[str] = data_util.retrieve_data_from_file_name(day_file)

    printing_floor = PrintingFloor()
    for line in data:
        printing_floor.add_string(line)
    
    y_length = len(data)
    x_length = len(data[0])
    accessible_paper_count: int = 0
    for y in range(0, y_length):
        for x in range(0, x_length):
            if y == 138:
                print("last row")
            if x == 138:
                print("last column")
            if data[y][x] != '@':
                continue
            elif printing_floor.check_adjacent_spots(y, x) < 4:
                accessible_paper_count += 1

    print(accessible_paper_count)
    return None

if __name__ == "__main__":
    challenge1()
