using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target2 : MonoBehaviour
{
	public float speed = 1;
	int intFlag = 1;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//当Z轴位置大于10的时候就向负方向移动
		if (transform.position.x <= -20)
		{
			intFlag = -1;
		}
		//当Z轴位置小于0的时候就向正方向移动
		if (transform.position.x >= -15)
		{
			intFlag = 1;
		}

		transform.Translate(new Vector3(intFlag, 0, 0) * Time.deltaTime * speed);
	}
}
