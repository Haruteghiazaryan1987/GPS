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
            signUp.onClick.RemoveListener(OpenPanelPersonalInformation);
            login.onClick.RemoveListener(OpenPanelMap);
        }

        private void CheckPasswordAndEmail(){
            if (string.Intern(email.text).Length != 0 && string.Intern(password.text).Length != 0){
                OpenPanelMap();
            }
            else{
                OpenPanelPersonalInformation();
            }
        }
    }
}