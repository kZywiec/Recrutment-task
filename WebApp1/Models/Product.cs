namespace WebApp1.Models
{
    public class Product
    {
        int id;
        string name;

        public List<Campany> companies_List = new List<Campany> { };

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }

        public Product(int id, string name)
            => (Id, Name) = (id, name);

        ////List operations
        //void AddCompany(Campany company)
        //    => companies_List.Add(company);

        //void RemoveCompany(Campany company)
        //    => companies_List.Remove(company);

        //void RemoveCompany(int id)
        //    => companies_List.Remove(companies_List.Single(c => c.Id == id));

        //Campany CompanyById(int id)
        //    => companies_List.Single(c => c.Id == id);
    }
}
