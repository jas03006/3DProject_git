using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum rank_box_index
{
    rank =0,
    cl,
    name_input,
    name,
    sl,
    score
}
public class End_Ranking : MonoBehaviour
{
    [SerializeField] private JsonExample jsonExample;
    [SerializeField] Text[] ranktexts;
    [SerializeField] Rank_Box[] Rank_Box_Array;
    [SerializeField] GameObject input_rank_ob;
    [SerializeField] Text[] input_ranktexts;
    private bool is_saved;
    private int now_rank_index = 100;
    // Start is called before the first frame update
    void Start()
    {
        jsonExample = FindObjectOfType<JsonExample>();
        is_saved = false;
    }

    private void Update()
    {
        if (!is_saved && Input.GetKeyDown(KeyCode.Return) && now_rank_index < Rank_Box_Array.Length) {
            string new_name = Rank_Box_Array[now_rank_index].get_input_name();
            if (!new_name.Equals("") ) {
                Rank_Box_Array[now_rank_index].save_input();
                Debug.Log(new_name);
                jsonExample.jtc.RankUpdate(new_name, GameManager.instance.score);
                SaveNewRank();
                is_saved = true;
            }            
        }
    }
    public void PrintNewRank()
    {

        jsonExample.jtc = jsonExample.LoadJsonFile<JTestClass>(Application.dataPath, "JTestClass");
        JTestClass new_jtc = new JTestClass(jsonExample.jtc);
        new_jtc.RankUpdate("", GameManager.instance.score);
        for (int i = 0; i < Rank_Box_Array.Length; i++)
        {
            if (i >= new_jtc.data.Count)
            {
                Rank_Box_Array[i].set_text((i+1).ToString(),"","");
                continue;
            }
            if (new_jtc.data[i].name.Equals(""))
            {
                now_rank_index = i;
                Rank_Box_Array[i].set_text_input((i+1).ToString(), new_jtc.data[i].score.ToString());

            }
            else
            {
                Rank_Box_Array[i].set_text((i + 1).ToString(),new_jtc.data[i].name, new_jtc.data[i].score.ToString());
            }
        }
    }

    public void SaveNewRank() {
        jsonExample.jsondata = jsonExample.ObjectToJson(jsonExample.jtc);
        jsonExample.CreateJsonFile(Application.dataPath, "JTestClass", jsonExample.jsondata);
    }
}
