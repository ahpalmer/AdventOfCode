class PrintingFloor:
    def __init__(self):
        self.strings: list[str] = []
    
    def add_string(self, value: str) -> None:
        self.strings.append(value)
    
    def get_strings(self) -> list[str]:
        return self.strings
    
    def check_adjacent_spots(self, y_value: int, x_value: int) -> int:
        max_y = len(self.strings) - 1
        max_x = len(self.strings[y_value]) - 1
        total_count: int = 0

        if y_value == 0:
            y_range: range = range(0, 2)
        elif y_value == max_y:
            y_range: range = range(y_value - 1, max_y + 1)
        else:
            y_range: range = range(y_value - 1, y_value + 2)
        
        if x_value == 0:
            x_range: range = range(0, 2)
        elif x_value == max_x:
            x_range: range = range(x_value - 1, max_x + 1)
        else:
            x_range: range = range(x_value - 1, x_value + 2)

        for y in y_range:
            for x in x_range:
                if self.strings[y][x] == '@':
                    total_count += 1
        
        if self.strings[y_value][x_value] == '@':
            total_count -= 1

        return total_count