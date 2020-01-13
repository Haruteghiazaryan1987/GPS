using System;
using System.Collections.Generic;
using System.Linq;
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
    

    private void Awake(){
        greenImage = Instantiate(imageGreen, panelMap);
        greenImage.SetActive(false);
        uiManager.Setup(this);
        uiManager.OnSearchButtonClicked += SearchButtonClicked;
        uiManager.OnUpdateButtonClicked += UpdateButtonClicked;
        uiManager.OnViewPanelMap += UpdateButtonClicked;
        AddUser();
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
