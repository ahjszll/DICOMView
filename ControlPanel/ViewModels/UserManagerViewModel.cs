using System.Collections.Generic;

namespace ControlPanel.ViewModels
{
    public class UserManagerViewModel : ViewModelBase
    {
        public string Title => "用户管理";

        public List<UserView> Users { get; set; } = new List<UserView>() { new UserView (),new UserView () };
    }

    public class UserView: ViewModelBase
    {
        public string Name { get; set; } = "123";

        public string RealName { get; set; } = "321";
    }
}
