using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bullet : MonoBehaviour
{
    public Vector3 targetVector;
    private SoundManager soundManager;
   

    public int speed = 10;
    // Start is called before the first frame update 
    private void Awake(){
        Debug.Log("Bullet Awake");
        soundManager = FindObjectOfType<SoundManager>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(targetVector * speed  * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Enemy")
        {
            soundManager.SeleccionAudio(1, 0.5f);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            IncreaseScore();
        }
    }

    // I destroy the bullet when is out of the camera
    void OnBecameInvisible() {
        Destroy(gameObject);
    }

    public void IncreaseScore()
    {
        Player.SCORE++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Score: " + Player.SCORE;
    }
}
