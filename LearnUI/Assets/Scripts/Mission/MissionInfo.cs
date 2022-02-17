using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionInfo 
{
    public int id;
    public int process;
    public int star;
    public int state;

    public MissionInfo(int id ,int process,int star,int state)
    {
        this.id = id;
        this.process = process;
        this.star = star;
        this.state = state;
    }
}
