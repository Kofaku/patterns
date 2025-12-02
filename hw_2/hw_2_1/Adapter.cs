namespace hw2_1
{
    class OldClass
    {
        public void OldMethod()
        {
            Console.WriteLine("Древний метод выполнен");
        }
    }

    interface IModernInterface
    {
        void Start();
    }

    class SomeAdapter : IModernInterface
    {
        private OldClass _oldClass;
        public SomeAdapter(OldClass oldclass)
        {
            _oldClass = oldclass;
        }

        public void Start()
        {
            _oldClass.OldMethod();
        }
    }
}