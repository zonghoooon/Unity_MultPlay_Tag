using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    private GameObject target;
    private bool isbomb = false;
    private int player_num;
    private int rannum;
    private float time;
    public Text timer;
    private GameObject[] players;
    private void Start()
    {
        //player_num = parent.transform.childCount;
        //target = GameObject.FindWithTag("Player");
        //target.GetComponent<Touch>().bombselect();
        
    }
    // Update is called once per frame
    private void Update()
    {
        //Debug.Log(target.name);
        if (isbomb)
        {
            transform.position = target.transform.position + new Vector3(0, 2.2f, 0);
            if (time > 0f) { time -= Time.deltaTime; timer.text = "bomb: "+((int)time).ToString()+" Sec"; }
            
        }
        else
        {
            players = GameObject.FindGameObjectsWithTag("Player");
            player_num = players.Length;
            if (player_num != 0)
            {
                newbomb(player_num);
                StartCoroutine(Bomb_make());
            }
        }
    }
    public void change(GameObject gameObject)
    {
        Debug.Log(gameObject.name);
        target = gameObject;
    }
    IEnumerator Bomb_make()
    {
        yield return new WaitForSeconds(10f);
        isbomb = false;
        players = GameObject.FindGameObjectsWithTag("Player");
        player_num = players.Length;
        if (player_num != 0)
        {
            newbomb(player_num);
        }
    }
    private void newbomb(int num)
    {
        rannum = Random.Range(0, num);
        target = players[rannum];
        target.GetComponent<Touch>().bombselect();
        isbomb = true;
        time = 10f;
        StartCoroutine(Bomb_make());
    }
}
