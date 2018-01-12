using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    [SerializeField]
    private GameObject player, platForm;

    private float minX = -2.5f, maxX = 2.5f, minY = -5.5f, maxY = -3.5f;

    // Use this for initialization
    void Awake () {
        MakeSingliton();
        InitializeGame();

    }
	
	// Update is called once per frame
	void Update () {
        MoveCamera();
    }

    void MakeSingliton()
    {
        if (!instance)
        {
            instance = this;
        }
    }//MakeSingliton


    void InitializeGame()
    {
        Vector3 temp = new Vector3(Random.Range(minX,minX+1.5f), Random.Range(minY,maxY), 0);
        //Crate first platform در نیمه اول صفحه
        Instantiate(platForm,temp,Quaternion.identity);
        //Crate Player
        temp.y += 1.8f;
        Instantiate(player, temp, Quaternion.identity);
        //Crate second platform در نیمه دوم صفحه
        temp = new Vector3(Random.Range(maxX-1.5f,maxX), Random.Range(minY, maxY), 0);
        Instantiate(platForm, temp, Quaternion.identity);
    }


    void CreatePlatform()
    {
        //Crate second platform در نیمه دوم صفحه
        Vector3 temp = new Vector3(Random.Range(maxX - 1.5f, maxX), Random.Range(minY, maxY), 0);
        Instantiate(platForm, temp, Quaternion.identity);
    }

    void MoveCamera()
    {
        float x = Camera.main.transform.position.x;
        x =20f+ Mathf.Lerp(x,2*x,10f*Time.deltaTime);
        Camera.main.transform.position = new Vector3(x, Camera.main.transform.position.y, Camera.main.transform.position.z);


    }


}//end of class
