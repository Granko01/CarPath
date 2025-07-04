using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    public Transform[] GoTo;
    public GameObject CarOBJ;
    public float moveSpeed = 2f;
    public bool Move = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator MoveCarToTargets()
    {
        foreach (var target in GoTo)
        {
            while (Vector3.Distance(CarOBJ.transform.position, target.position) > 0.05f)
            {
                CarOBJ.transform.position = Vector3.MoveTowards(
                    CarOBJ.transform.position,
                    target.position,
                    moveSpeed * Time.deltaTime
                );
                yield return null;
            }

            yield return new WaitForSeconds(0.2f);
        }
    }

    public void MoveCarMeth()
    {
        Move = true;
        Image img = GetComponent<Image>();
        img.enabled = true;
        StartCoroutine(MoveCarToTargets());
    }
}
