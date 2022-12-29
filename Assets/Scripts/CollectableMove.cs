using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMove : MonoBehaviour
{
    public List<GameObject> collectablesList = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(MoveRight());
    }

    IEnumerator MoveRight()
    {

        for (int i = 0; i < collectablesList.Count; i++)
        {
            yield return new WaitForSeconds(3);
            collectablesList[i].transform.position += new Vector3(0.5f, 0, 0);
        }

    }
}
