using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Controller : MonoBehaviour
{
    public GameObject Furry;
    int Speed = 10;      //ついてくるスペード
    private int take = 0;//連れて行くかどうか

    // Start is called before the first frame update
    void Start()
    {
        Furry = GameObject.Find("Furry");
    }

    // Update is called once per frame
    void Update()
    {
        Take();
    }

    void Take()
    {
        if (Input.GetKey(KeyCode.C)) take = 1;
        if (Input.GetKey(KeyCode.R)) take = 0;
        this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(Furry.transform.position.x - 3, Furry.transform.position.y), Speed * Time.deltaTime * take);
    }
}
