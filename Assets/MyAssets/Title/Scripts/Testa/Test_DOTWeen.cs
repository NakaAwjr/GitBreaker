using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using DG.Tweening.Core;

public class Test_DOTWeen : MonoBehaviour
{
    [SerializeField] private Button test;
    [SerializeField] private Button test2;
    [SerializeField] private InputField test3;
    [SerializeField] private GameObject test4;
    [SerializeField]private float time = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        test2.interactable = false;
        test3.interactable = false;
        test4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushButton()
    {
        test.transform.DOMove(new Vector3(5, 0, 0), time);
        test.interactable = false;
        test2.interactable = true;
        test3.interactable = true;
        test4.SetActive(true);
        test4.transform.DOMove(new Vector3(0, 0, 0), time);
    }
    public void PushButton2()
    {
        test.transform.DOMove(new Vector3(0, 0, 0), time);
        test.interactable = true;
        test2.interactable = false;
        test3.interactable = false;
        test4.transform.DOMove(new Vector3(0, 8, 0), time);
    }
}
