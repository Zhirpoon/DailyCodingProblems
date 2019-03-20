using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
/*
    #17
    Suppose we represent our file system by a string in the following manner:

    The string "dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext" represents:

    dir
        subdir1
        subdir2
            file.ext
    The directory dir contains an empty sub-directory subdir1 and a sub-directory subdir2 containing a file file.ext.

    The string "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext" represents:

    dir
        subdir1
            file1.ext
            subsubdir1
        subdir2
            subsubdir2
                file2.ext
    The directory dir contains two sub-directories subdir1 and subdir2. subdir1 contains a file file1.ext and an empty second-level sub-directory subsubdir1. subdir2 contains a second-level sub-directory subsubdir2 containing a file file2.ext.

    We are interested in finding the longest (number of characters) absolute path to a file within our file system. For example, in the second example above, the longest absolute path is "dir/subdir2/subsubdir2/file2.ext", and its length is 32 (not including the double quotes).

    Given a string representing the file system in the above format, return the length of the longest absolute path to a file in the abstracted file system. If there is no file in the system, return 0.

    Note:

    The name of a file contains at least a period and an extension.

    The name of a directory or sub-directory will not contain a period.
*/
namespace DCP17
{
    public class DCP17
    {
        // slightly messy but okay for now
        public static string longestPath = "";

        public class Directory
        {
            public Directory(string name, int level, Directory parent = null)
            {
                value = Regex.Replace(name, "\t", "");
                this.level = level;
                this.parent = parent;
            }

            public string value = "";
            public int level;
            public List<Directory> subs = new List<Directory>();
            public string file = "";
            public Directory parent;
        }

        public static Directory BuildDirectory(string text)
        {
            var paths = text.Split('\n').ToList();
            var level = 0;

            if(paths.Count == 0)
            {
                return null;
            }

            // create root
            var root = new Directory(paths[0], level);
            var current = root;

            // remove root from paths
            paths.RemoveAt(0);

            foreach(var path in paths)
            {
                level = path.Count(p => p == '\t');
                var cleanedPath = Regex.Replace(path, "\t", "");

                if (cleanedPath.Contains("."))
                {
                    current.file = cleanedPath;
                }
                else
                {
                    if(level == current.level + 1)
                    {
                        var node = new Directory(cleanedPath, level, current);
                        current.subs.Add(node);
                        current = node;
                    }
                    else
                    {
                        while (level <= current.level)
                        {
                            current = current.parent;
                        }
                        var node = new Directory(cleanedPath, level, current);
                        current.subs.Add(node);
                        current = node;
                    }
                }
            }

            return root;
        }

        public static string GetFullPath(Directory dir, string path)
        {
            if(dir.parent == null)
            {
                return string.Format("{0}/{1}", dir.value, path);
            }
            else
            {
                return GetFullPath(dir.parent, string.Format("{0}/{1}", dir.value, path));
            }
        }

        public static void FindLongestPath(Directory dir)
        {
            if(dir == null || (dir.subs.Count == 0 && dir.file == ""))
            {
                return;
            }

            if(dir.file != "")
            {
                var path = GetFullPath(dir, dir.file);
                longestPath = path.Length > longestPath.Length ? path : longestPath;
            }
            else
            {
                foreach(var d in dir.subs)
                {
                    FindLongestPath(d);
                }   
            }
        }

        public static void Main(string[] args)
        {
            //var text = "dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext";
            var text = "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext";

            var root = BuildDirectory(text);

            FindLongestPath(root);

            var test = longestPath;

            Console.WriteLine(longestPath);
        }
    }
}
