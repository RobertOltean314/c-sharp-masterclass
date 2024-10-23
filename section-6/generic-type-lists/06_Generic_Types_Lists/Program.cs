var numbers = new SimpleList<int>();
var words = new SimpleList<string>();
var dates = new SimpleList<DateTime>();
numbers.Add(1);
numbers.Add(2);
numbers.Add(3);
numbers.Add(4);
numbers.Add(5);

words.Add("aaa");
words.Add("bbb");
words.Add("ccc");
words.Add("ddd");
words.Add("eee");

dates.Add(DateTime.Now);
dates.Add(DateTime.Now.AddDays(1));
dates.Add(DateTime.Now.AddDays(2));
dates.Add(DateTime.Now.AddDays(3));
dates.Add(DateTime.Now.AddDays(4));

numbers.RemoveAt(2);
Console.WriteLine(numbers.ToString());
Console.WriteLine(words.ToString());
Console.WriteLine(dates.ToString());

Console.ReadKey();

class SimpleList<T>
{
    private T[] _items = new T[4];
    private int _size = 0;

    public void Add(T item)
    {
        if (_size >= _items.Length)
        {
            var newItems = new T[_items.Length * 2];

            for (int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }
            _items = newItems;
        }

        _items[_size] = item;
        _size++;
    }
    public string ToString()
    {
        var result = "";
        for (int i = 0; i < _size; i++)
        {
            result += _items[i] + " ";
        }
        return result;
    }
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _size)
        {
            throw new IndexOutOfRangeException($"Index {index} is out of bounds of the list");
        }
        --_size;
        for (int i = index; i < _size; i++)
        {
            _items[i] = _items[i + 1];
        }
        _items[_size] = default;
    }

    public T GetAtIndex(int index)
    {
        if (index < 0 || index >= _size)
        {
            throw new IndexOutOfRangeException($"Index {index} is out of bounds of the list");
        }
        return _items[index];
    }
}