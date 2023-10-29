using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rank_Box : MonoBehaviour
{    
    private List<Text> text_list;
    private void Start()
    {
        init();
    }

    //rank, cl, nameinput, name, sl, score
    private void init() {
        text_list = new List<Text>();
        for (int i =0; i < transform.childCount; i++) {
            Text[] now_texts = transform.GetChild(i).GetComponentsInChildren<Text>();
            if (now_texts.Length == 0) {
                Debug.Log("no text");
                continue;
            }
            if (now_texts.Length == 1)
            {
                text_list.Add(now_texts[0]);
            }
            else if (now_texts.Length == 2)
            {
                text_list.Add(now_texts[1]);
            }
            
        }
    }

    public void set_text(string rank, string name, string score) {
        if (text_list == null) {
            init();
        }
        text_list[(int)rank_box_index.rank].text = rank;
        text_list[(int)rank_box_index.name].text = name;
        text_list[(int)rank_box_index.score].text = score;
        set_active_input(false);
    }
    public void set_text_input(string rank, string score)
    {
        if (text_list == null)
        {
            init();
        }
        text_list[(int)rank_box_index.rank].text = rank;
        text_list[(int)rank_box_index.name].text = "";
        text_list[(int)rank_box_index.score].text = score;
        set_active_input(true);
    }

    private void set_active_input(bool is_active) {
        if (text_list == null)
        {
            init();
        }
        text_list[(int)rank_box_index.name_input].transform.parent.gameObject.SetActive(is_active);
        text_list[(int)rank_box_index.name].gameObject.SetActive(!is_active);
    }
    public void save_input() {
        if (text_list == null)
        {
            init();
        }
        text_list[(int)rank_box_index.name].text = get_input_name();
        set_active_input(false);
    }

    public string get_input_name() {
        if (text_list == null)
        {
            init();
        }
        return text_list[(int)rank_box_index.name_input].text.Trim();
    }
}
