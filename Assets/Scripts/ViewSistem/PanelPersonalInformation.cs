using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PanelPersonalInformation:View
    {
        [SerializeField] private Button continueButton;
        [SerializeField] private InputField firstName;
        [SerializeField] private InputField lastName;
        [SerializeField] private InputField email;
        [SerializeField] private InputField password;
        [SerializeField] private InputField day;
        [SerializeField] private InputField month;
        [SerializeField] private InputField year;

        private UserInfo userInfo;

        protected override void SubscribeEvents(){
            continueButton.onClick.AddListener(AddInputField);
        }

        private void AddInputField(){
            if (string.Intern(email.text).Length != 0 && string.Intern(password.text).Length != 0){
                userInfo=new UserInfo(string.Intern(email.text),string.Intern(password.text));
                uiManager.GetNewUser(userInfo);
                OpenPanelMap();
            }
            else{
                IncorrectPasswordOrEmail();
            }
        }

        private void IncorrectPasswordOrEmail(){
            Debug.Log("Incorrect password or mail");
        }

        protected override void UnSubscribeEvents(){
            continueButton.onClick.RemoveAllListeners();
        }
    }

    public struct UserInfo
    {
        public string Email{ get;  set; }
        public string Password{ get;  set; }

        public UserInfo(string email, string password){
            Email = email;
            Password = password;
        }
    }
}