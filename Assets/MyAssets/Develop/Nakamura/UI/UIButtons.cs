using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIButtons : MonoBehaviour
{
    [SerializeField] private GameObject _item;
    [SerializeField] private GameObject _equips;

    [SerializeField] private float _speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        _item.SetActive(false);
        _equips.SetActive(false);
        _item.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -1080);
        _equips.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -1080);
    }

    public void OnClickItemButton()
    {
        _item.SetActive(true);
        _item.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), _speed);
    }
    public void OnClickEquipsButton()
    {
        _equips.SetActive(true);
        _equips.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), _speed);
    }

    public void OnClickItemBackButton()
    {
        _item.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, -1080), _speed).onComplete = () => _item.SetActive(false);
    }
    public void OnClickEquipsBackButton()
    {
        _equips.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, -1080), _speed).onComplete = () => _equips.SetActive(false);
    }
}
