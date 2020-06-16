using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnClick : MonoBehaviour
{
    [SerializeField]
    GameObject objectToSpawn;
    IButton click;

    // Start is called before the first frame update
    void Start()
    {
        objectToSpawn.SetActive(false);
        click = GetComponent<IButton>();
        if (click != null)
        {
            click.OnClicked += HandleClick;
        }
    }
    void OnDestroy()
    {
        click.OnClicked -= HandleClick;
    }

    private void HandleClick()
    {
        objectToSpawn.SetActive(true);
    }


}
