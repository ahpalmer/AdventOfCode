﻿namespace Day8;

class Program
{
    Challenge1 Challenge1;
    Challenge2 Challenge2;
    Utility utility;

    public Program()
    {
        this.Challenge1 = new Challenge1();
        this.Challenge2 = new Challenge2();
        this.utility = new Utility();
    }

    public static void Main(string[] args)
    {
        //Challenge1.ChallengeOneSolve();
        Challenge2 challenge2 = new Challenge2();
        challenge2.ChallengeTwoSolve();
    }
}