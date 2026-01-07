import day3.challenge1 as d3c1
import day3.challenge2 as d3c2

def test_d3c1_find_largest_total_num():
    line1 = "987654321111111"
    line2 = "811111111111119"
    line3 = "234234234234278"
    line4 = "818181911112111"
    assert d3c1.find_largest_total_number(line1) == 98
    assert d3c1.find_largest_total_number(line2) == 89
    assert d3c1.find_largest_total_number(line3) == 78
    assert d3c1.find_largest_total_number(line4) == 92

def test_d3c1_find_biggest_number_index():
    line1 = "987654321111111"
    line2 = "811111111111119"
    line3 = "234234234234278"
    line4 = "818181911112111"
    assert d3c1.find_biggest_number_index(d3c1.create_line_array_without_last_digit(line1)) == 0
    assert d3c1.find_biggest_number_index(d3c1.create_line_array_without_last_digit(line2)) == 0
    assert d3c1.find_biggest_number_index(d3c1.create_line_array_without_last_digit(line3)) == 13
    assert d3c1.find_biggest_number_index(d3c1.create_line_array_without_last_digit(line4)) == 6

def test_day3_challenge2():
    # TODO: Add tests
    pass
