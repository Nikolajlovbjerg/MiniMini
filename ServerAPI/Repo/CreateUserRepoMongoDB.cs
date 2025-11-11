using Core;
using Microsoft.VisualBasic;
using MongoDB.Driver;
using ZstdSharp.Unsafe;

namespace ServerAPI.Repo
{

    public class CreateUserRepoMongoDB : ICreateUserRepo
    {
        private readonly IMongoCollection<User> cUser;

        public CreateUserRepoMongoDB()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("minimini");
            cUser = database.GetCollection<User>("bruger");
        }

        public List<User> GetAll()
        {
            return cUser.Find(_  => true).ToList();
        }

        public void Add(User user)
        {
            user.Id = new Random().Next(1, int.MaxValue);
            cUser.InsertOne(user);
        }

    }


}
