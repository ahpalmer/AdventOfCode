import day2.challenge1 as d2
import day2.challenge2 as d2c2

def test_day2_challenge2_find_invalid_ids():
    data = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124"
    data_list = data.split(',')
    assert d2c2.find_invalid_ids(data_list) == 4174379265

def test_day2_challenge2_find_invalid_ids_individual():
    # Valid repeating patterns - should return the number as int
    assert d2c2.find_invalid_ids_individual("1010") == 1010           # "10" repeats 2x
    assert d2c2.find_invalid_ids_individual("123123") == 123123       # "123" repeats 2x
    assert d2c2.find_invalid_ids_individual("111111") == 111111       # "1", "11", or "111" all repeat
    assert d2c2.find_invalid_ids_individual("123412341234") == 123412341234  # "1234" repeats 3x
    
    # Invalid - no repeating pattern, should return 0
    assert d2c2.find_invalid_ids_individual("1234") == 0              # No equal segments
    assert d2c2.find_invalid_ids_individual("1011") == 0              # "10" != "11"
    assert d2c2.find_invalid_ids_individual("123456") == 0            # No repeating pattern
    
    # Edge cases
    assert d2c2.find_invalid_ids_individual("5") == 0                 # Single digit, no divisors
    assert d2c2.find_invalid_ids_individual("") == 0                  # Empty string

def test_day2_challenge2_segment_number():
    assert d2c2.segment_number("123412341234", 2) == ["123412", "341234"]
    assert d2c2.segment_number("123412341234", 3) == ["1234", "1234", "1234"]
    assert d2c2.segment_number("123412341234", 4) == ["123", "412", "341", "234"]

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