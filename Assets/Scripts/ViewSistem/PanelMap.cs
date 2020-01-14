using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PanelMap:View
    {
        [SerializeField] private Button search;
        [SerializeField] private Button mainMenu;
        [SerializeField] private Button update;

        protected override void SubscribeEvents(){
            mainMenu.onClick.AddListener(OpenPanelMenu);
            search.onClick.AddListener(OnButtonSearch);
            update.onClick.AddListener(OnButtonUpdate);
        }

        private void OnButtonUpdate(){
            uiManager.ButtonUpdateClick();
        }

        private void OnButtonSearch(){
            uiManager.ButtonSearchClick();
        }

        protected override void UnSubscribeEvents(){
            mainMenu.onClick.RemoveAllListeners();
            search.onClick.RemoveAllListeners();
            update.onClick.RemoveAllListeners();
        }
    }
}