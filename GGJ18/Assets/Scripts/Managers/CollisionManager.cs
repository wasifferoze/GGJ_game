using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AssemblyCSharp.Scripts
{
    [CreateAssetMenu()]
    public class CollisionManager : Manager
    {
        [SerializeField] public Rect StageArea;

        private List<ICollidable> Collidables = new List<ICollidable>();

        public void ReportCollidable(ICollidable item)
        {
            if (!Collidables.Contains(item))
            {
                Collidables.Add(item);
            }
        }

        public void ClearCollidables()
        {
            Collidables.Clear();
        }

        public ICollidable GetCollidable(int idx)
        {
            return Collidables[idx];
        }

        public void Init()
        {
            Collidables.Clear();
            Collidables.ForEach((item) => Debug.Log(item));
        }

        public IEnumerator FindCollision()
        {
            while (true)
            {
                yield return null;

                const int PROCESS_PER_FRAME = 250;
                int process = PROCESS_PER_FRAME;
                int count = Collidables.Count;
                for (int i = 0; i < count - 2; i++)
                {
                    for (int j = i + 1; j < count - 1; j++)
                    {
                        if (process-- <= 0)
                        {
                            process = PROCESS_PER_FRAME;
                            // yield return null;
                        }

                        ICollidable A = Collidables[i];
                        ICollidable B = Collidables[j];

                        Vector2 delta;
                        if (A.IsCollide(B, out delta))
                        {
                            A.OnCollide(B, delta);
                            B.OnCollide(A, -delta);
                        }
                        
                        // Wrap to stage
                        var pos = A.GetPosition();
                        var a = A.GetAngle();
                        if (pos.x < StageArea.xMin)
                        {
                            pos.x = StageArea.xMin;
                            A.SetPosition(pos);
                            A.SetAngle(Mathf.Atan2(Mathf.Cos(-a), Mathf.Sin(-a)));
                        }
                        else if (pos.x > StageArea.xMax)
                        {
                            pos.x = StageArea.xMax;
                            A.SetPosition(pos);
                            A.SetAngle(Mathf.Atan2(Mathf.Cos(-a), Mathf.Sin(-a)));
                        }
                        else if (pos.y < StageArea.yMin)
                        {
                            pos.y = StageArea.yMin;
                            A.SetPosition(pos);
                            A.SetAngle(Mathf.Atan2(Mathf.Cos(Mathf.PI - a), Mathf.Sin(Mathf.PI - a)));
                        }
                        else if (pos.y > StageArea.yMax)
                        {
                            pos.y = StageArea.yMax;
                            A.SetPosition(pos);
                            A.SetAngle(Mathf.Atan2(Mathf.Cos(Mathf.PI - a), Mathf.Sin(Mathf.PI - a)));
                        }
                    }
                }
            }
        }
    }
}
