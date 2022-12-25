using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MRH.Utils;

public class Target : MonoBehaviour {

    private static List<Target> targetList;
    private Animation shakeAnimation;
    public static Target GetClosest(Vector3 position, float maxRange) {
        Target closest = null;

        Vector3 targetSpriteOffset = new Vector3(0, 1f);

        foreach (Target target in targetList) {
            if (Vector3.Distance(position, target.GetPosition() + targetSpriteOffset) <= maxRange) {
                if (closest == null) {
                    closest = target;
                } else {
                    if (Vector3.Distance(position, target.GetPosition() + targetSpriteOffset) < Vector3.Distance(position, closest.GetPosition() + targetSpriteOffset)) {
                        closest = target;
                    }
                }
            }
        }
        return closest;
    }
    private void Awake() {
        if (targetList == null) targetList = new List<Target>();
        targetList.Add(this);
        shakeAnimation = transform.Find("Sprite").GetComponent<Animation>();
    }
    public void Damage() {
        if (shakeAnimation != null) shakeAnimation.Play();

        if (shakeAnimation == null) {
            SpriteRenderer spriteRenderer =  transform.Find("Sprite").GetComponent<SpriteRenderer>();
            if (spriteRenderer != null) {
                spriteRenderer.color = Color.red;
                StartCoroutine(SwitchColorGreen(spriteRenderer, 0.2f));
            }
        }
    }
    private IEnumerator SwitchColorGreen(SpriteRenderer spriteRenderer,float duration) {
        yield return new WaitForSeconds(duration);
        spriteRenderer.color = Color.green;
    }
    public Vector3 GetPosition() {
        return transform.position;
    }
}
