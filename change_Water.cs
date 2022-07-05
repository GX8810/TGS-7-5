using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class change_Water : MonoBehaviour
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
        if (this.Water != null)
        {
            Vector2 p2 = this.Water.transform.position;
            Vector2 dir = p1 - p2;
            float d = dir.magnitude;
            float r1 = 0.5f;
            float r2 = 1.0f;

            if (d < r1 + r2)
            {
                waterflag = true;
                Destroy(GameObject.Find("mizu"));
                this.Water = null;
            }
        }
        if(waterflag == true)
        {
            animator.SetTrigger("WaterTrigger");
        }
    }
}
