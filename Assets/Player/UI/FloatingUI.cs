using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // gameObject.SetActive(!gameObject.activeSelf);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)){
            // gameObject.SetActive(gameObject.activeSelf);
        }
    }
}
