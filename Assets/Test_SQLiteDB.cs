using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System.IO;
using System.Data;
using UnityEngine.Networking;
using System;

public class Test_SQLiteDB : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        //StartCoroutine(DBCreate());
    }

    // Update is called once per frame
    void Start()
    {
        //DBConnectionCheck();
        //DataService data = new DataService("/Test.db");

        //data.CreatePerson();
        //ToConsole("New person has been created");
        //var p = data.GetJohnny();
        //ToConsole(p.ToString());
    }
    public IEnumerator DBCreate()
    {
        string path = string.Empty;

        if(Application.platform == RuntimePlatform.Android)
        {
            path = Application.persistentDataPath + "/Test.db";
            if(!File.Exists(path))
            {
                UnityWebRequest unityWebRequest = UnityWebRequest.Get("jar:file://" + Application.dataPath + "!assets/Test.db");
                unityWebRequest.downloadedBytes.ToString();
                yield return unityWebRequest.SendWebRequest().isDone;
                File.WriteAllBytes(path, unityWebRequest.downloadHandler.data);
                Debug.Log("파일 생성 완료");
            }
            else
            {
                Debug.Log("파일 이미 존재");
            }
        }
        else
        {
            path = Application.dataPath + "/Test.db";
            if(!File.Exists(path))
            {
                File.Copy(Application.streamingAssetsPath + "/Test.db", path);
                Debug.Log("파일 생성 완료");
            }
            else
            {
                Debug.Log("파일 이미 존재");
            }
        }
    }
    public string GetDBFilePath()
    {
        string str = string.Empty;
        if(Application.platform == RuntimePlatform.Android)
        {
            str = "URI=file:" + Application.persistentDataPath + "/Test.db";
        }
        else
        {
            str = "URI=file:" + Application.dataPath + "/Test.db";
        }
        return str;
    }
    public void DBConnectionCheck()
    {

        //try
        //{
        //    IDbConnection dbConnection = new SqliteConnection(GetDBFilePath());
        //    dbConnection.Open();

        //    if(dbConnection.State == ConnectionState.Open)
        //    {
        //        Debug.Log("연결 성공");
        //    }
        //    else
        //    {
        //        Debug.Log("연결 실패");
        //    }
        //}
        //catch(Exception e)
        //{
        //    Debug.Log(e);
        //}
    }
}
