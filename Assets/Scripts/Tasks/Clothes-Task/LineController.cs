using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lr;
    public List<Vector3> pointPositions = new List<Vector3>();
    private Vector3 lastPointPosition;

    private bool finishClothes = false;
    private Vector3 tshirtSpawnPosition = new Vector3(-0.11f, 0.3f, -0.8f); //Position of Tshirt (Spawn)

    private GameObject foundTaskCanvas;
    private CheckStatus checkProduct;

    public GameObject Points;
    private GameObject materialObj;
    private GameObject path;





    void Awake()
    {
        lr = GetComponent<LineRenderer>(); //Get component LineRender
    }


    void Start()
    {
        lr.enabled = false;
        materialObj = GameObject.Find("material");
        path = GameObject.Find("path");

        foundTaskCanvas = GameObject.Find("TaskCanv");
        if(foundTaskCanvas != null){
            checkProduct = foundTaskCanvas.GetComponent<CheckStatus>();
            if(checkProduct == null){
                Debug.LogError("CheckStatus script not found!");
            }
        }
    }

    /*===============[ Draw Line ]===============*/
    private void CreateLine(Vector3 finalPointPosition)
    {
        if (!pointPositions.Contains(finalPointPosition))
        {
            pointPositions.Add(finalPointPosition);
            lastPointPosition = finalPointPosition;
            lr.enabled = true;
            SetupLine();
        }
        else if (pointPositions.Count > 1 && pointPositions[0] == finalPointPosition)
        {
            pointPositions.Add(finalPointPosition);
            //lastPointPosition = finalPointPosition;
            lr.enabled = true;
            SetupLine();
            StartCoroutine(MoveTo(lastPointPosition));
            Debug.Log("You've reached the starting point again!");
            _finishClothes();
        }
        else
        {
            Debug.Log("This Point has been used Yet!");
        }
    }


    /*===============[ Setup Line ]===============*/
    private void SetupLine()
    {
        int pointLength = pointPositions.Count;
        lr.positionCount = pointLength;
        for (int i = 0; i < pointLength; i++)
        {
            lr.SetPosition(i, pointPositions[i]);
        }
    }

    /*===============[ Click Checker ]===============*/
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !finishClothes)
        {
            Debug.Log("MouseClicked");
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null)
            {
                CreateLine(hit.collider.transform.position);
                print(hit.collider.name);
            }
        }

        else if (Input.GetKeyDown(KeyCode.Space) && !finishClothes)
        {
            MoveToLastPoint();
        }
    }

    /*===============[ Move by points ]===============*/
    void MoveToLastPoint()
    {
        if (pointPositions.Count > 1)
        {
            pointPositions.Add(transform.position);

            StartCoroutine(MoveTo(lastPointPosition));
        }
        else
        {
            Debug.Log("No More Points to Move");
        }
    }

    IEnumerator MoveTo(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5f);
            yield return null;
        }

        transform.position = targetPosition;
    }


    /*===============[ Finisher ]===============*/
    void _finishClothes(){
        Debug.Log("Task FINISH!!");
        if(materialObj != null){
            Instantiate(Resources.Load("tshirt2_Object"), tshirtSpawnPosition, Quaternion.identity);
            Destroy(materialObj);
            Destroy(Points);
            Destroy(path);
            if(checkProduct != null){
                checkProduct.finishProduct(true);
            }
        }
    }

}

