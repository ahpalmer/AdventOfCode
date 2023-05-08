namespace Day7.DataStructure;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

public class DirectoryBuilds
{
    //Fields
    private string dirName;
    private DirectoryBuilds parentDir;
    private List<FileBuilds> files;
    private List<DirectoryBuilds> directories;
    private int dirSize;

    //Properties
    public string DirName { get; set; }
    public DirectoryBuilds ParentDir { get; set; }
    public List<FileBuilds> Files { get; set; }
    public List<DirectoryBuilds> Directories { get; set; }
    public int DirSize { get; set; }

    //Default Constructor
    public DirectoryBuilds(string dirName)
    {
        this.DirName = dirName;
        this.Files = new List<FileBuilds>();
        this.Directories = new List<DirectoryBuilds>();
        this.DirSize = 0;
    }

    //Constructor with inputs
    public DirectoryBuilds(List<FileBuilds> files, List<DirectoryBuilds> directories)
    {
        this.Files = files;
        this.Directories = directories;
        this.DirSize = 0;
    }

    public void AddDirectory(DirectoryBuilds directory)
    {
        Directories.Add(directory);
    }

    public void RemoveDirectory(DirectoryBuilds directory)
    {
        Directories.Remove(directory);
    }

    public void AddFiles(FileBuilds files)
    {
        Files.Add(files);
    }

    public void RemoveFiles(FileBuilds files)
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
