// 1. Generic

//interface Generic<T>
//{
//    public T Get(int num);
//}

//class GetDouble : Generic<double>
//{
//    List<double> list;
//    public double Get(int num)
//    {
//        return list.First(x => x < num);
//    }
//}


//List<int> ints = new List<int> { 1,2,3 };

//ints.Where(IsGeraterThanTwo).ToList();
//ints.Where(i=> i >2).ToList();


//bool IsGeraterThanTwo(int i)
//{
//    return i > 2;
//}
//delegate void MyDelaget(int first, int second);


// 2. Delagete

//MyDelegate del = (int first, int second) =>
//{
//    Console.WriteLine($"Arguments are {first} and {second}");
//};

//del(2,3);

//del = PrintIntsBackwards;

//del(10, 11);

//void PrintIntsBackwards(int first, int second)
//{
//    Console.Write($"{second} comes before {first}");
//}


//-- Excercise --

//MyDelegate del = (int first, int second) =>
//{
//    return first + second;
//};
//MyDelegate del = add;
//Console.WriteLine(del(3, 3));

//del = subtract;
//Console.WriteLine(del(9, 2));

//del= (int first,int second) =>
//{
//    return first / second;
//};
//Console.WriteLine(del(9, 3));


//int add(int first, int second)
//{
//    return first + second;
//}
//int subtract(int first, int second)
//{
//    return first - second;
//}
//int divide(int first, int second)
//{
//    return first / second;
//}
//delegate int MyDelegate(int first, int second);

//Func<int, int, int> randInt = (n1, n2) => new Random().Next(n1, n2);
//Console.WriteLine(randInt(1, 100));

//IntChildClass instance = new IntChildClass();
//instance.intList = new List<int> { 4,5,6,7 };

//Console.WriteLine(instance.Get(i => i > 5));

//Console.WriteLine(instance.GetList(i => i % 2 == 0).Count);
//Console.WriteLine(instance.GetList(i => i % 2 != 0).Count);

StringChildClass stringInstance = new StringChildClass();
stringInstance.stringList = new List<string>{
    "a",
    "ab",
    "abc",
    "ccc"
};
Console.WriteLine(stringInstance.Get(s=>s.Contains('c')));
Console.WriteLine(stringInstance.GetList(s => s.Length >= 2).Count());
public interface IGenerictest<T>
{
    
    void Add(T entity);

    T Get(Func<T, bool> whereFunction);

    ICollection<T> GetList(Func<T,bool> whereFunction);
}

public class StringChildClass : IGenerictest<string>
{
    public List<string> stringList { get; set; }
    public void Add(string entity)
    {
        stringList.Add(entity);
    }
    public string Get(Func<string, bool> func)
    {
        return stringList.Where(func).First();
    }
    public ICollection<string> GetList(Func<string, bool> func)
    {
        return stringList.Where(func).ToList();
    }
}

public class IntChildClass : IGenerictest<int>
{
    public List<int> intList { get; set; }
    public void Add(int entity)
    {
        intList.Add(entity);
    }

    public int Get(Func<int, bool> whereFunction)
    {
        return intList.Where(whereFunction).First();
    }

    public ICollection<int> GetList(Func<int, bool> func)
    {
        return intList.Where(func).ToList();
    }

}


