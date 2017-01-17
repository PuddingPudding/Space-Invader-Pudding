using UnityEngine;
using System.Collections;

public class DestroyEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Destroy(col.gameObject);

            GameFunction.Instance.MinusScore(); //若敵人跑出去，則算是玩家失誤沒殺掉，扣分
        }
    }
}
