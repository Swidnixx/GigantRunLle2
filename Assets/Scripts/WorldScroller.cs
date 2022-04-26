using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScroller : MonoBehaviour
{
    public Transform fragment1, fragment2;

    public GameObject[] worldFragments;

    private void FixedUpdate()
    {
        float speed = GameManager.Instance.worldScrollingSpeed;

        fragment1.position -= new Vector3(speed, 0, 0);
        fragment2.position -= new Vector3(speed, 0, 0);

        if(fragment2.position.x <= 0)
        {
            GameObject fragmentToCreate = worldFragments[Random.Range(0,worldFragments.Length)];
            Transform newFragment = Instantiate(
                fragmentToCreate, fragment2.position + new Vector3(16, 0, 0), Quaternion.identity
                ).transform;

            Destroy(fragment1.gameObject);
            fragment1 = fragment2;
            fragment2 = newFragment;
        }
    }
}
