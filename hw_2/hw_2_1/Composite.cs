namespace hw2_1
{
    interface IProduct
    {
        double GetPrice();
    }

    class SingleProduct : IProduct
    {
        private double _price;
        public SingleProduct(double price) { _price = price; }
        public double GetPrice() => _price;
    }

    class BoxOfProducts : IProduct
    {
        private List<IProduct> _children = new List<IProduct>();
        public void Add(IProduct product) { _children.Add(product); }
        public double GetPrice()
        {
            double total = 0;
            foreach (var child in _children)
            {
                total += child.GetPrice();
            }
            return total;
        }
    }
}