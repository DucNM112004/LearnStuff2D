using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class TestSpawner : MonoBehaviour
{
    [SerializeField] private AssetReference obj;
    [SerializeField] private AssetLabelReference label;
    [SerializeField] private AssetReference scene;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnGameObject();
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            LoadScene();
        }
    }

    private void SpawnGameObject()
    {
        // Load asset from asset reference
        // var handle = Addressables.LoadAssetAsync<GameObject>(obj);
        // handle.Completed += (AsyncOperationHandle<GameObject> task) =>
        // {
        //     Instantiate(task.Result);
        // };

        // load asset from asset label ref
        var handle2 = Addressables.LoadAssetsAsync<GameObject>(label, result => { Instantiate(result); });
    }

    private void LoadScene()
    {
        Addressables.LoadSceneAsync(scene);
    }

}
