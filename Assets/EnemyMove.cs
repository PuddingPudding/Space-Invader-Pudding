using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
    private float LRmoveCounter = 0;
    private float LRmovement = 0;

    public GameObject explotion;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(GameFunction.Instance.IsPlaying == true)
        {
            if (this.LRmoveCounter == 0)
            {
                this.LRmovement = Random.Range(-0.03f, 0.03f);
            }

            gameObject.transform.position += new Vector3(this.LRmovement, -0.021f, 0);

            LRmoveCounter += Time.deltaTime;
            if (this.LRmoveCounter >= 0.3f)
            {          
                this.LRmoveCounter = 0;
            }
        }        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "CaptainMortal")
        {
            Destroy(col.gameObject);
            Instantiate(explotion, col.gameObject.transform.position, col.gameObject.transform.rotation);

            GameFunction.Instance.GameOver();
        }
        else if(col.tag == "Bullet")
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            Instantiate(explotion , transform.position, transform.rotation);

            GameFunction.Instance.AddScore(); //當敵人碰觸到子彈時，死亡，並給玩家分數
        }
    }
}
