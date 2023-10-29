using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Controller : MonoBehaviour
{
    private Obstacle_Upper upper;
    private Obstacle_Lower lower;
    private void Start()
    {
        transform.GetChild(0).TryGetComponent(out upper);
        transform.GetChild(1).TryGetComponent(out lower);
        setup(get_player_id());
        random_reset();
       // StartCoroutine(reset_test_co());
    }
    private int get_player_id()
    {
        Player_controll pc = FindObjectOfType<Player_controll>();
        if (pc != null) {
            return pc.get_PlayerNum();
        }
        if (PlayerPrefs.HasKey("Info"))
        {
            return PlayerPrefs.GetInt("Info");
        }
        else
        {
            return Random.Range(0, transform.childCount);
        }
    }
    public void setup( int id) { //불기둥 높이 0, 1, 2  
        upper.init(id);
    }

    public void random_reset() // 호출하면 랜덤으로 불기둥 높이를 설정해서 Active 해줍니당
    {
        int fire_height = Random.Range(0, 3);
        upper.set_obstacle_count(3 - fire_height * 2);
        lower.set_fire_height(fire_height);
    }

    private IEnumerator reset_test_co() {
        while (true) {
            random_reset();
            yield return new WaitForSeconds(2f);
        }
    }
}
