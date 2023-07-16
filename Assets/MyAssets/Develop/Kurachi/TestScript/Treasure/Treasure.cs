using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Treasure : MonoBehaviour
{
    [SerializeField] Sprite CloseFolder;
    [SerializeField] Sprite OpenFolder;
    [SerializeField] List<GameObject> Item = new List<GameObject>();
    int _dropItemMaxCnt=3;
    bool _isUsed = false;
    
    void Start(){
        this.GetComponent<SpriteRenderer>().sprite = CloseFolder;
    }
    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("OnTrigger");
        if(!_isUsed){
            UseTreasure();
        }
        
    }
    public void UseTreasure(){
        SetIsUsed();
        ChangeSprite();
        DropItem();
    }
    void SetIsUsed(){
        _isUsed = true;
    }
    void ChangeSprite(){
        this.GetComponent<SpriteRenderer>().sprite = OpenFolder;
    }
    void DropItem(){
        for(int i=0; i<Random.Range(1,_dropItemMaxCnt); i++){
            var pos = transform.position;
            pos.x += Random.Range(-3f, 3f);
            pos.y += Random.Range(-3f, 3f);
            GameObject _dropedItem = Instantiate(Item[Random.Range(0,Item.Count)], transform.position, transform.rotation);
            _dropedItem.transform.DOJump(pos, jumpPower: 5f, numJumps: 2, duration: 2f);
        }
        
    }
    public bool GetIsUsed(){
        return _isUsed;
    }
}
