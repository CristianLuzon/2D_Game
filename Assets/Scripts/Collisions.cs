using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{

    [Header("State")]
    public bool isGrounded;
    public bool wasGroundedLastFrame;
    public bool justNotGrounded;
    public bool justGotGrounded;
    public bool isFalling;

    public bool isWalled;
    public bool wasWalledLastFrame;
    public bool justNotWalled;
    public bool justGotWalled;

    public bool isCellinged;
    public bool wasCeilingedLastFrame;
    public bool justNotCellinged;
    public bool justGotCellinged;

    [Header("Filter")]
    public ContactFilter2D filter;
    public int maxColliders = 6;

    public bool checkGround;
    public bool checkWall;
    public bool checkCelling;

    [Header("Filter")]
    public Vector2 groundedBoxPos;
    public Vector2 groundedBoxSize;

    public Vector2 walledBoxPos;
    public Vector2 walledBoxSize;

    public Vector2 cellingedBoxPos;
    public Vector2 cellingedBoxSize;

    void Start()
    {

    }

    void FixedUpdate()
    {
        ResetState();

        GroundDetection();
        WallDetection();
        CellingDetection();
    }

    void ResetState()
    {
        wasGroundedLastFrame = isGrounded;
        isFalling = !isGrounded;

        wasWalledLastFrame = isWalled;

        wasCeilingedLastFrame = isCellinged;

        isGrounded = false;
        justNotGrounded = false;
        justGotGrounded = false;

        isWalled = false;
        justNotWalled = false;
        justGotWalled = false;

        isCellinged = false;
        justNotCellinged = false;
        justGotCellinged = false;
    }

    void GroundDetection()
    {
        if(!checkGround) return;

        Vector3 pos = this.transform.position + (Vector3)groundedBoxPos;
        Collider2D[] results = new Collider2D[maxColliders];

        int numCollider = Physics2D.OverlapBox(pos, groundedBoxSize, 0, filter, results);

        if(numCollider > 0)
        {
            isGrounded = true;
        }
    }
    void WallDetection()
    {
        if(!checkWall) return;

        Vector3 pos = this.transform.position + (Vector3)walledBoxPos;
        Collider2D[] results = new Collider2D[maxColliders];

        int numCollider = Physics2D.OverlapBox(pos, walledBoxSize, 0, filter, results);

        if(numCollider > 0)
        {
            isWalled = true;
        }
    }
    void CellingDetection()
    {
        if(!checkCelling) return;

        Vector3 pos = this.transform.position + (Vector3)cellingedBoxPos;
        Collider2D[] results = new Collider2D[maxColliders];

        int numCollider = Physics2D.OverlapBox(pos, cellingedBoxSize, 0, filter, results);

        if(numCollider > 0)
        {
            isCellinged = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireCube(this.transform.position + (Vector3)groundedBoxPos, groundedBoxSize);

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(this.transform.position + (Vector3)walledBoxPos, walledBoxSize);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(this.transform.position + (Vector3)cellingedBoxPos, cellingedBoxSize);
    }
}
