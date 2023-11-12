using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SetSonGameObjectTag : MonoBehaviour
{
    public static GameObject gb; //声明GameObject

    [MenuItem("ToolKit/SetSonGameobjectTag")]
    public static void SetSonTag()
    {
        gb = Selection.activeGameObject; //初始化Gameobject为选中的物体
        string gb_tag = gb.tag; //获取gameobject的tag
        
        //获取当前物体的所有子物体Transform组件
        Transform[] gb_son = gb.GetComponentsInChildren<Transform>(); 
        
        //遍历所有子物体，设置子物体Tag为父物体的Tag
        for (int i = 0; i < gb_son.Length; i++)
        {
            gb_son[i].tag = gb_tag;
            string gb_name = gb_son[i].name;
            
            //Test Code:
            // Debug.Log(i + gb_name +"成功");
        }

    }
}
