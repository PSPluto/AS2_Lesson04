using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Cysharp.Threading.Tasks;

public class SampleTask : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private async void Start()
    {
        for (var i = 0; i < 10; i++)
        {
            await UniTask.WaitForSeconds(0.1f);
            Debug.Log("スタートの処理だよ");
        }

        // addressableによるassetの読み込み処理
        // 最初の一つだけ
        // var handle = Addressables.LoadAssetAsync<GameObject>("Prefabs");
        // GameObject prefab = await handle.ToUniTask();
        // Debug.Log($"読み込み済み : {prefab.name}");
        // Instantiate(prefab);
        
        // 複数読み込みしたい場合
        var handle = Addressables.LoadAssetsAsync<GameObject>("Prefabs");
        IList<GameObject> prefabs = await handle.ToUniTask();

        foreach (var p in prefabs)
        {
            Instantiate<GameObject>(p);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("アップデートの処理だよ");
    }
}
