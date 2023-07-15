using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Get : MonoBehaviour
{
    public Test_Property test_Property;
    private int D;
    private int E;
    private int F;
    // Start is called before the first frame update
    void Start()
    {
        D = test_Property.A;
        E = test_Property.B;
        F = test_Property.C;
        foreach (var item in new List<int> { D, E, F })
        {
            Debug.Log("�󂯂鑤"+item);
        }
    }
}
