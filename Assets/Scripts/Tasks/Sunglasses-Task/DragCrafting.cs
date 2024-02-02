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
        
        if (mouseButtonReleased && thisGameObjectName == "glasses" && collisionGameobjectName == "frame")
        {
            manipulateGameObject(collision, "sunglasses_Object", false);
        }
        else if (mouseButtonReleased && thisGameObjectName == "glasses" && collisionGameobjectName == "fullframe")
        {
            manipulateGameObject(collision, "glassesProduct_Object", true);
        }
        else if (mouseButtonReleased && thisGameObjectName == "3part" && collisionGameobjectName == "frame")
        {
            manipulateGameObject(collision, "fullframe_Object", false);
        }
        else if (mouseButtonReleased && thisGameObjectName == "3part" && collisionGameobjectName == "sunglasses")
        {
            manipulateGameObject(collision, "glassesProduct_Object", true);
        }
    }

    private void manipulateGameObject(Collider2D collision, string resourceName, bool checkProductStatement = false)
    {
        Instantiate(Resources.Load(resourceName), transform.position, Quaternion.identity);
        mouseButtonReleased = false;
        Destroy(collision.gameObject);
        Destroy(gameObject);
        
        if(checkProductStatement && checkProduct != null){
            checkProduct.finishProduct(true);
        }
    }


    private string GetObjectName(GameObject obj)
    {
        int underscoreIndex = obj.name.IndexOf("_");
        return (underscoreIndex != -1) ? obj.name.Substring(0, underscoreIndex) : obj.name;
    }
}
