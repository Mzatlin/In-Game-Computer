using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectOnStart : MonoBehaviour
{
    [SerializeField]
    GameObject objectToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        if(objectToSpawn != null)
        {
            objectToSpawn.SetActive(true);
        }
    }

}
