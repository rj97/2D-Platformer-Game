using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private GameObject[] healthItemsOrdered;
    private int triesLeft;

    private void Awake()
    {
        triesLeft = transform.childCount;

        GameObject[] healthItems = new GameObject[triesLeft];

        for (int i = 0; i < triesLeft; ++i)
            healthItems[i] = transform.GetChild(i).gameObject;

        healthItemsOrdered = healthItems.OrderBy(item => item.transform.position.x).ToArray();
    }

    public bool decreaseTries()
    {
        if (triesLeft == 0)
        {
            return true;
        }

        Animator anim = healthItemsOrdered[triesLeft - 1].GetComponent<Animator>();
        anim.SetBool("isLosing", true);

        triesLeft -= 1;

        if (triesLeft == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
