using System.IO;
using System.Text;
using UnityEngine;

[System.Serializable]
public class JTestClass
{
    public string[] name;
    public int[] score;

    public JTestClass() { }

    public JTestClass(bool isSet)
    {
        if (isSet)
        {
            name = new string[] { "�谭��", "������", "��Ե�", "���°�" };
            score = new int[] { 1, 2, 3, 4 };
        }
    }
    public void Print()
    {
        for (int i = 0; i < name.Length; i++)
        {
            Debug.Log($"{name[i]} : {score[i]} ��");
        }
    }
}


public class JsonExample : MonoBehaviour
{
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
        return JsonUtility.FromJson<T>(jsonData);
    }

    private void Start()
    {
        JTestClass jtc = new JTestClass(true);
        string jsonData = ObjectToJson(jtc);
        CreateJsonFile(Application.dataPath, "JTestClass", jsonData);
    }
}
