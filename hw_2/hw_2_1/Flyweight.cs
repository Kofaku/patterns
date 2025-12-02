
namespace hw2_1
{
    class TreeType
    {
        public string Name { get; }
        public string Color { get; }
        public string Texture { get; }
        public TreeType(string name, string color, string texture)
        {
            Name = name; Color = color; Texture = texture;
        }
        public void Draw(int x, int y)
        {
            Console.WriteLine($"Рисую дерево '{Name}' ({Color}) на позиции ({x},{y})");
        }
    }

    class TreeFactory
    {
        private static Dictionary<string, TreeType> _cache = new Dictionary<string, TreeType>();
        public static TreeType GetTreeType(string name, string color, string texture)
        {
            string key = $"{name}_{color}_{texture}";
            if (!_cache.ContainsKey(key))
            {
                _cache[key] = new TreeType(name, color, texture);
                Console.WriteLine($"Создаю НОВЫЙ тип дерева: {key}");
            }
            return _cache[key];
        }
    }

    class Tree
    {
        private int _x, _y;
        private TreeType _type;
        public Tree(int x, int y, TreeType type)
        {
            _x = x; _y = y; _type = type;
        }
        public void Draw()
        {
            _type.Draw(_x, _y);
        }
    }
}