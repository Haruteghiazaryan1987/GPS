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
    List<UserInfo> userList=new List<UserInfo>();
    private GameObject greenImage;

    private DataSaveUserInfo dataSaveUserInfo;
    private List<UserInfo> userInfo;
    private bool userAdded;

    private void Awake(){
        greenImage = Instantiate(imageGreen, panelMap);
        greenImage.SetActive(false);
        uiManager.Setup(this);
        uiManager.OnSearchButtonClicked += SearchButtonClicked;
        uiManager.OnUpdateButtonClicked += UpdateButtonClicked;
        uiManager.OnViewPanelMap += UpdateButtonClicked;
        uiManager.AddNewUser += SaveNewUser;
        uiManager.OnLoginButtonClicked += UserVerification;
        
        dataSaveUserInfo=new DataSaveUserInfo();
    }

    private void UserVerification(string email, string password){
        userInfo=dataSaveUserInfo.Load();
        if (userInfo != null && CheckForAccountAvailability(email, password, userInfo)){
            AddUser();
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
        userAdded = true;
        for (int i = userInfo.Count-4; i < userInfo.Count; i++){
            UserInfo user=new UserInfo(userInfo[i].Email,userInfo[i].Password,Instantiate(imageRed,panelMap));
            user.UserImage.transform.localPosition=new Vector2(50 * Random.Range(-10, 11),50 * Random.Range(-15, 19));
            userList.Add(user);
        }
    }

    private void UpdateButtonClicked(){
        if (!userAdded){
            AddUser();
        }
        greenImage.SetActive(false);
        userList[0].UserImage.SetActive(true);
        for (int i = 0; i < userList.Count; i++){
            userList[i].UserImage.transform.localPosition=new Vector2(50 * Random.Range(-10, 11),50 * Random.Range(-15, 19));
        }
    }

    private void SearchButtonClicked(){
        var sortedList = userList.OrderBy(x => (x.UserImage.transform.localPosition - myPosition.localPosition).magnitude)
            .ToList();
        userList = sortedList;
        greenImage.SetActive(true);
        greenImage.transform.localPosition = userList[0].UserImage.transform.localPosition;
        userList[0].UserImage.gameObject.SetActive(false);
    }
}
