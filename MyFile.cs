using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
   public abstract class MyFile : IFileAttributes, IComparable
    {
        readonly string _FilePath;
        public string FilePath { get; }

        static List<string> paths = new List<string>();

        protected MyFile(string filePath)
        {
            this.FilePath = filePath;
        }
        public MyFile()
        {

        }
        const bool FileSupport = true;
        public abstract void PrintFile();

        public int CompareTo(object obj)
        {
            MyFile newFile = obj as MyFile;
            return (this.FileSize - newFile.FileSize);
        }

        public int FileSize { get; private set; }
        public bool IsReadOnly{ get; private set; }
        public bool IsArchive { get; private set; }
        public bool IsInfected { get; private set; }

        public MyFile(string FilePath, int fileSize, bool isReadOnly, bool isArchive) : this(FilePath)
        {
            FileSize = fileSize;
            IsReadOnly = isReadOnly;
            IsArchive = isArchive;

            IsInfected = VirusScanner.IsFileInfected(this);
        }
        public static bool operator ==(MyFile x, MyFile y)
        {
            if (ReferenceEquals(x,null) && (ReferenceEquals(y, null)))
            {
                return true;
            }
            if (ReferenceEquals(x,null) || (ReferenceEquals(y, null)))
            {
                return false;
            }
            if (x.FilePath == y.FilePath)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(MyFile x, MyFile y)
        {
            return !(x == y);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is MyFile == false)
                return false;

            MyFile otherFile = obj as MyFile;

            return (this.FilePath == otherFile.FilePath);

        }
    }
    public class CompareAsFilePath : IComparer<MyFile>
    {
      public int Compare(MyFile x, MyFile y)
        {
            return x.FilePath.CompareTo (y.FilePath);
        }
    }
    
}
