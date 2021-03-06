/********************************************************************************
** auth:  https://github.com/HushengStudent
** date:  2018/05/23 23:40:04
** desc:  测试;
*********************************************************************************/

using Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameworkTest : MonoBehaviour
{
    private GameObject _go;
    private Queue<GameObject> _goQueue = new Queue<GameObject>();

    private void Awake()
    {
        _go = new GameObject();
        _goQueue.Enqueue(_go);
    }

    public void NetWorkTest()
    {
        Packet_LoginRequest req = new Packet_LoginRequest();
        req.Data.id = 1001;
        req.Data.name = "HushengStudent";
        NetMgr.Instance.Send<Packet_LoginRequest>(req);
    }

    public void GetObjectFromPool()
    {
        if (_go)
        {
            GameObject temp = PoolMgr.Instance.Clone(_go);
            _goQueue.Enqueue(temp);
        }
    }

    public void ReleaseObject2Pool()
    {
        if (_goQueue.Count > 0)
        {
            PoolMgr.Instance.Release(_goQueue.Dequeue());
        }
    }

    public void ClearPool()
    {
        CoroutineMgr.Instance.RunCoroutine(PoolMgr.Instance.ClearPool());
    }

    public void BehaviorTreeTest()
    {
        var entity = EntityMgr.Instance.GetEntity<RoleEntity>(ulong.MaxValue);
        if (entity == null)
        {
            entity = EntityMgr.Instance.CreateEntity<RoleEntity>(1, ulong.MaxValue, "BehaviorTree", null);
        }
        BehaviorTreeMgr.Instance.CreateBehaviorTree(entity, "BehaviourTree.BT", true);
    }

}
