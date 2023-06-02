using CtrlLove.Models;
using CtrlLove.Service;

namespace CtrlLove.DAL;

public class UserRepository : IRepository<UserModel, Guid>
{
    private List<UserModel> _users = new List<UserModel>();

    public UserRepository()
    {
        seedUsers();
    }

    private void seedUsers()
    {
        Random random = new Random();
        string[] FirstNames = { "Tom", "Sarah", "Emma", "Robb", "Lisa" };
        string[] LastNames = { "Smith", "Jones", "Big", "White", "Rodriguez" };
        Gender[] genders = Enum.GetValues<Gender>();
        
        DateTime start = new DateTime(1965, 1, 1);
        int range = (new DateTime(2005, 6, 2) - start).Days;



        for (int i = 0; i<20; i++)
        {
            string name = FirstNames[random.Next(FirstNames.Length)] + " " + LastNames[random.Next(LastNames.Length)];
            Gender gender = genders[random.Next(genders.Length)];
            DateTime randomBirthDate =  start.AddDays(random.Next(range));
            
            _users.Add(new UserModel(
                    name,
                    "xxx", 
                    "admin",
                    new HashSet<Guid>(),
                    new HashSet<Guid>(), 
                    "i like food", 
                    randomBirthDate,
                    DateTime.Now, 
                    "bp",
                    gender, 
                    new HashSet<Gender>() { genders[random.Next(genders.Length)] },
                new HashSet<string>(){"https://w7.pngwing.com/pngs/345/350/png-transparent-spider-man-drawing-internet-meme-know-your-meme-spiderman-comics-leaf-hand-thumbnail.png"},
                new HashSet<string>(){"Party", "Coding", "Sports"}
            ));
        }
    }

    public List<UserModel> GetAll()
    {
        return _users;
    }

    public UserModel? GetElementById(Guid id)
    {
        return _users.FirstOrDefault(user => user.Id.Equals(id));
    }

    public bool AddNewElement(UserModel user)
    {
         _users.Add(user);
         return _users.Contains(user);
    }

    public bool DeleteElement(UserModel user)
    {
        return _users.Remove(user);
    }

    public bool UpdateElement(object old, object updated)
    {
        throw new NotImplementedException();
    }
}