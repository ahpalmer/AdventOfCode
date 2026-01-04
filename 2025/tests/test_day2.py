import day2.challenge1 as d2

def test_day2_challenge1_find_invalid_ids_large():
    range_list = ['1188511880', '1188511890']
    assert d2.find_invalid_ids_large(range_list) == 1

def test_day2_challenge1_find_invalid_ids_ind():
    check_number_1 = "5"
    check_number_2 = "10"
    check_number_3 = "0"
    check_number_4 = "-4"
    check_number_5 = "1010"
    assert d2.find_invalid_ids_individual(check_number_1) == False
    assert d2.find_invalid_ids_individual(check_number_2) == False
    assert d2.find_invalid_ids_individual(check_number_3) == False
    assert d2.find_invalid_ids_individual(check_number_4) == False
    assert d2.find_invalid_ids_individual(check_number_5) == True