using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OneTimeText : MonoBehaviour
{
    [SerializeField] string oneTimeText;

    TextMeshProUGUI textMeshProUGUI;

    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        textMeshProUGUI.text = oneTimeText;
        Destroy(gameObject,3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
