using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGameController : MonoBehaviour
{
    #region
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Obstacle"))
        {
            Debug.Log("Obstacle Carptý");
        }


        if (collision.transform.CompareTag("Collectable"))
        {
            Debug.Log("Collectable Carptý");
        }


        if (collision.transform.CompareTag("Speed"))
        {
            Debug.Log("Speed Carptý");
        }


        if (collision.transform.CompareTag("Protect"))
        {
            Debug.Log("Protect Carptý");
        }
    }
    */
    #endregion
    public SkinnedMeshRenderer playerMash;
    private bool isProtecting = false;
    public GameObject winPanel, losePanel,restartButton, scorePanel;
    public int score = 0;
    public Text scoreText;


    private void Update()
    {
        scoreText.text = score.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Obstacle"))
        {
            if (isProtecting == false)
            {
                Debug.Log("Obstacle Carptý");
                other.gameObject.transform.GetComponent<BoxCollider>().isTrigger = false;
                PlayerMove.instance.playerAnim.SetBool("isDeath", true);
                StartCoroutine(LoseTime());
            }
        }


        if (other.transform.CompareTag("Collectable"))
        {
            Debug.Log("Collectable Carptý");
            score = score + 1;
            Destroy(other.gameObject,0.25f);
        }


        if (other.transform.CompareTag("Speed"))
        {
            Debug.Log("Speed Carptý");
            Destroy(other.gameObject, 0.25f);
            StartCoroutine(PowerUpSpeed());
        }


        if (other.transform.CompareTag("Protect"))
        {
            Debug.Log("Protect Carptý");
            Destroy(other.gameObject, 0.25f);
            StartCoroutine(PowerUpProtect());
        }

        if (other.transform.CompareTag("Finish"))
        {
            StartCoroutine(WinTime());
        }

    }
    IEnumerator PowerUpSpeed()
    {
        PlayerMove.instance.playerAnim.SetBool("isFast", true);
        PlayerMove.instance.speed = 10;
        yield return new WaitForSeconds(2);
        PlayerMove.instance.playerAnim.SetBool("isFast", false);
        PlayerMove.instance.speed = 5;
    }
    IEnumerator PowerUpProtect()
    {
        isProtecting = true;
        playerMash.material.color = Color.red;
        transform.GetComponent<BoxCollider>().isTrigger = true;
        yield return new WaitForSeconds(2);
        transform.GetComponent<BoxCollider>().isTrigger = false; 
        playerMash.material.color = Color.white;
        isProtecting = false;
    }

    IEnumerator LoseTime()
    {
        yield return new WaitForSeconds(3);
        Time.timeScale = 0;
        losePanel.SetActive(true);
        scorePanel.SetActive(true);
        restartButton.SetActive(true);
    }

    IEnumerator WinTime()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
        winPanel.SetActive(true);
        scorePanel.SetActive(true);
        restartButton.SetActive(true);
    }
}
