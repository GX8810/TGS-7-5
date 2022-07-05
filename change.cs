using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class change : MonoBehaviour
{
    Animator animator;
    public bool waterflag;
    public bool plantflag;
    GameObject Water;
    GameObject Player;
    GameObject Plant;

    Rigidbody2D rigid2D;
    
    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.Water = GameObject.Find("mizu");
        this.Player = GameObject.Find("chara");
        this.Plant = GameObject.Find("plant");
        waterflag = false;
        plantflag = false;
        this.animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 p1 = this.Player.transform.position;
        Vector2 p2 = this.Water.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;
        float r2 = 1.0f;

        if (d < r1 + r2)
        {
            waterflag = true;
            Destroy(GameObject.Find("mizu"));
        }
        if (waterflag == true)
        {
            //this.animator.SetTrigger("WaterTrigger");
            this.Water = GameObject.Find("plant");
            Vector2 p3 = this.Plant.transform.position;
            //Vector2 p4 = this.Water.transform.position;
            Vector2 dir2 = p3 - p1;
            float d2 = dir2.magnitude;
            float r3 = 1.0f;
            float r4 = 1.0f;
            if (d2 < r3 + r4)
            {
                plantflag = true;
                this.animator.SetTrigger("glowTrigger");
                //this.animator.SetBool("plantBool",true);

            }
            //float length = this.plant2.transform.position.x - this.player.transform.position.x;
            //if (length == 0)
            {
                //SceneManager.LoadScene("stage select");
            }
        }
        if (plantflag == true)
        {
            Invoke("senni", 2.0f);
        }
    }
    void senni()
    {
        SceneManager.LoadScene("clear");
    }
}
