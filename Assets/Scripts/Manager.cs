using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

public class Manager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private RectTransform panelMap;
    [SerializeField] private RectTransform myPosition;
    [SerializeField] private GameObject imageRed;
    [SerializeField] private GameObject imageGreen;
    List<GameObject> userList=new List<GameObject>();
    private GameObject greenImage;

    private DataSaveUserInfo dataSaveUserInfo;
    private List<UserInfo> userInfo;

    private void Awake(){
        greenImage = Instantiate(imageGreen, panelMap);
        greenImage.SetActive(false);
        uiManager.Setup(this);
        uiManager.OnSearchButtonClicked += SearchButtonClicked;
        uiManager.OnUpdateButtonClicked += UpdateButtonClicked;
        uiManager.OnViewPanelMap += UpdateButtonClicked;
        uiManager.AddNewUser += SaveNewUser;
        uiManager.OnLoginButtonClicked += UserVerification;
        AddUser();
        dataSaveUserInfo=new DataSaveUserInfo();
    }

    private void UserVerification(string email, string password){
        userInfo=dataSaveUserInfo.Load();
        if (userInfo != null && CheckForAccountAvailability(email, password, userInfo)){
            uiManager.ViewPanelMap();
        }
        else{
            uiManager.ViewPanelPersonalInformation();
        }
    }

    private bool CheckForAccountAvailability(string email, string password, List<UserInfo> list){
        bool accountIs = false;
       
        for (int i = 0; i < list.Count ; i++){
            if (list[i].Email == email && list[i].Password == password){
                accountIs = true;
                break;
            }
        }
        return accountIs;
    }

    private void SaveNewUser(UserInfo userInfo){
        dataSaveUserInfo.UserInfoList.Add(userInfo);
        dataSaveUserInfo.Save();
    }

    private void AddUser(){
        for (int i = 0; i < 4; i++){
            GameObject go=Instantiate(imageRed, panelMap);
            go.transform.localPosition=new Vector2(50 * Random.Range(-10, 11),50 * Random.Range(-15, 19));
            userList.Add(go);
        }
    }

    private void UpdateButtonClicked(){
        greenImage.SetActive(false);
        userList[0].SetActive(true);
        for (int i = 0; i < userList.Count; i++){
            userList[i].transform.localPosition=new Vector2(50 * Random.Range(-10, 11),50 * Random.Range(-15, 19));
        }
    }

    private void SearchButtonClicked(){
        var sortedList = userList.OrderBy(x => (x.transform.localPosition - myPosition.localPosition).magnitude)
            .ToList();
        userList = sortedList;
        greenImage.SetActive(true);
        greenImage.transform.localPosition = userList[0].transform.localPosition;
        userList[0].gameObject.SetActive(false);
    }
}
