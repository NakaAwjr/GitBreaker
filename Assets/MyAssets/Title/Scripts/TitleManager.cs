using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private GameObject _movemanager;
    [SerializeField] private float _speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.transform.DOMove(new Vector3(0, 10, 0), _speed).SetEase(Ease.InBack).onComplete = () =>
            {
                _movemanager.GetComponent<MoveManager>().EndTitle();
            };
        }
    }
}
