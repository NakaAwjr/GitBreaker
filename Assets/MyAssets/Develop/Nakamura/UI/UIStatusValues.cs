using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatusValues : MonoBehaviour
{
    private int _maxhp;
    private int _hp;
    private int _maxmp;
    private int _mp;
    private int _power;
    private int _defense;
    private int _magicpower;
    private int _magicdefense;
    private int _speed;

    private string _currentwepon;
    private string _currenthead;
    private string _currentbody;
    private string _currentbottom;

    [SerializeField] private TMP_Text _hpText;
    [SerializeField] private TMP_Text _mpText;
    [SerializeField] private TMP_Text _statusText;
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private Slider _mpSlider;

    [SerializeField] private TMP_Text _weponTexr;
    [SerializeField] private TMP_Text _headText;
    [SerializeField] private TMP_Text _bodyText;
    [SerializeField] private TMP_Text _bottomText;

    void Start()
    {
        SetStatus();
    }

    public void SetStatus()
    {
        _hpText.text = "HP(" + _hp.ToString() + "/" + _maxhp.ToString() + ")";
        _mpText.text = "MP(" + _mp.ToString() + "/" + _maxmp.ToString() + ")";
        _statusText.text = "Power:" + _power.ToString() + "\n" +
                           "Defense:" + _defense.ToString() + "\n" +
                           "MagicPower:" + _magicpower.ToString() + "\n" +
                           "MagickDefense:" + _magicdefense.ToString() + "\n" +
                           "Speed:" + _speed.ToString();
        _hpSlider.maxValue = _maxhp;
        _hpSlider.value = _hp;
        _mpSlider.maxValue = _maxmp;
        _mpSlider.value = _mp;

        _weponTexr.text = "Wepon:" + _currentwepon;
        _headText.text = "Head:" + _currenthead;
        _bodyText.text = "Body:" + _currentbody;
        _bottomText.text = "Bottom:" + _currentbottom;
    }
}
