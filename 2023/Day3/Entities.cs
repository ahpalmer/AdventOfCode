using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023Day3;

internal class Point
{
    public int X { get; set; }
    public int Y { get; set; }
    private bool _symbol { get; set; }
    private List<int> numbers = new List<int>();

    public List<int> Numbers
    {
        get { return numbers; }
        set { numbers = value; }
    }

    public bool Symbol
    {
        get { return _symbol; }
        set { _symbol = value; }
    }

    public Point(int x, int y, bool symbol = false)
    {
        X = x;
        Y = y;
        Symbol = symbol;
        numbers = new List<int>();

    }

    public override string ToString()
    {
        return $"{X}, {Y}";
    }
    public void AddNearbyNumber(int number)
    {
        numbers.Add(number);
    }
}

internal class NumberPoint
{
    public bool nearTwoNumbers { get; set; }
    private int _number;
    private List<Point> _pointList = new List<Point>();

    public int Number
    {
        get { return _number; }
        set { _number = value; }
    }

    public List<Point> PointList
    {
        get { return _pointList; }
        set { _pointList = value; }
    }

    public void AddPointValue(Point point)
    {
        _pointList.Add(point);
    }



    public NumberPoint (int number)
    {
        _number = number;
        PointList = new List<Point>();
        nearTwoNumbers = false;
    }

    public NumberPoint(int number, List<Point> pointList, bool nearSymbol)
    {
        _number = number;
        PointList = pointList;
        this.nearTwoNumbers = nearSymbol;
    }
}
