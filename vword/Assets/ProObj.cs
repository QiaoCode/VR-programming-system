using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProObj : MonoBehaviour
{
    public ArrayList blocklst = new ArrayList();
    public string text;
    public GameObject Text;
    public int list_idx_;
    public string str;

    public Vector3 startposition = Vector3.zero;
    public Vector3 endPosition = Vector3.zero;
    public float speed = 20;


    public Quaternion ori;

    public Quaternion originRotation;
    public Quaternion currentRotation;
    public Vector3 Movement = new Vector3();

    private int Orientation = 0;  
    public GameObject targetcube;
    public GameObject targetcubePrefab;

    Vector3 forward = new Vector3(0, 0, 0.005f);
    Vector3 up = new Vector3(0, 0.01f, 0);
    Vector3 down = new Vector3(0, -0.01f, 0);
    public AudioSource soundHit;

    // Start is called before the first frame update
    void Start()
    {

        targetcube = GameObject.Instantiate(targetcubePrefab);
        Debug.Log("Create a new reference");
        targetcube.transform.position = this.gameObject.transform.position;

        GameObject ProObj = gameObject;
        //为blocklst增加八个空值 0-7
        blocklst.Add("0");
        blocklst.Add("0");
        blocklst.Add("0");
        blocklst.Add("0");
        blocklst.Add("0");
        blocklst.Add("0");
        blocklst.Add("0");
        blocklst.Add("0");
        Text = ProObj.transform.Find("listtext").gameObject;
        str = "list-start:";
        for (int i = 0; i < blocklst.Count; i++)
        {
            str += blocklst[i];
            str += ",";
        }
        Text.GetComponent<TextMesh>().text = str;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitReferenceObj()
    {
        targetcube.transform.position = transform.position;
    }

    public void getBlock(string s)
    {   
        blocklst[list_idx_] = s;
        str = "list-add:";

        for (int i = 0; i < blocklst.Count; i++)
        {
            str += blocklst[i];
            str += ",";
        }

        Text.transform.parent = this.gameObject.transform;

        Text.GetComponent<TextMesh>().text = str;
        

    }

    public void getIndex(int idx)
    {
        list_idx_ = idx;
    }

    public void getRemove(int idx)
    {
        blocklst[idx] = "0";

        str = "list-r:";

        for (int i = 0; i < blocklst.Count; i++)
        {
            str += blocklst[i];
            str += ",";
        }

        Text.transform.parent = this.gameObject.transform;

        Text.GetComponent<TextMesh>().text = str;
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.name == "RightHandAnchor"){
            //soundHit.Play();
            StartCoroutine(execute(blocklst)); 
        }
         
    }

    public void StartProgram()
    {
        StartCoroutine(execute(blocklst));
    }


    IEnumerator execute(ArrayList topOrder)
    {
        string[] topString = (string[])topOrder.ToArray(typeof(string));
        startposition = this.gameObject.transform.position;
        //originRotation = this.gameObject.transform.localRotation;
        foreach (string s in topString)
        {

            switch (s)
            {
                case "forward":
                    Vector3 newTarget = updateTarget(targetcube.transform, s);
                    targetcube.transform.position = newTarget;

                    while (Vector3.Distance(this.gameObject.transform.position, targetcube.transform.position) > 0.001f )//&& Vector3.Distance(this.gameObject.transform.position, targetcube.transform.position) < 10)
                    {//平移对象
                        this.gameObject.transform.Translate(forward);//沿着z轴1单位/秒，向前移动物体
                                                            //"编程块-前进".showAsToast();
                        yield return new WaitForSeconds(0.002f);
                    }
                    break;

                case "turnleft":
                    //正前0 
                    int angle = (Orientation - 1) * 90;
                    int tmp = Orientation * 90;
                    //-DebugConsole.Log("target position:" + target.position);
                    //transform.eulerAngles = new Vector3(0, angle, 0);

                    while (tmp >= angle)
                    {
                        this.gameObject.transform.eulerAngles = new Vector3(0, tmp, 0);
                        tmp = tmp - 10;
                        //yield return null;
                        yield return new WaitForSeconds(0.05f);
                    }

                    if (Orientation == 0)
                    {
                        Orientation = 3;
                    }
                    else
                    {
                        Orientation = Orientation - 1;
                    }
                    break;

                case "turnright":
                    int ag = (Orientation + 1) * 90;
                    int tp = Orientation * 90;

                    while (tp <= ag)
                    {
                        this.gameObject.transform.eulerAngles = new Vector3(0, tp, 0);
                        tp = tp + 10;
                        //yield return null;
                        yield return new WaitForSeconds(0.05f);
                    }

                    if (Orientation == 3)
                    {
                        Orientation = 0;
                    }
                    else
                    {
                        Orientation = Orientation + 1;
                    }
                    break;

                case "up":;
                    Vector3 newTarget1 = updateTarget(targetcube.transform, s);
                    targetcube.transform.position = newTarget1;
                    this.gameObject.transform.Translate(up);//沿着y轴向上移动物体

                    while (Vector3.Distance(this.gameObject.transform.position, targetcube.transform.position) > 0.05f && Vector3.Distance(this.gameObject.transform.position, targetcube.transform.position) < 16)
                    {//平移对象
                        this.gameObject.transform.Translate(forward);//沿着z轴1单位/秒，向前移动物体
                                                            //"编程块-前进".showAsToast();
                        yield return new WaitForSeconds(0.002f);
                    }
                    break;

                case "down":
 
                    Vector3 newTarget2 = updateTarget(targetcube.transform, s);
                    targetcube.transform.position = newTarget2;
                    this.gameObject.transform.Translate(down);


                    while (Vector3.Distance(this.gameObject.transform.position, targetcube.transform.position) > 0.05f && Vector3.Distance(this.gameObject.transform.position, targetcube.transform.position) < 16)
                    {//平移对象

                        this.gameObject.transform.Translate(forward);//沿着z轴1单位/秒，向前移动物体
                                                            //"编程块-前进".showAsToast();
                        yield return new WaitForSeconds(0.002f);
                    }
                    break;
            }
        
        }

    }

    Vector3 updateTarget(Transform origin, string s)
    {
        //更新目标地点
       
        Vector3 result = new Vector3();
        if (s.Equals("up"))
        {
            result = new Vector3(origin.position.x, origin.position.y + 1, origin.position.z);
        }
        else if (s.Equals("down"))
        {
            result = new Vector3(origin.position.x, origin.position.y - 1, origin.position.z);
        }
        else
        {
            result = new Vector3(origin.position.x, origin.position.y, origin.position.z);
        }
        switch (Orientation)
        {
            case 0://前
                result.z = result.z + 1f;
                break;
            case 1://右
                result.x = result.x + 1f;
                break;
            case 2://后
                result.z = result.z - 1f;
                break;
            case 3://左
                result.x = result.x - 1f;
                break;
        }

        return result;
    }

}
