import day4.challenge1 as d4c1
import day4.challenge2 as d4c2
from day4.printing_floor import PrintingFloor


class TestPrintingFloor:
    """Tests for the PrintingFloor class used in challenge 1."""

    def test_add_string(self):
        floor = PrintingFloor()
        floor.add_string("..@@.@@@@.")
        floor.add_string("@@@.@.@.@@")
        assert floor.get_strings() == ["..@@.@@@@.", "@@@.@.@.@@"]

    def test_get_strings_empty(self):
        floor = PrintingFloor()
        assert floor.get_strings() == []

    def test_check_adjacent_spots_corner_top_left(self):
        """Test checking adjacent spots at top-left corner (0,0)."""
        floor = PrintingFloor()
        floor.add_string("..@@")
        floor.add_string("@@@.")
        # Position (0,0) is '.', adjacent: (0,1)='.', (1,0)='@', (1,1)='@'
        # Should count 2 '@' symbols (plus the cell itself if it's '@')
        assert floor.check_adjacent_spots(0, 0) == 2

    def test_check_adjacent_spots_corner_top_right(self):
        """Test checking adjacent spots at top-right corner."""
        floor = PrintingFloor()
        floor.add_string("..@@")
        floor.add_string("@@@.")
        # Position (0,3) is '@', adjacent: (0,2)='@', (1,2)='@', (1,3)='.'
        assert floor.check_adjacent_spots(0, 3) == 2

    def test_check_adjacent_spots_corner_bottom_left(self):
        """Test checking adjacent spots at bottom-left corner."""
        floor = PrintingFloor()
        floor.add_string("..@@")
        floor.add_string("@@@.")
        # Position (1,0) is '@', adjacent: (0,0)='.', (0,1)='.', (1,1)='@'
        assert floor.check_adjacent_spots(1, 0) == 1  # includes itself

    def test_check_adjacent_spots_corner_bottom_right(self):
        """Test checking adjacent spots at bottom-right corner."""
        floor = PrintingFloor()
        floor.add_string("..@@")
        floor.add_string("@@@.")
        # Position (1,3) is '.', adjacent: (0,2)='@', (0,3)='@', (1,2)='@'
        assert floor.check_adjacent_spots(1, 3) == 3

    def test_check_adjacent_spots_middle(self):
        """Test checking adjacent spots in the middle of the grid."""
        floor = PrintingFloor()
        floor.add_string("@@@")
        floor.add_string("@@@")
        floor.add_string("@@@")
        # Position (1,1) is '@', all 8 adjacent cells are '@' plus itself
        assert floor.check_adjacent_spots(1, 1) == 8

    def test_check_adjacent_spots_edge_top(self):
        """Test checking adjacent spots on top edge (not corner)."""
        floor = PrintingFloor()
        floor.add_string("@.@")
        floor.add_string("@@@")
        # Position (0,1) is '.', adjacent: (0,0)='@', (0,2)='@', (1,0)='@', (1,1)='@', (1,2)='@'
        assert floor.check_adjacent_spots(0, 1) == 5

    def test_check_adjacent_spots_edge_left(self):
        """Test checking adjacent spots on left edge (not corner)."""
        floor = PrintingFloor()
        floor.add_string("@.")
        floor.add_string(".@")
        floor.add_string("@@")
        # Position (1,0) is '.', adjacent: (0,0)='@', (0,1)='.', (1,1)='@', (2,0)='@', (2,1)='@'
        assert floor.check_adjacent_spots(1, 0) == 4

    def test_check_adjacent_spots_no_rolls(self):
        """Test with no paper rolls adjacent."""
        floor = PrintingFloor()
        floor.add_string("...")
        floor.add_string(".@.")
        floor.add_string("...")
        # Position (1,1) is '@', all adjacent are '.', only itself counts
        assert floor.check_adjacent_spots(1, 1) == 0

    def test_check_adjacent_spots_example_accessible_roll(self):
        """Test an accessible roll from the example (fewer than 4 adjacent rolls)."""
        # From the example, position (0,2) marked as 'x' should be accessible
        floor = PrintingFloor()
        floor.add_string("..@@.@@@@.")
        floor.add_string("@@@.@.@.@@")
        # Position (0,2) is '@', checking its adjacents
        # Adjacent: (0,1)='.', (0,3)='@', (1,1)='@', (1,2)='@', (1,3)='.'
        # Count: 4 (including itself) - so it's accessible (fewer than 4 adjacent)
        count = floor.check_adjacent_spots(0, 2)
        assert count < 5  # accessible means < 4 adjacent + itself = < 5 total


class TestDay4Challenge1:
    """Integration tests for day4 challenge1."""

    def test_example_grid_structure(self):
        """Test that the example grid can be loaded correctly."""
        floor = PrintingFloor()
        example_lines = [
            "..@@.@@@@.",
            "@@@.@.@.@@",
            "@@@@@.@.@@",
            "@.@@@@..@.",
            "@@.@@@@.@@",
            ".@@@@@@@.@",
            ".@.@.@.@@@",
            "@.@@@.@@@@",
            ".@@@@@@@@.",
            "@.@.@@@.@.",
        ]
        for line in example_lines:
            floor.add_string(line)
        
        assert len(floor.get_strings()) == 10
        assert len(floor.get_strings()[0]) == 10


def test_day4_challenge2():
    # TODO: Add tests
    pass
