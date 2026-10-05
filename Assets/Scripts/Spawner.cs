using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Spawner
{
    // -- 変数 --
    private GameObject[] _prefabs;

    public bool isLoaded = false;

    public async void LoadAsync(string label)
    {
        isLoaded = false;
        var handle = Addressables.LoadAssetsAsync<GameObject>(label);
        IList<GameObject> result = await handle.ToUniTask();
        _prefabs = result.ToArray();
        isLoaded = true;
    }

    public void Spawn(int index)
    {
        if (!isLoaded)
        {
            Debug.Log("まだ読み込み中");
            return;
        }
        GameObject.Instantiate(_prefabs[index]);
    }
    
    public void Spawn(string prefabName)
    {
        if (!isLoaded)
        {
            Debug.Log("まだ読み込み中");
            return;
        }
        
        if (FindName(_prefabs, prefabName, out GameObject result))
        {
            GameObject.Instantiate(result);
        }
    }

    private bool FindName(GameObject[] array ,string name , out GameObject result)
    {
        result = null;
        
        foreach (var obj in array)
        {
            result = name == obj.name ? obj : null;
            if (result != null) break;
        }
        
        if (result == null)
        {
            Debug.Log("合致するものがなかった");
            return false;
        }
        
        return true;
    }
}
