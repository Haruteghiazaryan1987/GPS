using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace DefaultNamespace
{
    public class DataSaveUserInfo
    {
        private string fileName="SaveUser.json";
        readonly string directoryPath;
        private string path;
        public List<UserInfo> UserInfoList{ get; private set; }

        public DataSaveUserInfo(){
            UserInfoList=new List<UserInfo>();
            directoryPath = Path.Combine(Application.dataPath, "Json");
            path=Path.Combine(directoryPath, fileName);
            if (!Directory.Exists(directoryPath)){
                DirectoryInfo di = Directory.CreateDirectory(directoryPath);
            }
        }
        public void Save(){
            string json = JsonConvert.SerializeObject(UserInfoList);
            File.WriteAllText(path,json);
        }

        public List<UserInfo> Load(){
            if (!File.Exists(path)){
                return null;
            }
            string json = File.ReadAllText(path);
            UserInfoList = JsonConvert.DeserializeObject<List<UserInfo>>(json);
            if (UserInfoList == null){
                UserInfoList=new List<UserInfo>();
            }

            return UserInfoList;
        }
    }
}