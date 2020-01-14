using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PanelLoginMenu:View
    {
        [SerializeField] private Button login;
        [SerializeField] private Button forgotPassword;
        [SerializeField] private Button signUp;
        [SerializeField] private InputField email;
        [SerializeField] private InputField password;

        protected override void SubscribeEvents(){
            signUp.onClick.AddListener(OpenPanelPersonalInformation);
            login.onClick.AddListener(CheckPasswordAndEmail);
        }

        protected override void UnSubscribeEvents(){
            signUp.onClick.RemoveAllListeners();
            login.onClick.RemoveAllListeners();
        }

        private void CheckPasswordAndEmail(){
            string stringEmail = string.Intern(email.text);
            string stringPassword = string.Intern(password.text);
            if (stringEmail.Length != 0 && stringPassword.Length != 0){
               GetEmailAndPassword(stringEmail,stringPassword);
            }
            else{
                OpenPanelPersonalInformation();
            }
        }

        private void GetEmailAndPassword(string email,string password){
            uiManager.LoginButtonClicked(email,password);
        }
    }
}