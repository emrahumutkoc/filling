using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildController : MonoBehaviour
{
    [SerializeField] private RuleTile grassTile;
    [SerializeField] private Tilemap groundTileMap;

    [SerializeField] private float castDistance = 100f;

    public Transform raycastPoint;
    public LayerMask layer;

    //float blockDestroyTime = 0.2f;


    Vector3 direction;
    RaycastHit2D hit;

    bool destroyingBlock = false;
    bool placingBlock = false;

    public void FixedUpdate() {
        if (Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.C)) {
            RaycastDirection();
        }
    }

    private void RaycastDirection() {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {
            direction.x = Input.GetAxis("Horizontal");
            direction.y = Input.GetAxis("Vertical");
        }

        hit = Physics2D.Raycast(raycastPoint.position, direction, castDistance, layer.value);
        Vector2 endpos = raycastPoint.position + direction;

        Debug.DrawLine(raycastPoint.position, endpos, Color.red);

        if (Input.GetKey(KeyCode.F)) {
            if (hit.collider && !destroyingBlock) {
                destroyingBlock = true;
                StartCoroutine(DestroyBlock(hit.collider.gameObject.GetComponent<Tilemap>(), endpos));
            }
        }

        if (Input.GetKey(KeyCode.C)) {
            if (!hit.collider && !placingBlock) {
                placingBlock = true;
                StartCoroutine(PlacingBlock(groundTileMap, endpos));
            }
        }
    }

    IEnumerator DestroyBlock (Tilemap map, Vector2 pos) {
        yield return new WaitForSeconds(0f);


        pos.y = Mathf.Floor(pos.y);
        pos.x = Mathf.Floor(pos.x);

        map.SetTile(new Vector3Int((int)pos.x, (int)pos.y, 0), null);

        destroyingBlock = false;
    }

    IEnumerator PlacingBlock(Tilemap map, Vector2 pos) {
        yield return new WaitForSeconds(0f);


        pos.y = Mathf.Floor(pos.y); 
        pos.x = Mathf.Floor(pos.x);

        map.SetTile(new Vector3Int((int)pos.x, (int)pos.y, 0), grassTile);

        placingBlock = false;
    }
}
