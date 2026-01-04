import day2.challenge1 as d2

def test_day2_challenge1_find_invalid_ids():
    data = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124"
    data_list = data.split(',')
    assert d2.find_invalid_ids(data_list) == 1227775554

def test_day2_challenge1_find_invalid_ids_range():
    range_list = ['1188511880', '1188511890']
    assert d2.find_invalid_ids_range(range_list) == 1188511885

def test_day2_challenge1_find_invalid_ids_ind():
    check_number_1 = "5"
    check_number_2 = "10"
    check_number_3 = "0"
    check_number_4 = "-4"
    check_number_5 = "1010"
    assert d2.find_invalid_ids_individual(check_number_1) == 0
    assert d2.find_invalid_ids_individual(check_number_2) == 0
    assert d2.find_invalid_ids_individual(check_number_3) == 0
    assert d2.find_invalid_ids_individual(check_number_4) == 0
    assert d2.find_invalid_ids_individual(check_number_5) == 1010