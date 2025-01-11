using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.SimplifiedPath
{
    public static class SimplifiedPath
    {
        public static string SimplifyPath(string path)
        {
            var components = path.Split('/');
            Stack<string> stack = new Stack<string>();
            foreach (var component in components)
            {
                if (component == "." || component == null || component == "")
                    continue;
                else if (component == "..")
                {
                    if (stack.Count > 0)
                        stack.Pop();
                }
                else
                    stack.Push(component);
            }
            return $"/{string.Join('/', stack.Reverse())}";
        }
        private static void RemoveRepeatedSlashes(StringBuilder path, int index)
        {
            for (int i = index; i < path.Length; i++)
            {
                if (path[i] == '/')
                {
                    path.Remove(i, 1);
                    i--;

                }
                else
                    break;
            }
        }
        private static int RemoveDirectory(StringBuilder path, int i)
        {
            int removedCount = 0;
            if (i != 0)
            {
                for (int j = i; j > 0 && path[j] != '/'; j--)
                    removedCount++;
                if (removedCount > 0)
                {
                    path.Remove(i - removedCount, removedCount + 1);
                    i = i - (removedCount + 1);

                }
            }
            return i;
        }
    }
}
