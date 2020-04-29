﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointHandler : MonoBehaviour
{

    [SerializeField]
    Transform m_SkeletonRoot;

    public List<Transform> Joints { get; set; }

    void OnEnable()
    {
        GetJoints();
    }

    public void GetJoints()
    {
        Joints = new List<Transform>();

        Queue<Transform> nodes = new Queue<Transform>();
        nodes.Enqueue(m_SkeletonRoot.parent);
        while (nodes.Count > 0)
        {
            Transform next = nodes.Dequeue();
            for (int i = 0; i < next.childCount; ++i)
            {
                nodes.Enqueue(next.GetChild(i));
            }
            
            Joints.Add(next);
        }
    }
    
}