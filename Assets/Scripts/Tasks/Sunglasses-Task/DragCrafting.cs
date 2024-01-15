using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class DragCrafting : MonoBehaviour
{
    private Vector2 mousePosition;
    private float offsetX, offsetY;
    public static bool mouseButtonReleased;

    private GameObject foundTaskCanvas;
    private CheckStatus checkProduct;
    void Start(){

        foundTaskCanvas = GameObject.Find("TaskCanv");
        if(foundTaskCanvas != null){
            checkProduct = foundTaskCanvas.GetComponent<CheckStatus>();
            if(checkProduct == null){
                Debug.LogError("CheckStatus script not found!");
            }
        }
    }

    void Update(){
    }

    private void OnMouseDown()
    {
        mouseButtonReleased = false;
        offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - offsetX, mousePosition.y - offsetY);
    }

    private void OnMouseUp()
    {
        mouseButtonReleased = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        string thisGameObjectName = GetObjectName(gameObject);
        string collisionGameobjectName = GetObjectName(collision.gameObject);

        //Debug.Log("ObjName: " + thisGameObjectName);
        //Debug.Log("CollName: " + collisionGameobjectName);

        if (mouseButtonReleased && thisGameObjectName == "glasses" && collisionGameobjectName == "frame")
        {
            Instantiate(Resources.Load("sunglasses_Object"), transform.position, Quaternion.identity);
            mouseButtonReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (mouseButtonReleased && thisGameObjectName == "glasses" && collisionGameobjectName == "fullframe")
        {
            Instantiate(Resources.Load("glassesProduct_Object"), transform.position, Quaternion.identity);
            mouseButtonReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            if(checkProduct != null){
                checkProduct.finishProduct(true);
            }
        }

        else if (mouseButtonReleased && thisGameObjectName == "3part" && collisionGameobjectName == "frame")
        {
            Instantiate(Resources.Load("fullframe_Object"), transform.position, Quaternion.identity);
            mouseButtonReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        else if (mouseButtonReleased && thisGameObjectName == "3part" && collisionGameobjectName == "sunglasses")
        {
            Instantiate(Resources.Load("glassesProduct_Object"), transform.position, Quaternion.identity);
            mouseButtonReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            if(checkProduct != null){
                checkProduct.finishProduct(true);
            }

        }
    }

    private string GetObjectName(GameObject obj)
    {
        int underscoreIndex = obj.name.IndexOf("_");
        return (underscoreIndex != -1) ? obj.name.Substring(0, underscoreIndex) : obj.name;
    }
}
