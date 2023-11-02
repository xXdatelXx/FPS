using System;

namespace FPS.Toolkit.Tests.Dummys
{
    [Serializable]
    internal class DummySaveData
    {
        public string Name;
        public int Id;

        public DummySaveData(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}