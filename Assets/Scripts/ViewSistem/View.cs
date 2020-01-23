using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public abstract class View:MonoBehaviour
    {
        protected UIManager uiManager;
        protected virtual void SubscribeEvents(){
        }
        protected virtual void UnSubscribeEvents(){
        }
        protected virtual void OnEnable(){
            SubscribeEvents();
        }

        protected virtual void OnDisable(){
            UnSubscribeEvents();
        }

        public void Setup(UIManager uIManager){
            uiManager=uIManager;
        }

        public void HideView(){
            gameObject.SetActive(false);
        }

        public void ShowView(){
            gameObject.SetActive(true);
        }

        protected void OpenPanelMap(){
            uiManager.ViewPanelMap();
        }
        protected void OpenPanelPersonalInformation(){
            uiManager.ViewPanelPersonalInformation();
        }

        protected void OpenPanelMenu(){
            uiManager.ViewPanelLoginMenu();
        }
        protected void ResetInputField( List<InputField> inputFields){
            for (int i = 0; i < inputFields.Count; i++){
                if (string.Intern(inputFields[i].text).Length != 0){
                    inputFields[i].text = "";
                }
            }
        }
    }
}