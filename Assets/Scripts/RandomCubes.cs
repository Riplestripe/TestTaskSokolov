using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomCubes : MonoBehaviour
{
    [SerializeField] Material Variant_01;
    [SerializeField] Material Variant_02;

    [SerializeField] GameObject[] cubes;
    
    private void Start()
    {
        Randomise();

    }
    
    public void Randomise()
    {

        for (int i = 0; i < cubes.Length; i++)
        {
            var array = new Material[] { Variant_01, Variant_02 };
            cubes[i].GetComponent<MeshRenderer>().material = array[Random.Range(0, array.Length)];
            
        }
        


    }
    
   
}
