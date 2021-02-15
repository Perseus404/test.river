namespace TestingAssessment.Steps.Models
{
    public class User
    {
        public User(int id, string name, string username, string email, string street, 
            string suite, string city, string zipcode, string lat, string lng, 
            string phone, string website, string companyName, 
            string catchPhrase, string bs)
        {
            Id = id;
            Name = name;
            Username = username;
            Email = email;
            Street = street;
            Suite = suite;
            City = city;
            Zipcode = zipcode;
            Lat = lat;
            Lng = lng;
            Phone = phone;
            Website = website;
            CompanyName = companyName;
            CatchPhrase = catchPhrase;
            Bs = bs;
        }

        public int Id { get; }
        public string Name { get; }
        public string Username { get; }
        public string Email { get; }
        public string Street { get; }
        public string Suite { get; }
        public string City { get; }
        public string Zipcode { get; }
        public string Lat { get; }
        public string Lng { get; }
        public string Phone { get; }
        public string Website { get; }
        public string CompanyName { get; }
        public string CatchPhrase { get; }
        public string Bs { get; }
    }
}
