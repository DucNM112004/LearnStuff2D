using System;
using System.Threading.Tasks;
using UnityEngine;

public class TaskMono : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { ProgressReport(); }

    private void ProgressReport()
    {
        IProgress<int> progress = new Progress<int>(percent => 
        {  
            Debug.Log($"Progress: {percent}%"); 
        });

        Task.Run(() => 
        { 
            for (int i = 0; i <= 100; i++) 
            { 
                // Here comes your asynchronous logic 
                progress.Report(i); 
            } 
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
