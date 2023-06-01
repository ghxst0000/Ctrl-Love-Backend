using CtrlLove.Models;
using CtrlLove.Service;

namespace CtrlLove.DAL;

public class UserRepository : IUserRepository
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
        
        
        
        for (int i = 0; i<20; i++)
        {
            string name = FirstNames[random.Next(FirstNames.Length)] + " " + LastNames[random.Next(LastNames.Length)];
            Gender gender = genders[random.Next(genders.Length)];
            _users.Add(new UserModel(
                    new Guid(),
                    name,
                    "xxx", 
                    "admin",
                    new HashSet<Guid>(),
                    new HashSet<Guid>(), 
                    "i like food", 
                    (byte)random.Next(18, 50),
                    DateTime.Now, 
                    "bp",
                    gender, 
                    new HashSet<Gender>() { genders[random.Next(genders.Length)] },
                    new HashSet<string>(),
                    new HashSet<string>()
                    ));
        }
    }

    public List<UserModel> GetAll()
    {
        return _users;
    }

    public UserModel GetUserById(string id)
    {
        throw new NotImplementedException();
    }

    public List<UserModel> GetMatchesByUser(string userId)
    {
        throw new NotImplementedException();
    }
}