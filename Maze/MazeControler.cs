using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    internal class MazeControler
    {
        public MazeVue Vue { set; get; }

        public MazeModel Model { set; get; }

        public void Start()
        {
            Vue.Display(Model, "This is a maze");
        }
    }
}
