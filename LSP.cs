//LSP Violation (Bad example)
public class File {
   public virtual string Read() {
    Console.WriteLine("Reading from the file");
    return "Content of File";
   }

   public virtual void Write(string text) {
    Console.WriteLine($"Writing {text} to the file");
   }
}

public class ReadOnlyFile : File {
    public override string Read() {
        Console.WriteLine("Reading from a read only file");
        return " Content of readonly file";
    }

    public override void Write(string text) {
        throw new InvalidOperationException("cannot write to a read only file");
    }
}

//LSP adherence (Good example)
public abstract class Readable
{
    public abstract string Read();
}

public abstract class Writable : Readable
{
    public abstract void Write(string text);
}

public class TextFile : Writable
{
    public override void Write(string text)
    {
        Console.WriteLine($"Writing '{text}' to text file.");
    }

    public override string Read()
    {
        Console.WriteLine("Reading from text file.");
        return "Text file content";
    }
}

public class ReadOnlyTextFile : Readable
{
    public override string Read()
    {
        Console.WriteLine("Reading from read-only text file.");
        return "Read-only text file content";
    }
}