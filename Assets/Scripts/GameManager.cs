using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Spawner spawner;
    void Start()
    {
        spawner = new Spawner();
        
        spawner.LoadAsync("Prefabs");
    }

    private void Update()
    {
        spawner.Spawn("Item");
    }
}
