using UnityEngine;
using System.Collections;

public class ShipControl : MonoBehaviour
{
    public GameObject Bullet; //宣告子彈物件

    private float shootingCounter = 1;  //用來計算這一次開槍跟上一次相隔多久的counter

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(GameFunction.Instance.IsPlaying == true)
        {
            this.shootingCounter += Time.deltaTime;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                gameObject.transform.position += new Vector3(0.1f, 0, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                gameObject.transform.position += new Vector3(-0.1f, 0, 0);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                if (this.shootingCounter >= 0.2f) //如果兩次射擊間隔大於0.2秒，則允許再射一發
                {
                    Vector3 pos = gameObject.transform.position + new Vector3(0, 0.9f , 0);

                    Instantiate(Bullet, pos, gameObject.transform.rotation);
                    this.shootingCounter = 0;
                }
            }
        }
        
    }
}
