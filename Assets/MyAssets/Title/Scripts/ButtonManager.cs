using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Color _defaultcolor;
    [SerializeField] private Color _selectedcolor;

    [SerializeField] private Button _random;
    [SerializeField] private Button _select;
    [SerializeField] private TMP_Text _randomtext;
    [SerializeField] private TMP_Text _selecttext;

    [SerializeField] private TMP_InputField _roomidinoutfield;

    [SerializeField] private Button _open;
    [SerializeField] private Button _private;
    [SerializeField] private TMP_Text _opentext;
    [SerializeField] private TMP_Text _privatetext;

   
    // Start is called before the first frame update
    void Start()
    {
        _roomidinoutfield.interactable = false;
    }

    //�����_��or�Z���N�g�{�^�����������ƌĂяo�����
    public void ClickRanSelButton(bool isRandom)
    {
        //���̓t�B�[���h�̗L�����ƃ{�^���I��
        _roomidinoutfield.interactable = !isRandom;
        if (isRandom)
        {
            _random.GetComponent<Image>().color = _selectedcolor;
            _select.GetComponent<Image>().color = _defaultcolor;
            _randomtext.color = _defaultcolor;
            _selecttext.color = _selectedcolor;
        }
        else
        {
            _random.GetComponent<Image>().color = _defaultcolor;
            _select.GetComponent<Image>().color = _selectedcolor;
            _randomtext.color = _selectedcolor;
            _selecttext.color = _defaultcolor;
        }
    }

    //�I�[�v��or�v���C�x�[�g�{�^�����������ƌĂяo�����
    public void ClickOpenPrivateButton(bool isOpen)
    {
        if (isOpen)
        {
            _open.GetComponent<Image>().color = _selectedcolor;
            _private.GetComponent<Image>().color = _defaultcolor;
            _opentext.color = _defaultcolor;
            _privatetext.color = _selectedcolor;
        }
        else
        {
            _open.GetComponent<Image>().color = _defaultcolor;
            _private.GetComponent<Image>().color = _selectedcolor;
            _opentext.color = _selectedcolor;
            _privatetext.color = _defaultcolor;
        }
    }
}
