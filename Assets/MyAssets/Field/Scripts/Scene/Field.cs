using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.MyAssets.Common.Scripts;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Scene
{
    public class Field : MonoBehaviour
    {
        public async Task SceneLoad(bool isAliveBoss,bool isAlivePlayer)
        {
            Debug.Log($"Bossは{isAliveBoss}、プレイヤーは{isAlivePlayer}");
            // シーンBをロードしてコンポーネントを取得
            //var nextScene = await SceneLoader.Load<Result>("Result");

            // 任意のメソッド呼び出し (タイミングはsceneBのAwakeの後、Startの前)
            // SceneAのGameObjectはDestroy済みでnullになるので注意
            //nextScene.SetArguments(123, new List<string> { "abc", "あいうえお" });
        }
    }
}

