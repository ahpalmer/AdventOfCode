import utility.retrieve_data as data_util
from day4.printing_floor import PrintingFloor

def challenge2(day_file: str = "day4"):
    data: list[str] = data_util.retrieve_data_from_file_name(day_file)

    printing_floor = PrintingFloor()
    for line in data:
        printing_floor.add_string(line)

    changed_roll: bool = False
    total_accessible_rolls = 0
    
    while not changed_roll:
        printing_floor, accessible_paper_count = run_challenge(printing_floor)
        if accessible_paper_count == 0:
            changed_roll = True
        total_accessible_rolls = total_accessible_rolls + accessible_paper_count
        print("One Rotation Done")
    
    print(total_accessible_rolls)
    return None

def run_challenge(printing_floor: PrintingFloor) -> tuple[PrintingFloor, int]:
    next_printing_floor = PrintingFloor()
    y_length = len(printing_floor)
    x_length = len(printing_floor.strings[0])
    accessible_paper_count: int = 0
    for y in range(0, y_length):
        next_printing_string : list[str] = list(printing_floor.strings[y])
        for x in range(0, x_length):
            if printing_floor.strings[y][x] != '@':
                continue
            elif printing_floor.check_adjacent_spots(y, x) < 4:
                accessible_paper_count += 1
                next_printing_string[x] = '.'

            if y == 138:
                print("last row")
            if x == 138:
                print("last column")
        next_printing_floor.add_string("".join(next_printing_string))

    print(accessible_paper_count)
    return next_printing_floor, accessible_paper_count

if __name__ == "__main__":
    challenge2()
