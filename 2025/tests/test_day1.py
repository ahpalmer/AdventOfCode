import day1
import utility.retrieve_data as data_util

def test_day1_challenge2_input():
    list = data_util.retrieve_data_from_file_name("day1test")
    assert list[0].strip() == "L68"

def test_day1_challenge2():
    actual_answer = day1.challenge2("day1test")
    assert actual_answer == 6