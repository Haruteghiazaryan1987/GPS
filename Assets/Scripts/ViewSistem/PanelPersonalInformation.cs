using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PanelPersonalInformation:View
    {
        [SerializeField] private Button continueButton;
        [SerializeField] private InputField firstName;
        [SerializeField] private InputField lastName;
        [SerializeField] private InputField phoneNumber;
        [SerializeField] private InputField email;
        [SerializeField] private InputField day;
        [SerializeField] private InputField month;
        [SerializeField] private InputField year;

        protected override void SubscribeEvents(){
            continueButton.onClick.AddListener(OpenPanelMap);
        }

        protected override void UnSubscribeEvents(){
            continueButton.onClick.RemoveListener(OpenPanelMap);
        }
    }
}