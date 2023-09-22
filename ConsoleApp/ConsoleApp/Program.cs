// See https://aka.ms/new-console-template for more information
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace model
{
    class program
    {
        private static string connectionstring = "AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";


        private static CosmosClient client = new CosmosClient(connectionstring);
        private static Database database = null;
        private static Microsoft.Azure.Cosmos.Container container = null;
        private static string Id;
        static async Task Main(string[] args)
        {
            database = client.GetDatabase("capital");
            container = database.GetContainer("capital");


            Console.WriteLine("Adding Item....");
            //Console.WriteLine("Updating Item....");
            //Console.WriteLine("Deleting Item....");
            await CreateProgramdetails();
            Console.WriteLine(Id);
            await Updatepersonal();

            //Console.WriteLine("Getting Items....");

            //await GetAppsAsync();
        }

        static async Task GetAppsAsync()
        {
            string query = "SELECT * FROM " + Id;

            var appsIterator = container.GetItemQueryIterator<programDetails>(query);

            var programDetails = await appsIterator.ReadNextAsync();

            foreach (var detail in programDetails)
            {
                Console.WriteLine($"{detail.id}\n");
                Console.WriteLine($"{detail.programtitle}\n {detail.description}\n {detail.benefits}\n {detail.summary}\n {detail.skills}\n {detail.criteria}\n ");
            }

        }
        static async Task Updatepersonal()
        { 
            
            Console.WriteLine("Enter Program Title\n");
            string title = Console.ReadLine();
            Console.WriteLine("Enter Program summary\n");
            String summary = Console.ReadLine();
            Console.WriteLine("Enter Program Description\n");
            String desc = Console.ReadLine();
            Console.WriteLine("Enter Key Skills\n");
            String skills = Console.ReadLine();
            Console.WriteLine("Enter program benfits\n");
            String benfit = Console.ReadLine();
            Console.WriteLine("Enter application criteria\n");
            String criteria = Console.ReadLine();
            Console.WriteLine("\t---Additional Information----");
            Console.WriteLine("Program Type");
            string progtype = Console.ReadLine();
            Console.WriteLine("Program Start Date: DD/MM/YYYY");
            DateOnly dates = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Application start date: DD/MM/YYYY");
            DateOnly appdate = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Application end date: DD/MM/YYYY");
            DateOnly appclose = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Duration in months\n");
            string dur = Console.ReadLine();
            Console.WriteLine("Program location\n");
            string loc = Console.ReadLine();
            Console.WriteLine("Minimum Qualifications\n");
            string qualif = Console.ReadLine();
            Console.WriteLine("Maximum number of applications\n");
            int app = int.Parse(Console.ReadLine());
                Console.WriteLine("FirstName\n");
                string finame = Console.ReadLine();
                Console.WriteLine("LastName\n");
                string laname = Console.ReadLine();
                Console.WriteLine("Email\n");
                string email = Console.ReadLine();
                Console.WriteLine("Nationality\n");
                string nation = Console.ReadLine();
                Console.WriteLine("Phone");
                string phone = Console.ReadLine();
                Console.WriteLine("Current residence\n");
                string address = Console.ReadLine();
                Console.WriteLine("ID number\n");
                string city = Console.ReadLine();
                Console.WriteLine("Date of Birth:DD/MM/YYY\n");
                DateOnly date = DateOnly.Parse(Console.ReadLine());
                Console.WriteLine("Gender\n");
                string gen = Console.ReadLine();
                var per = new programDetails
            {
                id = Guid.NewGuid().ToString(),
                programtitle = title,
                benefits = benfit,
                criteria = criteria,
                description = desc,
                skills = skills,
                summary = summary,
                programtype = progtype,
                Programstart = dates,
                Applicationstart = appdate,
                Applicationend = appclose,
                applications = app,
                duration = dur,
                location = loc,
                qualifications = qualif,
                fname = finame,
                lname = laname,
                dateofbirth = date,
                nation = nation,
                Mobile = phone,
                Email = email,
                gender = gen,
                 Identity= city,
                residence = address
            };
            var result=await container.CreateItemAsync(per);
            Console.Write(result.StatusCode.ToString());
        }
       

        public class programDetails
        {
            [Key]
            public string id { get; set; }

            [JsonProperty("Program Title")]
            public string programtitle { get; set; }
            [JsonProperty("Program Summary")]
            public string summary { get; set; }

            [JsonProperty("Program Description")]
            public string description { get; set; }
            [JsonProperty("Key Skills")]
            public string skills { get; set; }

            [JsonProperty("Program Benefits")]

            public string benefits { get; set; }

            [JsonProperty("Application Criteria")]
            public string criteria { get; set; }

            [JsonProperty("Program Type")]
            public string programtype { get; set; }

            [JsonProperty("Program Start")]
            public DateOnly Programstart { get; set; }

            [JsonProperty("Application Start")]
            public DateOnly Applicationstart { get; set; }

            [JsonProperty("Application End")]
            public DateOnly Applicationend { get; set; }

            [JsonProperty("Duration")]
            public string duration { get; set; }

            [JsonProperty("Program Location")]
            public string location { get; set; }

            [JsonProperty("Min Qualifications")]
            public string qualifications { get; set; }

            [JsonProperty("Max num of applications")]
            public int applications { get; set; }

            [JsonProperty("First Name")]
            public string fname { get; set; }
            [JsonProperty(" Last Name")]
            public string lname { get; set; }
            [JsonProperty("Email")]
            public string Email { get; set; }

            [JsonProperty("Phone")]
            public string Mobile { get; set; }
            [JsonProperty("Nationality")]
            public string nation { get; set; }
            [JsonProperty("Current Residence")]
            public string residence { get; set; }
            [JsonProperty("ID number")]
            public string Identity { get; set; }
            [JsonProperty("Date of Birth")]
            public DateOnly dateofbirth { get; set; }
            [JsonProperty("Gender")]
            public string gender { get; set; }
        }
    }
        
}