using Avalonia;
using FluentAvalonia.UI.Controls;
using ReactiveUI;
using System.ComponentModel.DataAnnotations;

namespace ControlPanel.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _loginMsg = "";
        public string LoginMsg
        {
            get => _loginMsg;
            set => this.RaiseAndSetIfChanged(ref _loginMsg, value);
        }

        private string _name = "admin";
        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

        private string _pwd = "admin";
        public string Pwd
        {
            get => _pwd;
            set => this.RaiseAndSetIfChanged(ref _pwd, value);
        }

        public LoginViewModel(ContentDialog dialog)
        {
            dialog.PrimaryButtonText = "登录";
            dialog.CloseButtonText = "退出";
            dialog.PrimaryButtonClick += Dialog_PrimaryButtonClick;
        }

        private void Dialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (Name == "admin" && Pwd == "admin")
            {
                LoginMsg = "";
            }
            else
            {
                LoginMsg = "账号密码错误";
                args.Cancel = true;
            }
        }
    }
}
