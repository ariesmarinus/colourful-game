using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
//using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TheTree : MonoBehaviour
{

    public int red;
    public int orange;
    public int yellow;
    public int green;
    public int cyan;
    public int blue;
    public int violet;
    private string colour;
    public Text message;
    public GameObject TreeMessage;
    public GameObject TaskComplete;
    public Text TaskCompleteMessage;
    public float message_counter;
    public float tree_counter;
    public int get_colour;
    public int get_number;
    public int the_colour;
    public GameObject rainbow;
    public bool complete;
    public GameObject tree;
    public Material glowing_tree;
    public GameObject player;
    public PlayerScript playerScript;
    public GameObject rainbow_camera;
    public bool task_exists;
    public GameObject where_move;
    public bool above_water_view;
    public GameObject rain;
    public GameObject inventory_menu;
    public bool inventory_active;
    public TMP_Text red_amount;
    public TMP_Text orange_amount;
    public TMP_Text yellow_amount;
    public TMP_Text green_amount;
    public TMP_Text cyan_amount;
    public TMP_Text blue_amount;
    public TMP_Text violet_amount;
    public GameObject RGB_menu;
    public bool RGB_active;
    public float R;
    public float G;
    public float B;
    public TMP_Text R_amount;
    public TMP_Text G_amount;
    public TMP_Text B_amount;
    public dayandnight dayandnight;
    public GameObject tree_speech;
    public GameObject[] pages;
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;
    public GameObject forward_button;
    public GameObject ready_button;
    public GameObject back_button;
    public GameObject start;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        red_amount.text = red.ToString();
        orange_amount.text = orange.ToString();
        yellow_amount.text = yellow.ToString();
        green_amount.text = green.ToString();
        cyan_amount.text = cyan.ToString();
        blue_amount.text = blue.ToString();
        violet_amount.text = violet.ToString();
        R_amount.text = R.ToString("0.00");
        G_amount.text = G.ToString("0.00");
        B_amount.text = B.ToString("0.00");
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (inventory_active == true)
            {
                inventory_menu.SetActive(false);
                inventory_active = false;
            }
            else
            {
                inventory_menu.SetActive(true);
                inventory_active = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (RGB_active == true)
            {
                RGB_menu.SetActive(false);
                RGB_active = false;
            }
            else
            {
                RGB_menu.SetActive(true);
                RGB_active = true;
            }

        }
        message_counter += Time.deltaTime;
        if (message_counter > 3)
        {
            TreeMessage.SetActive(false);
        }
        tree_counter += Time.deltaTime;
        if (complete == true && tree_counter > 3)
        {
            rainbow_camera.transform.position = Vector3.MoveTowards(rainbow_camera.transform.position, where_move.transform.position, 50 * Time.deltaTime);
            rainbow.SetActive(true);
            if (rain.activeSelf == true)
            {
                rain.SetActive(false);
            }
            if (tree_counter > 13)
            {
                rainbow_camera.SetActive(false);
                TaskComplete.SetActive(false);
                if (above_water_view == true)
                {
                    above_water_view = false;
                    playerScript.underwater = true;
                }
            }

        }
    }

    public void TreeTask()
    {
        if (tree_counter > 8)
        {
            string[] colors = { "red", "green", "orange", "yellow", "cyan", "blue", "violet" };
            get_colour = Random.Range(0, colors.Length - 1);
            colour = colors[get_colour];
            get_number = Random.Range(1, 2);
            tree_counter = 0;
            message.text = "Get" + " " + get_number.ToString() + " " + "of" + " " + colour.ToString();
            task_exists = true;
        }
        else
        {
            message.text = "Get" + " " + get_number.ToString() + " " + "of" + " " + colour.ToString();
        }
    }
    public void HappyTree()
    {
        Debug.Log("happy tree");
        TaskComplete.SetActive(true);
        TaskCompleteMessage.text = "Task complete \n Tree is happy";
        complete = true;
        if (dayandnight.is_raining == true)
        {
            dayandnight.is_raining = false;
        }
        RainbowHappen();
    }
    public void Complete()
    {
        if (the_colour == get_number && task_exists == true)
        {
            HappyTree();
        }
    }


    void OnMouseDown()
    {
        if (start.activeSelf == true)
        {
            start.SetActive(false);
        }
        if (R >= 225 && G >= 225 && B >= 225)
            {
                HappyTree();
            }
            else
            {
                tree_speech.SetActive(true);
                Cursor.visible = true;
            }
        
        //TreeTask();
        //TreeMessage.SetActive(true);
        //message_counter = 0;
        //UnloadColours();
        
    }

    void RainbowHappen()
    {
        if (complete == true)
        {
            tree_counter = 0;
            tree.GetComponent<MeshRenderer>().material = glowing_tree;
            rainbow_camera.SetActive(true);
            if (playerScript.underwater == true)
            {
                above_water_view = true;
                playerScript.underwater = false;
            }
            //rainbow.SetActive(true);
        }
    }

    public void UnloadColours()
    {
        if (R >= 225 && G >= 225 && B >= 225)
        {
            HappyTree();
        }
    }
    public void NextPage()
    {
        //for (int i = 0; i < pages.Length-1; i++)
        //{
        //    if (pages[i].activeSelf == true)
        //    {
        //        pages[i].SetActive(false);
        //        pages[i + 1].SetActive(true);
        //    }
        //}

        if (page1.activeSelf == true)
        {
            page1.SetActive(false);
            page2.SetActive(true);
            back_button.SetActive(true);
        }
        else if (page2.activeSelf == true)
        {
            page2.SetActive(false);
            page3.SetActive(true);
        }
        else if (page3.activeSelf == true)
        {
            page3.SetActive(false);
            page4.SetActive(true);
            forward_button.SetActive(false);
            ready_button.SetActive(true);
        }
    }

    public void PreviousPage()
    {
        if (page1.activeSelf == true)
        {

        }
        else if (page2.activeSelf == true)
        {
            page2.SetActive(false);
            page1.SetActive(true);
            back_button.SetActive(false);
        }
        else if (page3.activeSelf == true)
        {
            page3.SetActive(false);
            page2.SetActive(true);
        }
        else if (page4.activeSelf == true)
        {
            page4.SetActive(false);
            page3.SetActive(true);
            forward_button.SetActive(true);
            ready_button.SetActive(false);
        }
    }

    public void CloseSpeech()
    {
        tree_speech.SetActive(false);
        page4.SetActive(false);
        ready_button.SetActive(false);
        back_button.SetActive(false);
        page1.SetActive(true);
        forward_button.SetActive(true);
        Cursor.visible = false;
    }
}
