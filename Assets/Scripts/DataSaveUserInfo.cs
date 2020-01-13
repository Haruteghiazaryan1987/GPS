using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace DefaultNamespace
{
    public class DataSaveUserInfo
    {
        private string fileName="SaveUser.json";
        public List<UserInfo> UserInfoList{ get; private set; }

        public DataSaveUserInfo(){
            UserInfoList=new List<UserInfo>();
        }
        public void Save(){
            string directoryPath = Path.Combine(Application.dataPath, "Json");
            if (!Directory.Exists(directoryPath)){
                DirectoryInfo di = Directory.CreateDirectory(directoryPath);
            }
                
            string path = Path.Combine(directoryPath, fileName);
            string json = JsonConvert.SerializeObject(UserInfoList);
            File.AppendAllText(path,json);
        }
    }
}