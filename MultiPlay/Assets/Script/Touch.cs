using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    private bool isbomb= false;
    private GameObject bomb;

    private void Start()
    {
        bomb = GameObject.FindGameObjectWithTag("bomb");
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player")) { 
            Debug.Log("touch");
            if (!isbomb)
            {
                bomb.GetComponent<Bomb>().change(this.gameObject);
                isbomb = true;
            }
            else
            {
                isbomb = false;
            }
            
        }
    }
    public void bombselect()
    {
        isbomb = true;
    }
}
