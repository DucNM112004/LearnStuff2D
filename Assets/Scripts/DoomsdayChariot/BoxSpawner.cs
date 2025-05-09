using System.Collections.Generic;
using DoomsdayChariot;
using UnityEngine;

namespace DoomsdayChariot
{
    public class BoxSpawner : MonoBehaviour
    {
        [SerializeField] private List<Box> boxes;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(boxes[Random.Range(0, boxes.Count)], new Vector3(0, -5, 0), Quaternion.identity);
            }
        }
        
    }
}
