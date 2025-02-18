using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float lowPosY = -1f;

    public float holesizeMin = 60f;
    public float holesizeMax = 100f;

    public Transform topObject;
    public Transform bottomObject;

    public float withPadding = 6f;

    JumpGameManager jumpGameManager;

    public void Start()
    {
        jumpGameManager = JumpGameManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacelCount)
    {
        float holeSize = Random.Range(holesizeMin, holesizeMax);
        float halfHoleSize = holeSize / 2f;

        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(withPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        FlyPlayer player = collision.GetComponent<FlyPlayer>();
        if (player != null)
            jumpGameManager.AddScore(1);
    }
}
