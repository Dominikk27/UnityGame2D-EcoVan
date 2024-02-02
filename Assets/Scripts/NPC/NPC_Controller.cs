using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC_Controller : MonoBehaviour
{
   /*===============[ Variables ]===============*/
    public float MovementSpeed = 2.5f;
    private Rigidbody2D rigidbody;
    private Animator anim;

    public bool inStore = false;
    public bool leaveStore = false; 

    private GameObject TaskCard;
    private TaskManager taskManager;
    private SpawnManager sManager;

    private float TargetPosition;
    private float DestroyPosition;
    private Transform getCurrentPosition;
    private float CurrentPosition;




    private bool tutorial_played;
    TutorialUI tutorialUI;

   /*===============[ START INIT ]===============*/
    void Start()
    {
        tutorialUI = FindObjectOfType<TutorialUI>();
        tutorial_played = DataToStore.tutorial_played;
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        sManager = FindObjectOfType<SpawnManager>();
        TaskCard = FindObjectOfType<TaskManager>().gameObject;
        taskManager = TaskCard.GetComponent<TaskManager>();

    }

   /*===============[ Update Check ]===============*/
    void Update()
    {

        anim.SetBool("isWalking", rigidbody.velocity.x != 0);
        if(!inStore && !leaveStore){
            getCurrentPosition = transform;
            MoveToStore();
        }
        if (!inStore && leaveStore){
            moveToDestroy();
        }
    }

   /*===============[ Movement ]===============*/
    public void MoveToStore(){
        rigidbody.velocity = new Vector2(-MovementSpeed, 0);
        CurrentPosition = getCurrentPosition.position.x;
        //Debug.Log("NPC POS: " + CurrentPosition);
        if (Mathf.Abs(CurrentPosition - TargetPosition) < 0.1f){
            arrivedToStore();
        }
    }
    
    
    public void arrivedToStore()
    {
        tutorial_played = DataToStore.tutorial_played;
        Debug.Log("Tutorial_PLAYED: " + tutorial_played);

        inStore = true;
        sManager.enableSpawn(false);
        rigidbody.velocity = Vector2.zero;
        taskManager.createTaskCard(gameObject.name);

        if (!tutorial_played)
        {
            DataToStore.tutorialScene = 2;
            tutorialUI.NPC_InStoreTutorial();
        }
    }
    
    public void LeaveStore(){
      Debug.Log("Leave Store!");
      inStore = false;
      leaveStore = true;
      //Debug.Log("inStore" + inStore);
      //Debug.Log("leaveStore" + leaveStore);
    }

    void moveToDestroy(){
        rigidbody.velocity = new Vector2(-MovementSpeed, 0);
        CurrentPosition = getCurrentPosition.position.x;
        if (Mathf.Abs(CurrentPosition - DestroyPosition) < 0.1f){
            Destroy(gameObject);
            switch(tutorial_played){
                case true:
                    SceneManager.LoadScene("City_Scene");
                break;
                case false:
                    DataToStore.tutorialScene = 1;
                    SceneManager.LoadScene("City_Scene_Tutorial");
                break;
            }
        }
    }





    /*===============[ Set Target ]===============*/
    public void setTarget(float setTarget, float setDestroy){
        //Debug.Log("Target je: " + setTarget);
        TargetPosition =  setTarget;
        DestroyPosition = setDestroy;

    }
}