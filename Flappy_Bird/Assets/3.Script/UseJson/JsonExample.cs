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

    public void RankUpdate(string new_name, int new_score)
    {
        JTestUnitClass rank = new JTestUnitClass();
        rank.name = new_name;
        rank.score = new_score;
        data.Add(rank);
        data.Sort((a, b) => b.score.CompareTo(a.score));
    }
   
    public void Print()
    {
        for (int i = 0; i < data.Count; i++)
        {
            Debug.Log($"{i+1}��! {data[i].name} : {data[i].score}");
        }
    }
}

public class JsonExample : MonoBehaviour
{
    public JTestClass jtc;
    public string jsondata;

    public string ObjectToJson(object obj)
    {
        return JsonUtility.ToJson(obj); //JsonUtility.ToJson(obj) : �����͸� Json���� ����ȭ 
    }
    T JsonToObject<T>(string jsonData)
    {
        return JsonUtility.FromJson<T>(jsonData); //JsonUtility.ToJson(obj) : Json�����͸� object�� ��ȯ
    }
    void CreateJsonFile(string createPath, string filename, string jsonData)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, filename), FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }
    T LoadJsonFile<T>(string loadPath, string filename)
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
        CreateJsonFile(Application.dataPath, "JTestClass", jsondata);
        jtc = LoadJsonFile<JTestClass>(Application.dataPath, "JTestClass");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("������ ��ŷ����");
            jtc.RankUpdate("����", 452);

            //json������ ����ȭ�ؼ� ���� �����
            jsondata = ObjectToJson(jtc);
            CreateJsonFile(Application.dataPath, "JTestClass", jsondata);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("�����̿��� ��ŷ����");
            jtc.RankUpdate("����", 1000);

            //json������ ����ȭ�ؼ� ���� �����
            jsondata = ObjectToJson(jtc);
            CreateJsonFile(Application.dataPath, "JTestClass", jsondata);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            jtc.Print();
            jtc = LoadJsonFile<JTestClass>(Application.dataPath, "JTestClass");
        }
    }
}
