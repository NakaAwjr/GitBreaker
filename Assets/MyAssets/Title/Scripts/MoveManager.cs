using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveManager : MonoBehaviour
{
    [SerializeField] private GameObject _title;
    [SerializeField] private GameObject _selectroom;
    [SerializeField] private CanvasGroup _selectroomcanvas;
    [SerializeField] private GameObject _visitroom;
    [SerializeField] private GameObject _createroom;

    [SerializeField] private float _speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        _title.SetActive(true);

        _selectroomcanvas.alpha = 0.0f;
        _selectroom.SetActive(false);

        _visitroom.transform.position = new Vector3(0, 10, 0);
        _visitroom.SetActive(false);

        _createroom.transform.position = new Vector3(0, 10, 0);
        _createroom.SetActive(false);
    }

    //ƒ^ƒCƒgƒ‹‚ªÁ‚¦‚½‚ ‚Æ
    public void EndTitle()
    {
        _title.SetActive(false);
        Debug.Log("Title is killed");
        _selectroom.SetActive(true);
        _selectroomcanvas.DOFade(1.0f, _speed);
    }

    public void ClickVisitRoom()
    {
        _visitroom.SetActive(true);
        _visitroom.transform.DOMove(new Vector3(0, 0, 0), _speed).SetEase(Ease.InOutBack);

    }

    public void ClickVisitCancel()
    {
        _visitroom.transform.DOMove(new Vector3(0, 10, 0), _speed).SetEase(Ease.InBack).onComplete = () =>
        {
            _visitroom.SetActive(false);
        };
    }

    public void ClickCreateRoom()
    {
        _createroom.SetActive(true);
        _createroom.transform.DOMove(new Vector3(0, 0, 0), _speed).SetEase(Ease.InOutBack);
    }

    public void ClickCreateCancel()
    {
        _createroom.transform.DOMove(new Vector3(0, 10, 0), _speed).SetEase(Ease.InBack).onComplete = () =>
        {
            _createroom.SetActive(false);
        };
    }

}
