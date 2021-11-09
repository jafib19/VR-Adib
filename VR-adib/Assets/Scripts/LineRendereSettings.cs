using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LineRendereSettings : MonoBehaviour
{

    public GameObject panel;
    public Image img;
    public Button btn; 


    //Declaring a LineRenderer to store the compontent attached to the GameObject
    [SerializeField] LineRenderer rend;

    //Settings for the LineRenderer are store as a Vector3 array of points. set up a V3 array to //initialise to start.
    Vector3[] points;

    // Start is called before the first frame update
    void Start()
    {
        //Get the LineRederer attached to the gameobject
        rend = gameObject.GetComponent<LineRenderer>();

        //Initialise the LineRederer
        points = new Vector3[2];

        //Set the start point of the linerenderer to the position of the gameObject. 
        points[0] = Vector3.zero;

        //Set the end point 20 units away from the GO on the Z axis (pointing forward) 
        points[1] = transform.position + new Vector3(0, 0, 20);

        // set the positions array on the LineRederer to our new values
        rend.SetPositions(points);
        rend.enabled = true;

        img = panel.GetComponent<Image>();
    }
    public LayerMask layerMask; 



    public bool AlignLineRenderer (LineRenderer rend)
    {
        bool hitBtn = false;

        Ray ray; 
        ray = new Ray(transform.position, transform.forward);
        RaycastHit hit; 

        if (Physics.Raycast(ray, out hit, layerMask))
        {

            points[1] = transform.forward + new Vector3(0, 0, hit.distance);

            rend.startColor = Color.red;
            rend.endColor = Color.red;

            btn = hit.collider.gameObject.GetComponent<Button>();

            hitBtn = true;
        }
        else
        {
            points[1] = transform.forward + new Vector3(0, 0, 20);

            rend.startColor = Color.green;
            rend.endColor = Color.green;

            hitBtn = false; 
        }
        rend.SetPositions(points);

        rend.material.color = rend.startColor;

        return hitBtn; 

    }

    public void ColorChangeOnClick()
    {
        if (btn != null)
        {
            if (btn.name == "Clover_btn")
            {
                img.color = Color.yellow;
                SceneManager.LoadScene(1);
                Debug.Log("Clover_Game");
            }
            else if (btn.name == "Memory_btn")
            {
                img.color = Color.red;
                SceneManager.LoadScene(2);
                Debug.Log("Memory_Game");
            }
            else if (btn.name == "settings_btn")
            {
                img.color = Color.green;
                Debug.Log("Settings");
            }
            else if (btn.name == "Hub_btn")
            {
                img.color = Color.blue;
                SceneManager.LoadScene(3);
                Debug.Log("Hub_Game");
            }
            else if (btn.name == "Quit_btn")
            {
                img.color = Color.black;
                Application.Quit();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        AlignLineRenderer(rend);

        if (AlignLineRenderer(rend) && Input.GetAxis("submit") > 0 )
        {
            btn.onClick.Invoke();
        }
    }
}
