namespace Patterns
{
    public class Cat
    {
        public int Age;
        public string Color;
        public string Name;
        public IdInfo IdInfo;

        public Cat ShallowCopy()
        {
            return (Cat)this.MemberwiseClone();
        }

        public Cat DeepCopy()
        {
            Cat clone = (Cat)this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            return clone;
        }

        public void SetValues (int age, string color, string name)
        {
            this.Age = age;
            this.Color = color;
            this.Name = name;
        }
    }

    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }

}