namespace Semestralna_Praca1
{
    public class DataGenAndTest
    {
        public void CreateRealEstateTree()
        {
            Random rand = new Random();
            RealEstate root = new RealEstate();
            root.X = rand.NextDouble();
            root.Y = rand.NextDouble();
            Node<RealEstate> nodeRoot = new Node<RealEstate>(root);
            nodeRoot.Data.X = root.X;
            nodeRoot.Data.Y = root.Y;
            KDTree<RealEstate> tree = new KDTree<RealEstate>(nodeRoot);
            for (int i = 0; i < 10; i++) 
            {
                RealEstate estate = new RealEstate();
                estate.X = rand.NextDouble();
                estate.Y = rand.NextDouble();
                Node<RealEstate> node = new Node<RealEstate>(estate);
                node.Data.X = estate.X;
                node.Data.Y = estate.Y;
                tree.Insert(node);
            }
        }
    }
}
