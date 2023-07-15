using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Test_Property : MonoBehaviour
{
    public int A { get; set; } = 0;
    public int B { get; set; } = 0;
    public int C { get; set; } = 0;
    // Start is called before the first frame update
    void Start()
    {
        A = 1;
        B = 2;
        C = 3;
        foreach (var item in new List<int> { A, B, C })
        {
            Debug.Log("‘—‚é‘¤"+item);
        }
    }
}
