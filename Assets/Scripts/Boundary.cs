using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour {
    public bool dieOffScreen;
    Renderer[] renderers;
    bool isWrappingX;
    bool isWrappingY;

	void Start () {
        renderers = GetComponentsInChildren<Renderer>();	
	}

    bool IsOnScreen() {
        foreach(var r in renderers){
            if (r.isVisible){
                return true;
            }
        }
        return false;
    }

	void Update () {
        bool isVisible = IsOnScreen();

        if (isVisible) {
            isWrappingX = false;
            isWrappingY = false;
            return;
        } else {
            if (dieOffScreen) {
                Destroy(gameObject);
            }
        }

        if (isWrappingX && isWrappingY) {
            return;
        }

        Camera cam = Camera.main;
        Vector3 viewPosition = cam.WorldToViewportPoint(transform.position);
        Vector3 newPosition = transform.position;

        if (!isWrappingX && (viewPosition.x > 1 || viewPosition.x < 0)) {
            newPosition.x = -newPosition.x;
            isWrappingX = true;
        }

        if (!isWrappingY && (viewPosition.y > 1 || viewPosition.y < 0))
        {
            newPosition.y = -newPosition.y;
            isWrappingY = true;
        }

        transform.position = newPosition;
	}
}
