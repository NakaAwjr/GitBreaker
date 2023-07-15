using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class rootDirection : using UnityEngine;

[CreateAssetMenu(fileName = "rootDirection", menuName = "GitBreaker/rootDirection", order = 0)]
public class rootDirection : ScriptableObject {
    public List<bool> isDirection = new List<bool>();
}
