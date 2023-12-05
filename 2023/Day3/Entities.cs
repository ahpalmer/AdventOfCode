using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023Day3;

internal struct Point
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool Symbol { get; set; }

    public Point(int x, int y, bool symbol = false)
    {
        X = x;
        Y = y;
        Symbol = symbol;
    }

    public override string ToString()
    {
        return $"{X}, {Y}";
    }
}

internal class NumberPoint
{
    private int _number;
    private List<Point> _pointList = new List<Point>();
    public bool nearSymbol { get; set; }

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
        nearSymbol = false;
    }

    public NumberPoint(int number, List<Point> pointList, bool nearSymbol)
    {
        _number = number;
        PointList = pointList;
        this.nearSymbol = nearSymbol;
    }
}
