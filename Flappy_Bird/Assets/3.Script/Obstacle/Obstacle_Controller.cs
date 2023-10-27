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
        setup(0);
        random_reset();
       // StartCoroutine(reset_test_co());
    }

    public void setup(int player_id ) { //�ұ�� ���� 0, 1, 2  
        upper.init(player_id);
    }

    public void random_reset() // ȣ���ϸ� �������� �ұ�� ���̸� �����ؼ� Active ���ݴϴ�
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
