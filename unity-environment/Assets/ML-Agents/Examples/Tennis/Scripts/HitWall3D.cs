﻿using System.Collections;
using System.Collections.Generic;
using MLAgents;
using UnityEngine;

public class HitWall3D : MonoBehaviour
{
    public GameObject areaObject;
    public int lastAgentHit;

    private TennisArea3D area;
    private TennisAgent3D agentA;
    private TennisAgent3D agentB;

    // Use this for initialization
    void Start()
    {
        area = areaObject.GetComponent<TennisArea3D>();
        agentA = area.agentA.GetComponent<TennisAgent3D>();
        agentB = area.agentB.GetComponent<TennisAgent3D>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "over")
        {
            if (lastAgentHit == 0)
            {
                agentA.AddReward(1.0f);
            }
            else
            {
                agentB.AddReward(1.0f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("iWall"))
        {
            if (collision.gameObject.name == "wallA")
            {
                if (lastAgentHit == 0)
                {
                    agentA.AddReward( -0.01f);
                    agentB.SetReward(0);
                    agentB.score += 1;
                }
                else
                {
                    agentA.SetReward(0);
                    agentB.AddReward(-0.01f);
                    agentA.score += 1;
                }
            }
            else if (collision.gameObject.name == "wallB")
            {
                if (lastAgentHit == 0)
                {
                    agentA.AddReward( -0.01f);
                    agentB.SetReward(0);
                    agentB.score += 1;
                }
                else
                {
                    agentA.SetReward(0);
                    agentB.AddReward( -0.01f);
                    agentA.score += 1;
                }
            }
            else if (collision.gameObject.name == "floorA")
            {
                if (lastAgentHit == 0 || lastAgentHit == -1)
                {
                    agentA.AddReward(-0.01f);
                    agentB.SetReward(0);
                    agentB.score += 1;
                }
                else
                {
                    agentA.AddReward( -0.01f);
                    agentB.SetReward(0);
                    agentB.score += 1;

                }
            }
            else if (collision.gameObject.name == "floorB")
            {
                if (lastAgentHit == 1 || lastAgentHit == -1)
                {
                    agentA.SetReward(0);
                    agentB.AddReward( -0.01f);
                    agentA.score += 1;
                }
                else
                {
                    agentA.SetReward(0);
                    agentB.AddReward( -0.01f);
                    agentA.score += 1;
                }
            }
            else if (collision.gameObject.name == "net" || collision.gameObject.name == "wallC" || collision.gameObject.name == "wallD")
            {
                if (lastAgentHit == 0)
                {
                    agentA.AddReward( -0.01f);
                    agentB.SetReward(0);
                    agentB.score += 1;
                }
                else
                {
                    agentA.SetReward(0);
                    agentB.AddReward( -0.01f);
                    agentA.score += 1;
                }
            }
            agentA.Done();
            agentB.Done();
            area.MatchReset();
        }

        if (collision.gameObject.CompareTag("agent"))
        {
            lastAgentHit = collision.gameObject.name == "AgentA" ? 0 : 1;
        }
    }
}