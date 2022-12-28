using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject winPanel, losePanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Obstacle"))
        {
            if (isProtecting == false)
            {
                Debug.Log("Obstacle Carptý");
                other.gameObject.transform.GetComponent<BoxCollider>().isTrigger = false;
                PlayerMove.instance.playerAnim.SetBool("isDeath", true);
                Invoke("LoseTime", 3.0f);
            }
        }


        if (other.transform.CompareTag("Collectable"))
        {
            Debug.Log("Collectable Carptý");
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
            WinTime();
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
    void LoseTime()
    {
        Time.timeScale = 0;
        losePanel.SetActive(true);
    }
    void WinTime()
    {
        Time.timeScale = 0;
        winPanel.SetActive(true);
    }
}
