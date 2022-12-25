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
            Debug.Log("Obstacle Carpt�");
        }


        if (collision.transform.CompareTag("Collectable"))
        {
            Debug.Log("Collectable Carpt�");
        }


        if (collision.transform.CompareTag("Speed"))
        {
            Debug.Log("Speed Carpt�");
        }


        if (collision.transform.CompareTag("Protect"))
        {
            Debug.Log("Protect Carpt�");
        }
    }
    */
    #endregion
    public SkinnedMeshRenderer playerMash;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Obstacle"))
        {
            Debug.Log("Obstacle Carpt�");
            other.gameObject.transform.GetComponent<BoxCollider>().isTrigger = false;
            PlayerMove.instance.playerAnim.SetBool("isDeath", true);
            Invoke("StopTime", 2.0f);
        }


        if (other.transform.CompareTag("Collectable"))
        {
            Debug.Log("Collectable Carpt�");
            Destroy(other.gameObject,0.25f);
        }


        if (other.transform.CompareTag("Speed"))
        {
            Debug.Log("Speed Carpt�");
            Destroy(other.gameObject, 0.25f);
            StartCoroutine(PowerUpSpeed());
        }


        if (other.transform.CompareTag("Protect"))
        {
            Debug.Log("Protect Carpt�");
            Destroy(other.gameObject, 0.25f);
            StartCoroutine(PowerUpProtect());
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
        playerMash.material.color = Color.red;
        yield return new WaitForSeconds(2);
        playerMash.material.color = Color.white;
    }
    void StopTime()
    {
        Time.timeScale = 0;
    }
}
