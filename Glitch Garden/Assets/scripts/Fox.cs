using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        if(otherCollider.tag == "Gravestone")
        {
            GetComponent<Animator>().SetTrigger("JumpTrigger");
        }
        else if(otherCollider.tag == "Defender")
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
