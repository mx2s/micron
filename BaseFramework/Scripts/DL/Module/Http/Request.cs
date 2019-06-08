using BaseFramework.Scripts.DL.Model.User;

namespace BaseFramework.Scripts.DL.Module.Http {
    public class Request {
        private User _user = null;

        public Request() {
            
        }
        
        public User GetUser() => _user;
    }
}