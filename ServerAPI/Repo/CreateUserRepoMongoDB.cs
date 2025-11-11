using Core;
using Microsoft.VisualBasic;
using MongoDB.Driver;

namespace ServerAPI.Repo
{
    private IMongoCollection<User> users;
    public class CreateUserRepoMongoDB
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("minimini");
        user = database.GetCollection<User>("bruger");
    };

    public void Add(User user)
        {
            var max = 0;
            if (user.CountDocument(Builders<User>.Filter.Empty) > 0)
            {
                max = MaxId();
            }
            user.Id = max + 1;
            users.InsertOne(user);
        }
    } }
