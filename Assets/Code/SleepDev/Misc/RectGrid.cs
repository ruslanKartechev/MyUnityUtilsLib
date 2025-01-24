using UnityEngine;

namespace SleepDev
{
    [System.Serializable]
    public class RectGrid
    {
        public Transform center;
        public float sizeX1 = 1;
        public float sizeX2 = 2;
        public float spacingX1 = 0.1f;
        public float spacingX2 = 0.1f;
        public int lengthX1;
        public int lengthX2;
        public Vector3 localStartPos;
        private int _frontCenter;
        
        public Vector3 CenterWorldPoint => center.position;
        public int Area => lengthX1 * lengthX2;

        public void InitAsXZ()
        {
            SetCenter(lengthX1, lengthX2, true);
        }
        
        public void SetCenter(int totalX, int totalY, bool XZ)
        {
            _frontCenter = 1;
            lengthX1 = totalX;
            lengthX2 = totalY;
            var localY = 0f;
            if (lengthX2 % 2 == 0)
                localY -= (lengthX2 / 2 - 0.5f) * (sizeX2 + spacingX2);
            else
                localY -= (lengthX2 / 2) * (sizeX2 + spacingX2);   
            
            var localX = 0f;
            if (lengthX1 % 2 == 0)
                localX -= (lengthX1 / 2 - 0.5f) * (sizeX1 + spacingX1);
            else
                localX -= (lengthX1 / 2) * (sizeX1 + spacingX1);
            
            if(XZ)
                localStartPos = new Vector3(localX, 0, localY);
            else
                localStartPos = new Vector3(localX, localY, 0);
        }
        
        public void SetCenterFront(int totalX, int totalY, bool XZ)
        {
            _frontCenter = -1;
            lengthX1 = totalX;
            lengthX2 = totalY;
            var localX = 0f;
            if (lengthX1 % 2 == 0)
                localX -= (lengthX1 / 2 - 0.5f) * (sizeX1 + spacingX1);
            else
                localX -= (lengthX1 / 2) * (sizeX1 + spacingX1);
            
            if(XZ)
                localStartPos = new Vector3(localX, 0, 0);
            else
                localStartPos = new Vector3(localX, 0, 0);
        }

        public Vector3 GetWorld(Vector3 local) => center.TransformPoint(local);
        
        public Vector3 GetPositionXZ(int x, int z)
        {
            return localStartPos + new Vector3(x * (sizeX1 + spacingX1), 
                0
                , _frontCenter * z * (sizeX2 + spacingX2));
        }
        
        public Vector3 GetPositionXY(int x, int y)
        {
            return localStartPos + new Vector3(x * (sizeX1 + spacingX1),  
                _frontCenter * y * (sizeX2 + spacingX2), 
                0);
        }
        
    }

    [System.Serializable]
    public class RectGridStack : RectGrid
    {
        public float layerHeight;
        
        public int currentCount { get; set; }
        
        public int nextX1 { get; set; }
        
        public int nextX2 { get; set; }
        
        public int currentY { get; set; }

        public Vector3 GetLocalTopMostPosition()
        {
            return localStartPos + new Vector3(0, currentY * layerHeight,0 );
        }
        
        public Vector3 GetWorldTopMostPosition()
        {
            return center.TransformPoint(GetLocalTopMostPosition());
        }
        
        public Vector3 GetPositionAndMoveNext()
        {
            currentCount++;
            var pos = GetPositionXZ(nextX1, nextX2);
            pos.y = layerHeight * currentY;
            nextX1++;
            CorrectCoordinates();
            return pos;
        }

        public void MovePositionBack()
        {
            currentCount--;
            if (currentCount < 0)
                currentCount = 0;
            nextX1--;
            CorrectCoordinates();
        }

        public Vector3 GetPrevLocalPos()
        {
            currentCount--;
            if (currentCount < 0)
                currentCount = 0;
            nextX1--;
            CorrectCoordinates();
            var pos = GetPositionXZ(nextX1, nextX2);
            pos.y = layerHeight * currentY;
            return pos;
        }
        
        public void CorrectCoordinates()
        {
            if (nextX1 >= lengthX1)
            {
                nextX1 = 0;
                nextX2++;
                if (nextX2 >= lengthX2)
                {
                    nextX2 = 0;
                    currentY++;
                }
            }
            else if (nextX1 < 0)
            {
                nextX1 = lengthX1 - 1;
                nextX2--;
                if (nextX2 < 0)
                {
                    nextX2 = 0;
                    currentY--;
                    if (currentY < 0)
                        currentY = 0;
                }
            }
        }

        public void Empty()
        {
            currentCount = 0;
            nextX1 = 0;
            nextX2 = 0;
            currentY = 0;
        }
        
    }
}