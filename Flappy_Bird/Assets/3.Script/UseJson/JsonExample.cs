using System.IO;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JTestUnitClass
{
    public string name;
    public int score;
}
[System.Serializable]
public class JTestClass
{
    public List<JTestUnitClass> data;
    public JTestClass()
    {
        data = new List<JTestUnitClass>();
    }
    public JTestClass(JTestClass jtc) {
        data = new List<JTestUnitClass>();
        for (int i = 0; i < jtc.data.Count; i++) {
            JTestUnitClass jtuc = new JTestUnitClass();
            jtuc.name = jtc.data[i].name;
            jtuc.score = jtc.data[i].score;
            data.Add(jtuc);
        }
    }

    public void RankUpdate(string new_name, int new_score)
    {
        JTestUnitClass rank = new JTestUnitClass();
        rank.name = new_name;
        rank.score = new_score;
        data.Add(rank);
        data.Sort((a, b) => b.score.CompareTo(a.score));
    }
}
public class JsonExample : MonoBehaviour
{
    public JTestClass jtc;
    public string jsondata;

    public string ObjectToJson(object obj)
    {
        return JsonUtility.ToJson(obj); //JsonUtility.ToJson(obj) : 데이터를 Json으로 직렬화 
    }
    T JsonToObject<T>(string jsonData)
    {
        return JsonUtility.FromJson<T>(jsonData); //JsonUtility.ToJson(obj) : Json데이터를 object로 전환
    }
    public void CreateJsonFile(string createPath, string filename, string jsonData)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, filename), FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }
    public T LoadJsonFile<T>(string loadPath, string filename)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, filename), FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string jsonData = Encoding.UTF8.GetString(data);
        Debug.Log(jsonData);
        return JsonUtility.FromJson<T>(jsonData);
    }

    private void Start()
    {
        jtc = new JTestClass();
        jsondata = ObjectToJson(jtc);
        //CreateJsonFile(Application.dataPath, "JTestClass", jsondata);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("교수님 랭킹등판");
            jtc.RankUpdate("고동원", 452);

            //json데이터 직렬화해서 파일 만들기
            jsondata = ObjectToJson(jtc);
            CreateJsonFile(Application.dataPath, "JTestClass", jsondata);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("강민이오빠 랭킹등판");
            jtc.RankUpdate("강민", 1000);

            //json데이터 직렬화해서 파일 만들기
            jsondata = ObjectToJson(jtc);
            CreateJsonFile(Application.dataPath, "JTestClass", jsondata);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            //jtc.Print();
            jtc = LoadJsonFile<JTestClass>(Application.dataPath, "JTestClass");
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            //jtc.Print();
            CreateJsonFile(Application.dataPath, "JTestClass", "{}");
            jtc = LoadJsonFile<JTestClass>(Application.dataPath, "JTestClass");
        }
    }
}