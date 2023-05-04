namespace Day7.DataStructure;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

public class Directory
{
    //Fields
    private string dirName;
    private List<Files> files;
    private List<Directory> directories;
    private int dirSize;

    //Properties
    public string DirName { get; set; }
    public List<Files> Files { get; set; }
    public List<Directory> Directories { get; set; }
    public int DirSize { get; set; }

    //Default Constructor
    public Directory(string dirName)
    {
        this.DirName = dirName;
        this.Files = new List<Files>();
        this.Directories = new List<Directory>();
        this.DirSize = 0;
    }

    //Constructor with inputs
    public Directory(List<Files> files, List<Directory> directories)
    {
        this.Files = files;
        this.Directories = directories;
        this.DirSize = 0;
    }

    public void AddDirectory(Directory directory)
    {
        Directories.Add(directory);
    }

    public void RemoveDirectory(Directory directory)
    {
        Directories.Remove(directory);
    }

    public void AddFiles(Files files)
    {
        Files.Add(files);
    }

    public void RemoveFiles(Files files)
    {
        Files.Remove(files);
    }

    public int FindCurrentDirectorySize()
    {
        this.dirSize = this.Files.Select(s => s.FileSize).Sum();
        return this.dirSize;
    }

    public int FindTotalDirectorySize()
    {
        int total = 0;
        total += this.FindCurrentDirectorySize();

        if (this.Directories.Any())
        {
            foreach (var directory in this.Directories)
            {
                total += directory.FindTotalDirectorySize();
            }
        }

        return total;
    }
}
