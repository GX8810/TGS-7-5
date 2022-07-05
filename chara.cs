using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class chara : MonoBehaviour
{
    Animator animator;
    public bool waterflag;
    public bool plantflag;
    GameObject Water;
    GameObject Player;
    GameObject Plant;

    Rigidbody2D rigid2D;
    float jumpForce = 200.0f;
    float walkSpeed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.Water = GameObject.Find("mizu");
        this.Player = GameObject.Find("chara");
        this.Plant = GameObject.Find("plant");
        waterflag = false;
        plantflag = false;
        //this.animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 p1 = transform.position;    //操作キャラの座標を取得
        // ジャンプする
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        //プレイヤの移動
        if (Input.GetKey(KeyCode.RightArrow))   //右矢印を押してる間
        {
            p1.x += walkSpeed;  //キャラがスピードの値だけ右に移動
        }
        else if (Input.GetKey(KeyCode.LeftArrow))   //左矢印が押してる青田
        {
            p1.x -= walkSpeed;  //キャラがスピードの値だけ左に移動
        }
        transform.position = p1;

        // 動く方向に応じて反転

        if (this.Water != null)
        {
            Vector2 p2 = this.Water.transform.position;
            Vector2 dir = p1 - p2;
            float d = dir.magnitude;
            float r1 = 0.1f;
            float r2 = 0.1f;

            if (d < r1 + r2)
            {
                waterflag = true;
                Destroy(this.Water);
                this.Water = null;
            }
        }
            if (waterflag == true)
            {
            //animator.SetTrigger("WaterTrigger");
            this.Plant = GameObject.Find("plant");
                Vector2 p3 = transform.position;
                Vector2 dir2 = p3 - p1;
                float d2 = dir2.magnitude;
                float r3 = 0.1f;
                float r4 = 0.1f;
                if (d2 < r3 + r4)
                {
                    //Destroy(GameObject.Find("plant"));
                    plantflag = true;
                    //animator.SetTrigger("glowTrigger");
                    //this.animator.GetBool("plantBool");

                }
                //if (plantflag == true)
                //{
                  //  Invoke("senni", 1.0f);
                //}
                //float length = this.plant2.transform.position.x - this.player.transform.position.x;
                //if (length == 0)
                //{
                //SceneManager.LoadScene("stage select");
                //}
            }
        
    }
    //void senni()
    //{
    //    SceneManager.LoadScene("clear");
    //}
}