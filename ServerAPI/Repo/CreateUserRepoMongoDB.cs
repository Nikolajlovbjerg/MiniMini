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
            var max = 0;
            if (cUser.CountDocuments(Builders<User>.Filter.Empty) > 0)
            {
                max = MaxId();
            }
            user.Id = max + 1;
            cUser.InsertOne(user);
        }

        private int MaxId() => GetAll().Select(x => x.Id).Max();

    }


}
