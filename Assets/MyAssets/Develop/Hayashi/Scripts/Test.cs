using System.Collections;
using Assets.MyAssets.Field.Scripts.Attacks.Attackers;
using Assets.MyAssets.Field.Scripts.Attacks.Imples;
using Assets.MyAssets.Field.Scripts.Players;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private GameObject hoge;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(3);
        PhysicsAttack physicsAttack = Instantiate(hoge, this.transform.position, this.transform.rotation)
            .GetComponentInChildren<PhysicsAttack>();
        physicsAttack.StartAttack(5,new PlayerAttacker(PlayerId.Player1));
    }
}
