﻿namespace Day7.DataStructure;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Files
{
    //Fields
    private string fileName;
    private int fileSize;

    //Properties
    public string FileName { get; set; }
    public int FileSize { get; set; }

    //Constructor
    public Files(string fileName, int fileSize)
    {
        this.FileName = fileName;
        this.FileSize = fileSize;
    }
}