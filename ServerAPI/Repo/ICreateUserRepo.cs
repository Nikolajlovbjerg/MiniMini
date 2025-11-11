using Core;

namespace ServerAPI.Repo
{
    public interface ICreateUserRepo
    {
        List<User> GetAll();
        void Add(User user);
    }
}
