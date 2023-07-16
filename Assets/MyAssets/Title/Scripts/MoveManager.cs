using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveManager : MonoBehaviour
{
    [SerializeField] private GameObject _title;

    [SerializeField] private GameObject _selectroom;
    [SerializeField] private CanvasGroup _selectroomcanvas;

    [SerializeField] private GameObject _visitroom;
    [SerializeField] private GameObject _createroom;

    [SerializeField] private GameObject _roading;
    [SerializeField] private Image _roadingbackground;
    [SerializeField] private GameObject _roadingbackgroundobject;

    [SerializeField] private GameObject _maching;

    [SerializeField] private GameObject _error;
    
    public PhotonManager PhotonManager;
    public MachingManager MachingManager;

    //アニメーションの速さ
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

        _roading.SetActive(false);
        _roading.transform.position = new Vector3(0, 10, 0);
        _roadingbackgroundobject.SetActive(false);
        _roadingbackground.color = new Color(0, 0, 0, 0);

        _maching.SetActive(false);
        _maching.transform.position = new Vector3(0, 10, 0);

        _error.SetActive(false);
        _error.transform.position = new Vector3(0, 10, 0);
    }

    //タイトルが消えたあと
    public void EndTitle()
    {
        _title.SetActive(false);
        Debug.Log("Title is killed");
        _selectroom.SetActive(true);
        _selectroomcanvas.DOFade(1.0f, _speed);
    }
    
    //部屋入室画面
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

    //部屋作成画面
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

    //ローディング画面へ移行
    public void ClickEnterCreate(bool iscreate)
    {
        _roadingbackgroundobject.SetActive(true);
        _roadingbackground.DOFade(0.5f, _speed);
        _roading.SetActive(true);
        _roading.transform.DOMove(new Vector3(0, 0, 0), _speed).SetEase(Ease.InOutBack);
        //Photonに接続
        PhotonManager.StartConnect(iscreate);
    }

    //エラー画面
    public void Error()
    {
        _error.SetActive(true);
        _error.transform.DOMove(new Vector3(0, 0, 0), _speed).SetEase(Ease.InOutBack);
    }
    public void ClickBack()
    {
        _error.transform.DOMove(new Vector3(0, 10, 0), _speed).SetEase(Ease.InBack).onComplete = () =>
        {
            _roading.transform.DOMove(new Vector3(0, 10, 0), _speed).SetEase(Ease.InBack).onComplete = () =>
            {
                _roadingbackground.DOFade(0.0f, _speed).onComplete = () =>
                {
                    _error.SetActive(false);
                    _roading.SetActive(false);
                    _roadingbackgroundobject.SetActive(false);
                };
            };
        };
    }

    //マッチング画面へ移行
    public void EndConnect()
    {
        _roading.transform.DOMove(new Vector3(0, 10, 0), _speed).SetEase(Ease.InBack).onComplete = () =>
        {
            _roading.SetActive(false);
            _roadingbackground.DOFade(0.0f, _speed).onComplete = () =>
            {
                _roadingbackgroundobject.SetActive(false);
                MachingScene();
            };
        };
    }
    void MachingScene()
    {
        _maching.SetActive(true);  
        MachingManager.StartMaching();

        _maching.transform.DOMove(new Vector3(0, 0, 0), _speed).onComplete = () =>
        {
            _createroom.SetActive(false);
            _visitroom.SetActive(false);
            _selectroom.SetActive(false);
        };
    }

    [SerializeField] private string _scenename;
    public void ClickStart()
    {
        SceneManager.LoadScene(_scenename);
    }
}
