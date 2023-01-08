using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void play(){
        SceneManager.LoadScene("GameScene");
    }

    public void instructions(){
        SceneManager.LoadScene("InstructionScene");
    }

    public void hangar(){
        SceneManager.LoadScene("Hangar");
    }

    public void main(){
        SceneManager.LoadScene("MainScene");
    }

    public void play1(){
        SceneManager.LoadScene("Ship1Scene");
    }

    public void play2(){
        SceneManager.LoadScene("Ship2Scene");
    }
}