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
    private JsonExample jsonExample;
    private List<Rank_Box> Rank_Box_List;

    private bool is_saved;
    private int now_rank_index = 100;
    private int new_score = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        jsonExample = FindObjectOfType<JsonExample>();
        is_saved = false;
        init_rank_box_list();
    }

    void Start()
    {
        
    }

    private void Update()
    {
        if (!is_saved && Input.GetKeyDown(KeyCode.Return) && now_rank_index < Rank_Box_List.Count) {
            string new_name = Rank_Box_List[now_rank_index].get_input_name();
            if (!new_name.Equals("") ) {
                Rank_Box_List[now_rank_index].save_input();
                jsonExample.jtc = jsonExample.LoadJsonFile<JTestClass>(Application.dataPath, "JTestClass");
                jsonExample.jtc.RankUpdate(new_name, new_score);
                SaveNewRank();
                is_saved = true;
                //Debug.Log(new_name);
            }            
        }
    }

    private void init_rank_box_list() {
        Rank_Box_List = new List<Rank_Box>();
        for (int i =0; i < transform.childCount; i++) {
            Rank_Box rb = transform.GetChild(i).GetComponent<Rank_Box>();
            if (rb) {
                Rank_Box_List.Add(rb);
            }
            
        }
    }
    public void PrintRank(bool is_new=true)
    {

        jsonExample.jtc = jsonExample.LoadJsonFile<JTestClass>(Application.dataPath, "JTestClass");
        JTestClass new_jtc = new JTestClass(jsonExample.jtc);
        if (is_new) {
            new_score = GameManager.instance.score;
            new_jtc.RankUpdate("", new_score);
            //Debug.Log(new_jtc.data.Count);
           // Debug.Log(Rank_Box_List.Count);
        }        
        for (int i = 0; i < Rank_Box_List.Count; i++)
        {
            if (i >= new_jtc.data.Count)
            {
                Rank_Box_List[i].set_text((i+1).ToString(),"","");
                continue;
            }
            if (is_new && new_jtc.data[i].name.Equals(""))
            {
                now_rank_index = i;
                Rank_Box_List[i].set_text_input((i+1).ToString(), new_jtc.data[i].score.ToString());
            }
            else
            {
                Rank_Box_List[i].set_text((i + 1).ToString(),new_jtc.data[i].name, new_jtc.data[i].score.ToString());
            }
        }
    }

    public void SaveNewRank() {
        jsonExample.jsondata = jsonExample.ObjectToJson(jsonExample.jtc);
        jsonExample.CreateJsonFile(Application.dataPath, "JTestClass", jsonExample.jsondata);
    }
}
