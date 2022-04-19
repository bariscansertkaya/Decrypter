using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LetterManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI passwordText;
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] char letter;
    AudioManager audioManager;

    SpriteRenderer letterRenderer;
    BoxCollider2D letterCollider;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        letterRenderer = GetComponent<SpriteRenderer>();
        letterCollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        audioManager.PlayPickSound();
        passwordText.text += letter;
        Destroy(gameObject);
    }


}
