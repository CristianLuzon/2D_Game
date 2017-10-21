using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestsCollisions : MonoBehaviour
{
    public Collider2D collider2D;
    public ContactFilter2D ContactFilter;
    public Collider2D[] results;
    public int numCollider;

    public Vector2 boxSize;

    void Start()
    {

    }

    void Update()
    {

    }

    void FixedUpdate ()
    {
        //numCollider = Physics2D.OverlapCollider(collider2D, ContactFilter, results);
        //numCollider = Physics2D.OverlapCollider( ContactFilter, results);

        numCollider = Physics2D.OverlapBox(this.transform.position, boxSize, 0, ContactFilter, results);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(this.transform.position, boxSize);
    }


}
