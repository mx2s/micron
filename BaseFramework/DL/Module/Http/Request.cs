using BaseFramework.DL.Model.User;

namespace BaseFramework.DL.Module.Http {
    public class Request {
        private User _user = null;

        public User GetUser() => _user;
    }
}