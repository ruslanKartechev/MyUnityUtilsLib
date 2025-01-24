namespace SleepDev
{
    [System.Serializable]
    public class TransformDataSerializable
    {
        /// <summary>
        /// World position
        /// </summary>
        public Vector3Serializable position = Vector3Serializable.zero;
        /// <summary>
        /// Global euler angles
        /// </summary>
        public Vector3Serializable eulerAngles = Vector3Serializable.zero;
        /// <summary>
        /// local scale
        /// </summary>
        public Vector3Serializable scale = Vector3Serializable.one;
        
        public override string ToString()
        {
            return $"TransformData position: {position}. eulers: {eulerAngles}, scale {scale}";
        }
        
        public TransformDataSerializable(){}

        public TransformDataSerializable(TransformDataSerializable other)
        {
            position = new Vector3Serializable(other.position);
            eulerAngles = new Vector3Serializable(other.eulerAngles);
            scale = new Vector3Serializable(other.scale);
        }
        
    }
}